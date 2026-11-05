import { createRequire } from 'node:module';
import { createServer } from 'node:http';
import { spawn } from 'node:child_process';
import { mkdtemp, rm } from 'node:fs/promises';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { fileURLToPath } from 'node:url';

const require = createRequire(new URL('../../client/package.json', import.meta.url));
const { build } = require('esbuild');
const client = fileURLToPath(new URL('../../client', import.meta.url));
const result = await build({
  stdin: { resolveDir: client, loader: 'tsx', contents: `
import React from 'react';
import { createRoot } from 'react-dom/client';
import { App } from './src/App';
import { api } from './src/api';
sessionStorage.setItem('signet.token', 'menu-test');
localStorage.removeItem('signet.menuAbierto');
let modo = 'denegado', resolverViejo;
const usuario = { id: 23, nombre: 'Usuario prueba', empresa: 'Prueba' };
api.me = async () => usuario;
api.logout = async () => {};
api.catalogo = async () => {
  if (modo === 'pendiente') return await new Promise(r => resolverViejo = r);
  return modo === 'permitido' ? [{ area: 'Tesorería', pantallas: [{ key: 'Cajas', titulo: 'Cajas' }] }] : [];
};
api.contabilidadEstado = async () => ({ ingresar: modo === 'permitido' });
api.portalEstado = async () => ({ ingresar: modo === 'permitido' });
api.chatEstado = async () => ({ habilitado: false, permitido: false });
const root = createRoot(document.getElementById('root')); root.render(<App />);
const esperar = async f => {
  for (let i = 0; i < 500; i++) { if (f()) return; await new Promise(r => setTimeout(r, 10)); }
  throw new Error('Tiempo agotado: ' + document.body.textContent);
};
const boton = texto => [...document.querySelectorAll('button')].find(b => b.textContent === texto);
const enlace = href => document.querySelector('aside nav a[href="' + href + '"]');
const ingresar = async nuevo => {
  boton('Salir').click(); await esperar(() => boton('Ingresar prueba'));
  modo = nuevo; boton('Ingresar prueba').click();
};
(async () => {
  try {
    await esperar(() => document.body.textContent.includes('Sin pantallas habilitadas'));
    if (enlace('#/Cajas') || enlace('#/contabilidad') || enlace('#/vendedores'))
      throw new Error('Menu visible sin permiso de ingreso');
    await ingresar('permitido');
    await esperar(() => boton('▸ Tesorería'));
    boton('▸ Tesorería').click();
    await esperar(() => enlace('#/Cajas'));
    if (!enlace('#/contabilidad') || !enlace('#/vendedores')) throw new Error('Oculta accesos autorizados');
    await ingresar('pendiente'); await esperar(() => resolverViejo);
    if (enlace('#/Cajas') || enlace('#/contabilidad') || enlace('#/vendedores'))
      throw new Error('Conserva menu del usuario anterior mientras carga');
    await ingresar('denegado');
    await esperar(() => document.body.textContent.includes('Sin pantallas habilitadas'));
    resolverViejo([{ area: 'Tesorería', pantallas: [{ key: 'Cajas', titulo: 'Cajas' }] }]);
    await new Promise(r => setTimeout(r, 50));
    if (document.querySelector('.menu-area') || enlace('#/contabilidad') || enlace('#/vendedores'))
      throw new Error('Respuesta de sesion anterior repuebla menu');
    document.body.innerHTML = '<pre id="result">PASS: barra lateral por permisos, accesos especiales, areas vacias y aislamiento al cambiar de sesion.</pre>';
  } catch (e) { document.body.innerHTML = '<pre id="result">FAIL: ' + e.message + '</pre>'; }
})();
` },
  plugins: [{
    name: 'screens-unrelated-to-menu',
    setup(b) {
      b.onResolve({ filter: /components[\\/](Inicio|Login|Chat|CambiarClave|Screen|Vendedores|contabilidad[\\/]Contabilidad)$/ },
        args => ({ path: args.path.split(/[\\/]/).pop(), namespace: 'screen-stub' }));
      b.onLoad({ filter: /.*/, namespace: 'screen-stub' }, args => ({
        loader: 'tsx', resolveDir: client,
        contents: args.path === 'Login'
          ? "import React from 'react'; export function Login({onLogin}) { return <button onClick={() => onLogin({id: 23, nombre: 'Prueba', empresa: 'Prueba'})}>Ingresar prueba</button>; }"
          : 'export function ' + args.path + '() { return null; }'
      }));
    }
  }],
  bundle: true, write: false, outfile: join(client, 'menu-test.js'),
  define: { 'process.env.NODE_ENV': '"production"' }, format: 'iife'
});
const server = createServer((req, res) => {
  res.setHeader('Content-Type', req.url === '/test.js' ? 'text/javascript' : 'text/html');
  res.end(req.url === '/test.js' ? result.outputFiles.find(f => f.path.endsWith('.js')).text
    : '<!doctype html><div id="root"></div><script src="/test.js"></script>');
});
await new Promise(r => server.listen(0, '127.0.0.1', r));
const profile = await mkdtemp(join(tmpdir(), 'signet-menu-'));
try {
  const output = await new Promise((resolve, reject) => {
    const child = spawn(process.env.SIGNET_TEST_BROWSER || 'C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe',
      ['--headless', '--disable-gpu', '--no-first-run', '--no-default-browser-check', '--window-size=1280,900',
        '--user-data-dir=' + profile, '--dump-dom', '--virtual-time-budget=20000', 'http://127.0.0.1:' + server.address().port]);
    let stdout = '', stderr = '';
    child.stdout.on('data', d => { stdout += d; }); child.stderr.on('data', d => { stderr += d; });
    child.on('error', reject); child.on('close', c => c === 0 ? resolve(stdout) : reject(new Error(stderr)));
  });
  const match = /<pre id="result">([^<]+)<\/pre>/.exec(output);
  if (!match || !match[1].startsWith('PASS:')) throw new Error(match ? match[1] : output);
  console.log(match[1]);
} finally {
  server.close();
  await rm(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 200 });
}
