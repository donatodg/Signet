import { createRequire } from 'node:module';
import { createServer } from 'node:http';
import { spawn } from 'node:child_process';
import { mkdtemp, readFile, rm } from 'node:fs/promises';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { fileURLToPath } from 'node:url';

const require = createRequire(new URL('../../client/package.json', import.meta.url));
const { build } = require('esbuild');
const client = fileURLToPath(new URL('../../client', import.meta.url));
const profile = await mkdtemp(join(tmpdir(), 'signet-repx-browser-'));
const execute = (exe, args) => new Promise((resolve, reject) => {
  const child = spawn(exe, args);
  let stdout = '', stderr = '';
  child.stdout.on('data', data => { stdout += data; });
  child.stderr.on('data', data => { stderr += data; });
  child.on('error', reject);
  child.on('close', code => code === 0 ? resolve(stdout) : reject(new Error(stdout + stderr)));
});
let server;
try {
  const pdfPath = join(profile, 'Prueba.pdf');
  await execute(fileURLToPath(new URL('./bin/Debug/net48/Repx.exe', import.meta.url)), [pdfPath]);
  const pdf = (await readFile(pdfPath)).toString('base64');
  const result = await build({
    stdin: { contents: `
import React from 'react';
import { createRoot } from 'react-dom/client';
import { Screen } from './src/components/Screen';
import { api } from './src/api';
const pdf = ${JSON.stringify(pdf)};
let url, ejecuciones = 0, ventana, cerrada = false;
window.open = () => ventana = { document: { write: () => {} }, location: { replace: u => { url = u; } },
  close: () => { cerrada = true; }, closed: false };
const accion = { key: 'comprobante', titulo: 'Comprobante', menu: 'Imprimir', seleccion: 'Una', campos: [] };
api.schema = async () => ({ key: 'ComprobantesVentas', titulo: 'Ventas', area: 'Gestion', tipo: 'lista',
  parametros: [], columnas: [{ name: 'Id', type: 'int', label: 'Id' }, { name: 'Nombre', type: 'string', label: 'Nombre' }],
  camposEdicion: [], lookups: [], colecciones: [], permisos: { buscar: true }, acciones: [accion] });
api.buscar = async () => ({ filas: [{ Id: 25, Nombre: 'Venta REPX' }], truncado: false });
api.ejecutarAccion = async (pantalla, clave, ids) => {
  if (pantalla !== 'ComprobantesVentas' || clave !== 'comprobante' || ids[0] !== 25)
    throw new Error('No se enviaron la pantalla, accion y seleccion correctas');
  if (++ejecuciones === 2) throw new Error('No se encontro la plantilla de prueba');
  return { pdf: { nombre: 'Venta.pdf', contentType: 'application/pdf', base64: pdf } };
};
createRoot(document.getElementById('root')).render(<Screen screenKey="ComprobantesVentas" />);
const esperar = async f => {
  for (let i = 0; i < 300; i++) { if (f()) return; await new Promise(r => setTimeout(r, 10)); }
  throw new Error('Tiempo agotado esperando la interfaz');
};
const boton = texto => [...document.querySelectorAll('button')].find(b => b.textContent === texto);
const imprimir = async () => {
  boton('Imprimir ▾').click();
  await esperar(() => boton('Comprobante'));
  boton('Comprobante').click();
};
(async () => {
  try {
    await esperar(() => boton('Buscar'));
    boton('Buscar').click();
    await esperar(() => document.querySelector('tbody tr'));
    document.querySelector('tbody tr').click();
    await new Promise(r => setTimeout(r, 20));
    await imprimir();
    await esperar(() => url);
    const response = await fetch(url);
    const blob = await response.blob();
    const bytes = new Uint8Array(await blob.arrayBuffer());
    if (blob.type !== 'application/pdf' || new TextDecoder().decode(bytes.slice(0, 5)) !== '%PDF-')
      throw new Error('El visor no recibio un PDF real');
    let bin = ''; for (const byte of bytes) bin += String.fromCharCode(byte);
    if (btoa(bin) !== pdf) throw new Error('Se altero el PDF generado desde la plantilla');
    ventana.closed = true;
    await imprimir();
    await esperar(() => document.querySelector('.alert')?.textContent.includes('No se encontro la plantilla'));
    if (!cerrada) throw new Error('El error dejo una ventana de impresion pendiente');
    document.body.innerHTML = '<pre id="result">PASS: accion Imprimir envia seleccion, abre PDF REPX sin convertirlo a HTML y muestra errores.</pre>';
  } catch (e) { document.body.innerHTML = '<pre id="result">FAIL: ' + e.message + '</pre>'; }
})();
`, resolveDir: client, loader: 'tsx' },
    bundle: true, write: false, define: { 'process.env.NODE_ENV': '"production"' }, format: 'iife'
  });
  server = createServer((req, res) => {
    res.setHeader('Content-Type', req.url === '/test.js' ? 'text/javascript' : 'text/html');
    res.end(req.url === '/test.js' ? result.outputFiles[0].text
      : '<!doctype html><meta charset="utf-8"><div id="root"></div><script src="/test.js"></script>');
  });
  await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
  const output = await execute(process.env.SIGNET_TEST_BROWSER || 'C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe',
    ['--headless', '--disable-gpu', '--no-first-run', '--no-default-browser-check', '--user-data-dir=' + profile,
      '--dump-dom', '--virtual-time-budget=15000', 'http://127.0.0.1:' + server.address().port]);
  const match = /<pre id="result">([^<]+)<\/pre>/.exec(output);
  if (!match || !match[1].startsWith('PASS:')) throw new Error(match ? match[1] : 'El navegador no completo la prueba:\n' + output);
  console.log(match[1]);
} finally {
  server?.close();
  await rm(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 200 });
}
