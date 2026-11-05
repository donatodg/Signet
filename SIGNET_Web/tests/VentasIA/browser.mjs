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
  stdin: { contents: `
import React from 'react';
import { createRoot } from 'react-dom/client';
import { Chat } from './src/components/Chat';
import { api } from './src/api';
let guardadas = 0, aperturas = 0, preguntas = 0, dependencias = 0;
const solicitud = { cliente: 'Cliente prueba', sucursal: 'Central', tipoComprobante: 'Venta',
  productos: [{ producto: 'P1', cantidad: 2 }, { producto: 'P2', cantidad: 3 }] };
const borrador = { solicitud, cliente: 'Cliente prueba', sucursal: 'Central', tipoComprobante: 'Venta',
  formaPago: 'Contado', total: 250, advertencias: ['Sin guardar'], lineas: [
    { producto: 'P1', moneda: 'Pesos', cantidad: 2, precioUnitario: 50, descuento: 0, iva: 0, total: 100 },
    { producto: 'P2', moneda: 'Pesos', cantidad: 3, precioUnitario: 50, descuento: 0, iva: 0, total: 150 }] };
const campo = (name, type, required = false) => ({ name, type, label: name, required, nullable: false, hidden: false, sensitive: false });
api.chatEstado = async () => ({ habilitado: true, permitido: true, configurado: true, limiteMes: 1000, tokensMes: 0 });
api.chatPreguntar = async (texto, historial, anterior) => {
  preguntas++;
  if (preguntas === 2) {
    if (!anterior || anterior.productos.length !== 2 || anterior.productos[0].cantidad !== 2)
      throw new Error('No se conserva el borrador anterior');
    return { respuesta: 'Actualizada', consultas: [], venta: { ...borrador, solicitud: { ...solicitud,
      productos: [{ producto: 'P1', cantidad: 4 }, solicitud.productos[1]] } } };
  }
  return { respuesta: 'Sin guardar', consultas: [], venta: borrador };
};
api.schema = async () => ({ key: 'ComprobantesVentas', titulo: 'Venta', camposEdicion: [
  campo('Observaciones', 'string', true), campo('NroComprobante', 'string', true),
  { ...campo('Id_FormaPago', 'int', true), lookup: 'FormasPago' }], parametrosGuardar: [],
  colecciones: [{ name: 'Detalle', label: 'Detalle', puedeQuitar: true, campos: [campo('Cantidad', 'decimal'), campo('Importe', 'decimal')], lookups: [] }],
  permisos: { agregar: true, modificar: true }, lookups: [] });
api.chatAbrirVenta = async (s) => {
  aperturas++;
  if (s.productos[0].cantidad !== 4) throw new Error('Se abrio un borrador anterior');
  return { pantalla: 'ComprobantesVentas', valores: { Observaciones: '-', NroComprobante: null, Id_FormaPago: 9 },
    detalles: { Detalle: [{ Id: 0, Cantidad: 4, Importe: 300 }] } };
};
api.obtener = async () => ({ datos: { Id_FormaPago: 3 },
  lookups: { FormasPago: [{ key: 3, name: 'Predeterminada' }, { key: 9, name: 'Elegida en chat' }] }, detalles: {} });
api.lookupsDependientes = async () => {
  dependencias++;
  return { lookups: {}, valores: { Id_FormaPago: 3 } };
};
api.guardar = async (key, id, valores) => {
  if (valores.Id_FormaPago !== 9) throw new Error('Se reemplazo la forma de pago elegida');
  if (valores.NroComprobante !== null) throw new Error('Se invento un numero de comprobante');
  guardadas++; return { id: 123 };
};
createRoot(document.getElementById('root')).render(<Chat onClose={() => {}} />);
const esperar = async (f) => {
  for (let i = 0; i < 300; i++) { if (f()) return; await new Promise(r => setTimeout(r, 10)); }
  throw new Error('Tiempo agotado esperando UI');
};
const enviar = async (texto) => {
  const ta = document.querySelector('textarea');
  Object.getOwnPropertyDescriptor(HTMLTextAreaElement.prototype, 'value').set.call(ta, texto);
  ta.dispatchEvent(new Event('input', { bubbles: true }));
  await new Promise(r => setTimeout(r, 20));
  document.querySelector('.chat-entrada').requestSubmit();
};
const abrir = () => [...document.querySelectorAll('button')].filter(b => b.textContent.includes('Revisar en formulario') && !b.disabled).pop();
(async () => {
  try {
    await esperar(() => document.querySelector('textarea'));
    await enviar('Carga 2 P1 y 3 P2 para Cliente prueba');
    await esperar(() => abrir());
    if (guardadas !== 0 || aperturas !== 0) throw new Error('La conversacion persistio o abrio sin confirmacion');
    await enviar('Mejor cuatro de P1');
    await esperar(() => preguntas === 2 && abrir());
    abrir().click();
    await esperar(() => document.querySelector('[role=dialog]'));
    await esperar(() => document.querySelector('[role=dialog]').textContent.includes('300'));
    await esperar(() => dependencias > 0);
    await new Promise(r => setTimeout(r, 20));
    if (document.querySelector('#f_Id_FormaPago').value !== '9') throw new Error('Los valores predeterminados reemplazaron la precarga');
    if (guardadas !== 0) throw new Error('Abrir guardo una venta');
    [...document.querySelectorAll('[role=dialog] button')].find(b => b.textContent === 'Cancelar').click();
    await esperar(() => !document.querySelector('[role=dialog]'));
    if (guardadas !== 0) throw new Error('Cancelar guardo una venta');
    abrir().click();
    await esperar(() => document.querySelector('[role=dialog] input[disabled]')?.value === 'Se asigna al guardar');
    [...document.querySelectorAll('[role=dialog] button')].find(b => b.textContent === 'Guardar').click();
    await esperar(() => guardadas === 1 && !document.querySelector('[role=dialog]'));
    if (abrir()) throw new Error('Se puede reutilizar un borrador ya guardado');
    if (aperturas !== 2) throw new Error('No se recalculo al volver a abrir');
    document.body.innerHTML = '<pre id="result">PASS: borrador, correccion, apertura, precios actualizados, cancelar sin guardar y guardado manual unico.</pre>';
  } catch (e) { document.body.innerHTML = '<pre id="result">FAIL: ' + e.message + '</pre>'; }
})();
`, resolveDir: client, loader: 'tsx' },
  bundle: true, write: false, define: { 'process.env.NODE_ENV': '"production"' }, format: 'iife'
});
const server = createServer((req, res) => {
  res.setHeader('Content-Type', req.url === '/test.js' ? 'text/javascript' : 'text/html');
  res.end(req.url === '/test.js' ? result.outputFiles[0].text
    : '<!doctype html><meta charset="utf-8"><div id="root"></div><script src="/test.js"></script>');
});
await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
const profile = await mkdtemp(join(tmpdir(), 'signet-ventas-ui-'));
try {
  const edge = process.env.SIGNET_TEST_BROWSER || 'C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe';
  const output = await new Promise((resolve, reject) => {
    const child = spawn(edge, ['--headless', '--disable-gpu', '--no-first-run', '--no-default-browser-check',
      '--user-data-dir=' + profile, '--dump-dom', '--virtual-time-budget=15000', 'http://127.0.0.1:' + server.address().port]);
    let stdout = '', stderr = '';
    child.stdout.on('data', data => { stdout += data; });
    child.stderr.on('data', data => { stderr += data; });
    child.on('error', reject);
    child.on('close', code => code === 0 ? resolve(stdout) : reject(new Error(stderr)));
  });
  const match = /<pre id="result">([^<]+)<\/pre>/.exec(output);
  if (!match || !match[1].startsWith('PASS:')) throw new Error(match ? match[1] : 'El navegador no completo la prueba:\n' + output);
  console.log(match[1]);
} finally {
  server.close();
  await rm(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 200 });
}
