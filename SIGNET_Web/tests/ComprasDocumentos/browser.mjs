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
const result = await build({
  stdin: { contents: `
import React from 'react';
import { createRoot } from 'react-dom/client';
import { ComprasDocumentos } from './src/components/compras-documentos/ComprasDocumentos';
import { api } from './src/api';
const op = (key, name) => ({ key, name });
const copiar = x => structuredClone(x);
let cargadas = 0, lecturas = 0, revisiones = 0, compras = 0, descargas = 0, cerro = false;
let carga;
let r;
const pixel = 'iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVQIHWP4z8DwHwAFgAI/ScLbtAAAAABJRU5ErkJggg==';
api.comprasDocOpciones = async () => ({ configurado: true, modelo: 'local-prueba', sucursales: [op(1, 'Central')],
  proveedores: [op(1, 'Proveedor prueba')], tipos: [op(2, 'Factura A')], depositos: [op(1, 'Deposito central')],
  centros: [op(1, 'Administracion')], formas: [op(1, 'Cuenta corriente')], monedas: [op(1, 'Pesos')], alicuotas: [0, 10.5, 21] });
api.comprasDocListar = async () => carga ? [copiar(carga)] : [];
api.comprasDocCargar = async (id, sucursal, archivos) => {
  if (!id || sucursal !== 1 || archivos.length !== 1 || archivos[0].nombre !== 'factura.png' || !archivos[0].base64) throw new Error('Carga sin originales/sucursal');
  await new Promise(resolve => setTimeout(resolve, 40)); cargadas++;
  carga = { id, version: 1, sucursal: 1, estado: 'Cargado', fecha: '2026-05-01', compra: null, lectura: null, revision: null, archivos: ['factura.png'], error: null };
  return copiar(carga);
};
api.comprasDocObtener = async () => copiar(carga);
api.comprasDocVista = async () => [pixel, pixel];
api.comprasDocOriginal = async () => { descargas++; return { nombre: 'factura.png', contentType: 'image/png', base64: pixel }; };
api.comprasDocLeer = async (id, version) => {
  if (version !== carga.version) throw new Error('Version de lectura obsoleta'); lecturas++; carga.version++;
  if (lecturas === 1) { carga.estado = 'Error'; carga.error = 'Lector local no disponible; originales conservados'; return copiar(carga); }
  const documento = { proveedor: 'Proveedor prueba', cuit: '20123456786', tipo: 'Factura', letra: 'A', puntoVenta: '1', numero: '123',
    fecha: '2026-05-01', moneda: 'ARS', total: 121, neto: 100, iva: 21, noGravado: 0, otrosImpuestos: 0, percepcionIva: 0, percepcionIibb: 0,
    percepcionGanancias: 0, itc: 0, percepcionIibbCapital: 0, descuento: 0, advertencias: ['Revise nitidez y tipo de comprobante'],
    items: [{ codigo: 'ABC', descripcion: 'Articulo factura', unidad: 'UN', cantidad: 1, cantidadStock: null, producto: 4, precioNeto: 100, descuento: 0, iva: 21, total: 121, tipoTotal: 'ConIva', recordarEquivalencia: false }] };
  r = { id, version: carga.version, sucursal: 1, proveedor: 1, tipoComprobante: 0, deposito: 0, centroCosto: 0, formaPago: 0, moneda: 0, cotizacion: 0,
    recepcion: '2026-05-02', vencimiento: '2026-05-10', revisado: false, documento };
  carga.estado = 'Leido'; carga.error = null; carga.lectura = copiar(documento); return copiar(carga);
};
api.comprasDocPropuesta = async () => copiar(carga.revision ? { ...carga.revision, version: carga.version } : r);
api.comprasDocProductos = async (buscar, id) => [op(4, 'ABC - Articulo del sistema')];
api.comprasDocRevision = async revision => {
  revisiones++; carga.version++; carga.revision = copiar(revision); return copiar(carga);
};
api.comprasDocRevisar = async revision => {
  const errores = !revision.revisado ? ['Debe revisar el original'] : revision.documento.total !== 121 ? ['El total de la factura no coincide'] : [];
  if (!revision.tipoComprobante || !revision.moneda || !revision.cotizacion || !revision.deposito || !revision.centroCosto || !revision.formaPago)
    errores.push('Faltan referencias');
  return { total: 121, neto: 100, iva: 21, firma: errores.length ? null : 'firma-revisada', errores, advertencias: ['No verifica CAE/QR'], compra: null };
};
api.comprasDocGuardar = async (revision, firma) => {
  if (!revision.revisado || firma !== 'firma-revisada' || revision.version !== carga.version) throw new Error('Compra sin firma/version/revision');
  await new Promise(resolve => setTimeout(resolve, 40)); compras++; carga.estado = 'Guardado'; carga.compra = 77; carga.version++; carga.revision = copiar(revision);
  return { total: 121, errores: [], advertencias: [], compra: 77 };
};
HTMLAnchorElement.prototype.click = function() { if (this.download !== 'factura.png' || !this.href.startsWith('blob:')) throw new Error('Original no descargado como archivo'); };
const root = createRoot(document.getElementById('root'));
root.render(<ComprasDocumentos onClose={() => { cerro = true; }} />);
const esperar = async fn => { for (let i=0;i<200;i++) { if (fn()) return; await new Promise(r=>setTimeout(r,20)); } throw new Error('Espera agotada: '+String(fn)); };
const boton = t => [...document.querySelectorAll('button')].find(b => b.textContent === t);
const campo = t => [...document.querySelectorAll('label')].find(l => l.firstChild?.textContent === t)?.querySelector('input,select');
const ingresar = async (input, value) => {
  if (!input) throw new Error('Campo no existe');
  Object.getOwnPropertyDescriptor(input.tagName==='SELECT' ? HTMLSelectElement.prototype : HTMLInputElement.prototype, 'value').set.call(input, value);
  input.dispatchEvent(new Event(input.tagName==='SELECT' ? 'change' : 'input',{bubbles:true})); await new Promise(r=>setTimeout(r,20));
};
const aceptar = async () => { await esperar(()=>boton('Aceptar')); boton('Aceptar').click(); await new Promise(r=>setTimeout(r,20)); };
const revisar = async () => { const c = [...document.querySelectorAll('input[type=checkbox]')].find(c=>c.parentElement.textContent.includes('Revisé el original')); if (!c.checked) c.click(); await new Promise(r=>setTimeout(r,20)); };
(async () => {
try {
  await esperar(()=>campo('Sucursal de la carga')?.options.length===2);
  const entrada = document.querySelector('input[type=file][multiple]');
  const files = new DataTransfer(); files.items.add(new File([new Uint8Array([137,80,78,71])], 'factura.png', {type:'image/png'})); entrada.files = files.files;
  entrada.dispatchEvent(new Event('change',{bubbles:true})); await new Promise(r=>setTimeout(r,20));
  const cargar = boton('Guardar originales'); cargar.click(); cargar.click();
  await esperar(()=>boton('Leer documento') && !boton('Leer documento').matches(':disabled'));
  if (cargadas!==1 || compras!==0 || !document.querySelector('img')) throw new Error('Carga duplicada o sin preview');
  boton('Página siguiente').click(); await esperar(()=>document.querySelector('img')?.alt.endsWith('2'));
  boton('Descargar original: factura.png').click(); await esperar(()=>descargas===1);
  await esperar(()=>!boton('Leer documento').matches(':disabled')); boton('Leer documento').click();
  await esperar(()=>document.body.textContent.includes('Lector local no disponible')); await esperar(()=>!boton('Leer documento').matches(':disabled'));
  boton('Leer documento').click(); await esperar(()=>campo('Total de la factura') && !boton('Validar borrador').matches(':disabled'));
  for (const [titulo, valor] of [['Tipo de comprobante','2'],['Depósito','1'],['Centro de costo','1'],['Forma de pago','1'],['Moneda del sistema','1'],['Cotización revisada','1']])
    await ingresar(campo(titulo),valor);
  await esperar(()=>campo('Producto del sistema')?.options.length===2);
  if (!campo('Producto del sistema').textContent.includes('Articulo del sistema')) throw new Error('Producto sin nombre');
  boton('Validar borrador').click(); await esperar(()=>document.body.textContent.includes('Debe revisar el original'));
  if (boton('Crear compra pendiente')) throw new Error('Permite compra sin revision humana');
  await ingresar(campo('Total de la factura'),'999'); await revisar();
  boton('Validar borrador').click(); await esperar(()=>document.body.textContent.includes('El total de la factura no coincide'));
  if (boton('Crear compra pendiente')) throw new Error('Permite compra con mismatch');
  await ingresar(campo('Total de la factura'),'121'); await revisar();
  boton('Validar borrador').click(); await esperar(()=>boton('Crear compra pendiente'));
  await ingresar(campo('Número'),'124'); if (boton('Crear compra pendiente')) throw new Error('No invalida firma al editar');
  await ingresar(campo('Número'),'123');
  boton('Guardar correcciones sin crear compra').click(); await esperar(()=>revisiones===1 && document.body.textContent.includes('Correcciones guardadas'));
  if (compras!==0) throw new Error('Guardar correcciones genero compra');
  await ingresar(campo('Número'),'999');
  await ingresar(document.querySelector('label > select[value]') || [...document.querySelectorAll('select')].find(s=>s.parentElement.textContent.startsWith('Retomar una carga propia')),carga.id);
  await aceptar(); await esperar(()=>campo('Número').value==='123');
  await revisar(); boton('Validar borrador').click(); await esperar(()=>boton('Crear compra pendiente'));
  const guardar = boton('Crear compra pendiente'); guardar.click(); guardar.click(); await aceptar();
  await esperar(()=>document.body.textContent.includes('Compra #77 creada PENDIENTE'));
  if (compras!==1 || boton('Leer documento') || ![...document.querySelectorAll('fieldset')].some(f=>f.disabled)) throw new Error('Compra duplicada o editable despues de guardar');
  boton('Cerrar').click(); await esperar(()=>cerro);
  root.unmount(); document.body.innerHTML='<pre id="result">PASS: web compras por imagen: originales, preview, reintento local, referencias, productos, revision obligatoria, diferencias, firma invalidada, borrador recuperado y compra pendiente sin doble toque.</pre>';
} catch(e) { document.body.innerHTML='<pre id="result">FAIL: '+e.message+'</pre>'; }
})();
`, resolveDir: client, loader: 'tsx' }, bundle: true, write: false, outfile: join(client, 'purchases-test.js'),
  define: { 'process.env.NODE_ENV': '"production"' }, format: 'iife'
});
const css = await readFile(join(client, 'src', 'styles.css'), 'utf8');
const server = createServer((req, res) => {
  const js = req.url === '/test.js'; res.setHeader('Content-Type', js ? 'text/javascript' : 'text/html');
  res.end(js ? result.outputFiles.find(f => f.path.endsWith('.js')).text : '<!doctype html><meta charset="utf-8"><style>' + css +
    result.outputFiles.find(f => f.path.endsWith('.css')).text + '</style><div id="root"></div><script src="/test.js"></script>');
});
await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
const profile = await mkdtemp(join(tmpdir(), 'signet-compras-documentos-'));
try {
  const output = await new Promise((resolve, reject) => {
    const child = spawn(process.env.SIGNET_TEST_BROWSER || 'C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe',
      ['--headless', '--disable-gpu', '--no-first-run', '--no-default-browser-check', '--window-size=1280,900',
        '--user-data-dir=' + profile, '--dump-dom', '--virtual-time-budget=20000', 'http://127.0.0.1:' + server.address().port]);
    let stdout = '', stderr = '';
    const timeout = setTimeout(() => { child.kill(); reject(new Error('Navegador no termino: ' + stderr)); }, 90000);
    child.stdout.on('data', d => { stdout += d; }); child.stderr.on('data', d => { stderr += d; });
    child.on('error', e => { clearTimeout(timeout); reject(e); });
    child.on('close', code => { clearTimeout(timeout); code === 0 ? resolve(stdout) : reject(new Error(stderr)); });
  });
  const match = /<pre id="result">([^<]+)<\/pre>/.exec(output);
  if (!match || !match[1].startsWith('PASS:')) throw new Error(match ? match[1] : 'Prueba incompleta:\n' + output);
  console.log(match[1]);
} finally {
  server.close(); await rm(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 200 });
}
