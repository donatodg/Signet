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
import { Vendedores } from './src/components/Vendedores';
import { api } from './src/api';
let guardadas = 0, revisadas = 0, token = '', ultimaVenta, monedaConsultada, sinPermisos = false;
const opcion = (key, name) => ({ key, name });
const producto = { id: 8, codigo: 'P8', nombre: 'Producto prueba', precio: 100, iva: 21, descuento: 0, moneda: 'Pesos', cantidadStock: true };
api.portalEstado = async () => ({ precios: !sinPermisos, cuenta: !sinPermisos, ventas: !sinPermisos });
api.portalEntidades = async (uso, texto, tipo) => ({ opciones: [opcion(7, tipo === 2 ? 'Proveedor prueba' : 'Cliente prueba')], hayMas: false });
api.portalProductos = async (uso, cliente, buscar) => {
  if (cliente !== 7 || buscar !== 'prueba') throw new Error('Busqueda sin cliente o producto correcto');
  return { productos: [producto], hayMas: false };
};
api.portalOpciones = async () => ({ sucursales: [opcion(1, 'Central')], comprobantes: [opcion(2, 'Venta')],
  centros: [opcion(3, 'Centro')], vendedores: [opcion(4, 'Vendedor prueba')], formasPago: [opcion(5, 'Contado')] });
api.portalTalonarios = async (cliente, sucursal, comprobante) => {
  if (cliente !== 7 || sucursal !== 1 || comprobante !== 2) throw new Error('Dependencias de talonario incorrectas');
  return [opcion(6, 'A-0001')];
};
api.portalRevisar = async venta => {
  revisadas++; ultimaVenta = venta; token = 'revision-' + revisadas;
  if (venta.productos[0].cantidad !== 2 || venta.productos[0].cantidadStock !== 4)
    throw new Error('No se enviaron cantidad y cantidad stock');
  return { token, impuestos: [{ nombre: 'Percepcion prueba', alicuota: 3, importe: 6 }],
    resumen: { cliente: 'Cliente prueba', sucursal: 'Central', tipoComprobante: 'Venta',
    formaPago: 'Contado', total: 248, advertencias: ['Pendiente de confirmacion'], lineas: [
    { producto: 'Producto prueba', cantidad: 2, precioUnitario: 100, descuento: 0, iva: 42, total: 242, moneda: 'Pesos' }] } };
};
api.portalGuardar = async t => {
  if (t !== token) throw new Error('Token incorrecto');
  await new Promise(r => setTimeout(r, 50));
  guardadas++; return { id: 15, comprobante: 'A-0001-00000015', mensaje: 'Pendiente de confirmacion por administracion' };
};
api.portalMonedas = async () => [opcion(1, 'Pesos'), opcion(2, 'Dolares')];
api.portalCuenta = async (entidad, moneda, desde, hasta, tipo) => {
  monedaConsultada = moneda;
  if (entidad !== 7 || tipo !== 1 || !desde || !hasta) throw new Error('Consulta incorrecta');
  return { saldo: 150, saldoAnterior: 50, movimientos: [{ id: 1, fecha: '2026-10-28T12:00:00',
    movimiento: 'Factura', concepto: 'Venta', debito: 100, credito: 0, saldo: 150 }] };
};
const root = createRoot(document.getElementById('root'));
root.render(<Vendedores />);
const esperar = async f => {
  for (let i = 0; i < 500; i++) { if (f()) return; await new Promise(r => setTimeout(r, 10)); }
  throw new Error('Tiempo agotado esperando UI: ' + document.body.textContent);
};
const boton = texto => [...document.querySelectorAll('button')].find(b => b.textContent === texto);
const campo = texto => [...document.querySelectorAll('label')].find(l => l.firstChild?.textContent === texto)?.querySelector('input,select,textarea');
const ingresar = async (input, value) => {
  const proto = input.tagName === 'SELECT' ? HTMLSelectElement.prototype : HTMLInputElement.prototype;
  Object.getOwnPropertyDescriptor(proto, 'value').set.call(input, value);
  input.dispatchEvent(new Event(input.tagName === 'SELECT' ? 'change' : 'input', { bubbles: true }));
  await new Promise(r => setTimeout(r, 20));
};
(async () => {
  try {
    await esperar(() => boton('Lista de precios'));
    boton('Lista de precios').click();
    await esperar(() => boton('Cliente prueba')); boton('Cliente prueba').click();
    await ingresar(campo('Productos'), 'prueba');
    await esperar(() => document.body.textContent.includes('Precio unitario sin IVA') && document.body.textContent.includes('100'));
    if (guardadas || revisadas) throw new Error('Consultar precios modifico ventas');
    boton('Volver al portal').click(); await esperar(() => boton('Cuenta corriente')); boton('Cuenta corriente').click();
    await esperar(() => boton('Cliente prueba')); boton('Cliente prueba').click();
    await ingresar(campo('Moneda'), '2');
    boton('Consultar cuenta').click();
    await esperar(() => document.body.textContent.includes('Saldo al cierre: 150'));
    if (monedaConsultada !== 2) throw new Error('No respeto la moneda');
    await ingresar(campo('Tipo de entidad'), '2');
    await esperar(() => !document.body.textContent.includes('Saldo al cierre:'));
    if (!boton('Consultar cuenta').disabled) throw new Error('Se conservo la entidad de otro tipo');
    boton('Volver al portal').click(); await esperar(() => boton('Nueva venta')); boton('Nueva venta').click();
    await esperar(() => boton('Cliente prueba')); boton('Cliente prueba').click();
    await ingresar(campo('Productos'), 'prueba');
    await esperar(() => boton('Agregar Producto prueba')); boton('Agregar Producto prueba').click();
    await esperar(() => campo('Cantidad'));
    await ingresar(campo('Cantidad'), '2'); await ingresar(campo('Cantidad Stock'), '4');
    await esperar(() => !boton('Revisar venta').disabled); boton('Revisar venta').click();
    await esperar(() => boton('Guardar pendiente de confirmación'));
    if (!document.body.textContent.includes('Percepcion prueba (3%): 6 pesos')
      || !document.body.textContent.includes('Total en pesos: 248')) throw new Error('No muestra impuestos y total de la revision');
    if (guardadas) throw new Error('Revisar guardo automaticamente');
    if (ultimaVenta.centroCosto !== 3 || ultimaVenta.vendedor !== 4 || ultimaVenta.talonario !== 6)
      throw new Error('No completo opciones unicas');
    await ingresar(campo('Cantidad'), '3');
    await esperar(() => !boton('Guardar pendiente de confirmación'));
    await ingresar(campo('Cantidad'), '2'); boton('Revisar venta').click();
    await esperar(() => boton('Guardar pendiente de confirmación'));
    const guardar = boton('Guardar pendiente de confirmación'); guardar.click(); guardar.click();
    await esperar(() => document.body.textContent.includes('Venta registrada'));
    if (guardadas !== 1) throw new Error('El doble toque duplico la venta');
    if (!document.body.textContent.includes('Pendiente de confirmacion')) throw new Error('No indica estado pendiente');
    boton('Cargar otra venta').click();
    await esperar(() => boton('Revisar venta'));
    if (campo('Vendedor').value !== '4') throw new Error('Nueva venta perdio valores unicos');
    sinPermisos = true;
    root.render(<Vendedores key="sin-permisos" />);
    await esperar(() => document.body.textContent.includes('Sin permisos'));
    if (boton('Nueva venta') || boton('Lista de precios')) throw new Error('Se muestran acciones no permitidas');
    document.body.innerHTML = '<pre id="result">PASS: portal movil, precios por cliente, cuenta por moneda, venta con stock, revision invalidada al editar, guardado manual sin doble toque y permisos.</pre>';
  } catch (e) { document.body.innerHTML = '<pre id="result">FAIL: ' + e.message + '</pre>'; }
})();
`, resolveDir: client, loader: 'tsx' },
  bundle: true, write: false, outfile: join(client, 'portal-test.js'),
  define: { 'process.env.NODE_ENV': '"production"' }, format: 'iife'
});
const css = await readFile(join(client, 'src', 'styles.css'), 'utf8');
const portalCss = result.outputFiles.find(f => f.path.endsWith('.css'))?.text ?? '';
const server = createServer((req, res) => {
  res.setHeader('Content-Type', req.url === '/test.js' ? 'text/javascript' : 'text/html');
  res.end(req.url === '/test.js' ? result.outputFiles.find(f => f.path.endsWith('.js'))?.text ?? result.outputFiles[0].text
    : '<!doctype html><meta name="viewport" content="width=device-width,initial-scale=1"><style>' + css + portalCss
      + '</style><div id="root"></div><script src="/test.js"></script>');
});
await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
const profile = await mkdtemp(join(tmpdir(), 'signet-vendedores-'));
try {
  const output = await new Promise((resolve, reject) => {
    const child = spawn(process.env.SIGNET_TEST_BROWSER || 'C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe',
      ['--headless', '--disable-gpu', '--no-first-run', '--no-default-browser-check', '--window-size=390,844',
        '--user-data-dir=' + profile, '--dump-dom', '--virtual-time-budget=20000', 'http://127.0.0.1:' + server.address().port]);
    let stdout = '', stderr = '';
    child.stdout.on('data', d => { stdout += d; }); child.stderr.on('data', d => { stderr += d; });
    child.on('error', reject); child.on('close', code => code === 0 ? resolve(stdout) : reject(new Error(stderr)));
  });
  const match = /<pre id="result">([^<]+)<\/pre>/.exec(output);
  if (!match || !match[1].startsWith('PASS:')) throw new Error(match ? match[1] : 'El navegador no completo la prueba:\n' + output);
  console.log(match[1]);
} finally {
  server.close();
  await rm(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 200 });
}
