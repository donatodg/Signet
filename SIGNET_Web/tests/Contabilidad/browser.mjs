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
import { Contabilidad } from './src/components/contabilidad/Contabilidad';
import { api } from './src/api';
const op = (key, name) => ({ key, name });
let guardadas = 0, registradas = 0, reversiones = 0, complementarios = 0, ejercicios = 0, sinPermisos = false;
let registrosLote = 0, aprobaciones = 0, politicasGuardadas = 0, bloqueos = 0, reaperturas = 0, exportados = 0, clasificados = 0;
let falloRevision = false, registradoPendiente = false;
let descargas = 0;
const clickEnlace = HTMLAnchorElement.prototype.click;
HTMLAnchorElement.prototype.click = function() {
  if (!this.download) return clickEnlace.call(this);
  if (!this.href.startsWith('blob:') || this.download !== 'contabilidad.pdf') throw new Error('Descarga sin archivo/blob autorizado');
  descargas++;
};
const fijo = lado => ({ origen: 1, magnitud: 1, lado, factor: 1, cuentaFija: lado === 1 ? 10 : 20,
  rol: null, prioridad: [], producto: null, categoria: null, impuesto: null, formaPago: null });
let config = { empresa: 1, version: 1, monedaBase: 1, asignaciones: [], plantillas: [
  { codigo: 'VENTA', nombre: 'Venta comercial', operatoria: 1, desde: '2026-01-01', hasta: null, tipoComprobante: 2,
    sucursal: null, invertir: false, reglas: [fijo(1), fijo(2)] }] };
const asiento = { plantilla: 'VENTA', descripcion: 'Venta comercial', debe: 121, haber: 121, renglones: [
  { cuenta: 10, debe: 121, haber: 0, regla: 1, origen: 'Cabecera', resolucion: 'Cuenta fija' },
  { cuenta: 20, debe: 0, haber: 121, regla: 2, origen: 'Cabecera', resolucion: 'Cuenta fija' }] };
const sim = { version: 2, firma: 'firma-servidor', hecho: { empresa: 1, operatoria: 1, documento: 8,
  fecha: '2026-11-02', descripcion: 'Factura A-0001-00000008', total: 121 }, asientos: [asiento, { ...asiento, plantilla: 'SEGUNDO' }] };
const lote = { id: 5, empresa: 1, operatoria: 1, documento: 8, fecha: '2026-11-02', usuario: 23, reversionDe: null,
  asientos: [101, 102], simulacion: sim };
api.contabilidadEstado = async () => ({ empresas: [op(1, 'Empresa prueba')], configurar: !sinPermisos, editar: !sinPermisos,
  simular: !sinPermisos, registrar: !sinPermisos, diario: !sinPermisos, revertir: !sinPermisos,
  bandeja: !sinPermisos, registrarBandeja: !sinPermisos, aprobar: !sinPermisos, automatizacion: !sinPermisos,
  editarAutomatizacion: !sinPermisos, periodos: !sinPermisos, bloquearPeriodos: !sinPermisos,
  reabrirPeriodos: !sinPermisos, conciliar: !sinPermisos, exportar: !sinPermisos });
api.contabilidadCatalogos = async () => ({ cuentas: [op(10, '1.01.01.01.000001 - Caja'), op(20, '4.01.01.01.000001 - Ventas')],
  monedas: [op(1, 'Pesos')], sucursales: [op(1, 'Central')], comprobantes: [op(2, 'Factura')],
  operatorias: [op(1, 'Venta'), op(2, 'Compra'), op(5, 'CostoVenta'), op(7, 'TransferenciaFondos'), op(12, 'Cierre')],
  ejercicios: [op(1, 'Ejercicio prueba (abierto)')], origenes: [op(1, 'Cabecera'), op(2, 'Productos')],
  magnitudes: [op(1, 'Total'), op(2, 'Neto')], lados: [op(1, 'Debe'), op(2, 'Haber')],
  dimensiones: [op(1, 'Empresa'), op(2, 'Producto')], medios: [], cajas: [op(1, 'Caja central')] });
api.contabilidadBandeja = async () => [8, 9].map(n => ({ id: n, empresa: 1, operatoria: 1, documento: n,
  sucursal: 1, fecha: '2026-11-02', estado: 1, intentos: 0, anulado: false, aprobado: false,
  descripcion: 'Factura pendiente ' + n, lote: registradoPendiente && n === 8 ? 5 : null }));
api.contabilidadRevisarLote = async (empresa, docs) => docs.map(d => d.documento === 9 && falloRevision ?
  { ...d, error: 'Falta cuenta parametrizada' } : { ...d, simulacion: { ...sim, hecho: { ...sim.hecho, documento: d.documento } } });
api.contabilidadRegistrarLote = async (empresa, docs) => {
  if (empresa !== 1 || docs.length !== 1 || docs[0].simulacion.firma !== sim.firma) throw new Error('Lote sin firma revisada');
  await new Promise(r => setTimeout(r, 50)); registrosLote++; registradoPendiente = true; return [lote];
};
api.contabilidadAprobar = async (empresa, r, motivo) => {
  if (empresa !== 1 || r.simulacion.firma !== sim.firma || motivo !== 'Revision independiente') throw new Error('Aprobacion sin firma o motivo');
  aprobaciones++;
};
api.contabilidadCostos = async () => [{ producto: 1, cantidad: 2, costoUnitario: 50, cotizacion: 1, costoTotal: 100, error: null }];
api.contabilidadOperativa = async () => ({ empresa: 1, moneda: 1, version: 1, activa: false, capturarCosto: false, dobleControl: true,
  politicas: [{ operatoria: 1, modo: 1, usuarioAutomatico: null, desde: '' }] });
api.contabilidadUsuariosAutomaticos = async () => [op(2, 'Contador autorizado')];
api.contabilidadGuardarOperativa = async (o, motivo) => {
  if (o.version !== 1 || o.politicas[0].modo !== 3 || o.politicas[0].usuarioAutomatico !== 2 || motivo !== 'Autorizar modo automatico')
    throw new Error('Politica sin actor/version/motivo');
  politicasGuardadas++; return { ...o, version: 2 };
};
api.contabilidadProcesar = async () => ({ procesados: 1 });
api.contabilidadPeriodos = async () => [{ mes: '2026-11-01', cerrado: bloqueos > reaperturas, usuario: 2, fecha: '2026-11-02', motivo: 'Cierre revisado' }];
api.contabilidadPeriodo = async (empresa, mes, cerrar, motivo) => {
  if (!mes.endsWith('-01') || motivo !== 'Cierre revisado') throw new Error('Periodo sin fecha/motivo');
  cerrar ? bloqueos++ : reaperturas++;
};
api.contabilidadAuditoria = async () => [{ Accion: 'Bloquear mes', Usuario: 2, Motivo: 'Cierre revisado' }];
api.contabilidadClasificacion = async () => ({ cuentas: [], cajas: [] });
api.contabilidadGuardarClasificacion = async (empresa, c, motivo) => {
  if (c.cuentas[0].cuenta !== 10 || c.cuentas[0].clase !== 1 || c.cajas[0].caja !== 1 || c.cajas[0].cuenta !== 10 || motivo !== 'Balance gerencial')
    throw new Error('Clasificacion/caja sin referencias');
  clasificados++;
};
api.contabilidadConciliacion = async (empresa, moneda) => {
  if (moneda !== 1) throw new Error('Conciliacion sin moneda');
  return [{ Estado: 'Conciliado por origen y balance', Gestion: 121, DebeRegistrado: 242, HaberRegistrado: 242 }];
};
api.contabilidadExportar = async (empresa, moneda, desde, hasta, tipo, formato) => {
  exportados++; return { nombre: 'contabilidad.' + formato, contentType: 'application/pdf', base64: btoa('%PDF-prueba') };
};
api.contabilidadConfiguracion = async () => structuredClone(config);
api.contabilidadGuardar = async c => {
  if (c.empresa !== 1 || c.plantillas[0].reglas[0].cuentaFija !== 10) throw new Error('Configuracion incorrecta');
  guardadas++; config = { ...c, version: c.version + 1 }; return structuredClone(config);
};
api.contabilidadDocumentos = async () => [op(8, 'A-0001-00000008 / Venta prueba'), op(9, 'A-0001-00000009 / Otra venta')];
api.contabilidadSimular = async s => {
  if (s.empresa !== 1 || s.operatoria !== 1 || s.documento !== 8) throw new Error('Origen incorrecto');
  return structuredClone(sim);
};
api.contabilidadRegistrar = async s => {
  if (s.firma !== 'firma-servidor') throw new Error('No envia firma de revision');
  await new Promise(r => setTimeout(r, 50)); registradas++; return lote;
};
api.contabilidadDiario = async () => reversiones ? [lote, { ...lote, id: 6, reversionDe: 5, asientos: [103, 104] }] : [lote];
api.contabilidadRevertir = async (empresa, id, fecha, motivo) => {
  if (empresa !== 1 || id !== 5 || !fecha || motivo !== 'Correccion prueba') throw new Error('Reversion sin motivo/origen');
  reversiones++; return { ...lote, id: 6, reversionDe: 5 };
};
api.contabilidadReferencias = async (empresa, dimension) => [op(1, dimension === 2 ? 'Producto prueba' : 'Referencia prueba')];
api.contabilidadCrearDocumento = async d => {
  if (d.hecho.empresa !== 1 || d.hecho.operatoria !== 5 || d.hecho.partidas[0].producto !== 1 ||
      d.hecho.partidas[0].importe !== 100 || !d.clave || d.moneda !== 1 || d.respaldo !== 'Valuacion revisada')
    throw new Error('Documento sin importes/respaldo correctos');
  complementarios++; return { ...d, id: 49 };
};
api.contabilidadEjercicio = async s => {
  if (s.empresa !== 1 || s.ejercicio !== 1 || s.operatoria !== 12 || s.sucursal !== 1 || !s.clave)
    throw new Error('Cierre sin parametros');
  ejercicios++; return { id: 50 };
};
api.contabilidadSaldos = async (empresa, moneda) => {
  if (empresa !== 1 || moneda !== 1) throw new Error('Libro sin empresa/moneda');
  return [{ cuenta: 10, nombre: 'Caja libro prueba', anterior: 10, debe: 100, haber: 20, saldo: 90 }];
};
api.contabilidadMayor = async (empresa, moneda, cuenta) => {
  if (empresa !== 1 || moneda !== 1 || cuenta !== 10) throw new Error('Mayor sin cuenta');
  return { anterior: 10, saldo: 90, movimientos: [{ asiento: 101, numero: 101, fecha: '2026-11-02',
    descripcion: 'Asiento del mayor prueba', debe: 100, haber: 20, saldo: 90 }] };
};
const root = createRoot(document.getElementById('root'));
root.render(<Contabilidad />);
const esperar = async f => {
  for (let i = 0; i < 500; i++) { if (f()) return; await new Promise(r => setTimeout(r, 10)); }
  throw new Error('Tiempo agotado: ' + document.body.textContent);
};
const boton = t => [...document.querySelectorAll('button')].find(b => b.textContent === t);
const campo = t => [...document.querySelectorAll('label')].find(l => l.firstChild?.textContent === t)?.querySelector('input,select');
const ingresar = async (input, value) => {
  Object.getOwnPropertyDescriptor(input.tagName === 'SELECT' ? HTMLSelectElement.prototype : HTMLInputElement.prototype, 'value').set.call(input, value);
  input.dispatchEvent(new Event(input.tagName === 'SELECT' ? 'change' : 'input', { bubbles: true }));
  await new Promise(r => setTimeout(r, 20));
};
const aceptar = async () => { await esperar(() => boton('Aceptar')); boton('Aceptar').click(); await new Promise(r => setTimeout(r, 20)); };
(async () => {
  try {
    await esperar(() => boton('Parametrización')); boton('Parametrización').click();
    await esperar(() => campo('Nombre'));
    if (!document.body.textContent.includes('1.01.01.01.000001 - Caja')) throw new Error('Cuenta sin nombre/codigo');
    await ingresar(campo('Nombre'), 'Venta parametrizada');
    boton('Guardar nueva versión').click(); await aceptar();
    await esperar(() => document.body.textContent.includes('Versión 2'));
    if (guardadas !== 1) throw new Error('No guardo nueva version');
    boton('Simular y registrar').click(); await aceptar();
    await esperar(() => campo('Documento confirmado')?.options.length === 3);
    await ingresar(campo('Documento confirmado'), '8'); boton('Simular asientos').click();
    await esperar(() => boton('Registrar asientos revisados'));
    if (registradas) throw new Error('Simular registro asientos');
    if (!document.body.textContent.includes('SEGUNDO') || !document.body.textContent.includes('Diferencia 0,00')) throw new Error('No muestra N asientos balanceados');
    await ingresar(campo('Documento confirmado'), '9');
    await esperar(() => !boton('Registrar asientos revisados'));
    await ingresar(campo('Documento confirmado'), '8'); boton('Simular asientos').click();
    await esperar(() => boton('Registrar asientos revisados'));
    const registrar = boton('Registrar asientos revisados'); registrar.click(); registrar.click(); await aceptar();
    await esperar(() => document.body.textContent.includes('Lote #5 registrado'));
    if (registradas !== 1) throw new Error('Doble toque duplico registracion');
    boton('Diario y reversiones').click(); await aceptar();
    await esperar(() => boton('Consultar diario')); boton('Consultar diario').click();
    await esperar(() => boton('Revertir lote #5')); boton('Revertir lote #5').click();
    await esperar(() => campo('Motivo'));
    await ingresar(campo('Motivo'), 'Correccion prueba');
    boton('Confirmar reversión').click(); await aceptar();
    await esperar(() => document.body.textContent.includes('Reversión de #5'));
    if (reversiones !== 1) throw new Error('No genero contraasiento');
    boton('Complementarios y ejercicios').click(); await aceptar();
    await esperar(() => boton('Agregar partida'));
    await ingresar(campo('Sucursal'), '1'); await ingresar(campo('Moneda local de los importes'), '1');
    await ingresar(campo('Descripción'), 'Costo documentado'); await ingresar(campo('Respaldo (documento / liquidación / valuación)'), 'Valuacion revisada');
    boton('Agregar partida').click();
    await esperar(() => campo('Referencia')?.options.length === 2);
    await ingresar(campo('Referencia de partida'), 'Factura 8, dos unidades');
    await ingresar(campo('Importe local con signo'), '100'); await ingresar(campo('Referencia'), '1');
    const aprobar = boton('Aprobar documento complementario'); aprobar.click(); aprobar.click(); await aceptar();
    await esperar(() => document.body.textContent.includes('Documento #49 aprobado'));
    if (complementarios !== 1 || registradas !== 1) throw new Error('Aprobar duplico o registro automaticamente');
    await ingresar(campo('Operatoria complementaria'), '12');
    await esperar(() => campo('Ejercicio de origen'));
    await ingresar(campo('Ejercicio de origen'), '1'); boton('Preparar apertura / cierre').click(); await aceptar();
    await esperar(() => document.body.textContent.includes('Documento #50 aprobado'));
    if (ejercicios !== 1 || registradas !== 1) throw new Error('Preparar cierre registro sin revisar');
    boton('Mayor y sumas y saldos').click(); await aceptar();
    await esperar(() => campo('Moneda del libro'));
    await ingresar(campo('Moneda del libro'), '1'); boton('Consultar libro').click();
    await esperar(() => document.body.textContent.includes('Caja libro prueba'));
    await ingresar(campo('Cuenta del mayor (vacío = sumas y saldos)'), '10');
    await esperar(() => !document.body.textContent.includes('Caja libro prueba'));
    boton('Consultar libro').click();
    await esperar(() => document.body.textContent.includes('Asiento del mayor prueba'));
    boton('Bandeja y aprobaciones').click(); await aceptar();
    await esperar(() => boton('Consultar pendientes')); boton('Consultar pendientes').click();
    await esperar(() => document.querySelector('input[aria-label="Seleccionar documento 8"]'));
    document.querySelector('input[aria-label="Seleccionar documento 8"]').click();
    await esperar(() => !boton('Revisar selección').disabled); boton('Revisar selección').click();
    await esperar(() => boton('Registrar lote revisado'));
    document.querySelector('input[aria-label="Seleccionar documento 9"]').click();
    await esperar(() => !boton('Registrar lote revisado')); falloRevision = true; boton('Revisar selección').click();
    await esperar(() => document.body.textContent.includes('Falta cuenta parametrizada'));
    if (!boton('Registrar lote revisado').disabled) throw new Error('Registra un lote con errores');
    document.querySelector('input[aria-label="Seleccionar documento 9"]').click();
    await esperar(() => !boton('Registrar lote revisado')); boton('Revisar selección').click();
    await esperar(() => boton('Registrar lote revisado'));
    await ingresar(campo('Motivo de aprobación independiente'), 'Revision independiente');
    boton('Aprobar revisión #8').click(); await aceptar(); await esperar(() => aprobaciones === 1);
    boton('Registrar lote revisado').click(); boton('Registrar lote revisado').click(); await aceptar();
    await esperar(() => document.body.textContent.includes('Registrados 1 lotes'));
    if (registrosLote !== 1) throw new Error('Doble toque registra dos lotes');
    boton('Automatización').click(); await aceptar(); await esperar(() => campo('Modo'));
    await ingresar(campo('Modo'), '3'); await esperar(() => campo('Usuario contable automático')?.options.length === 2);
    await ingresar(campo('Usuario contable automático'), '2'); await ingresar(campo('Motivo del cambio'), 'Autorizar modo automatico');
    boton('Guardar políticas').click(); await aceptar(); await esperar(() => politicasGuardadas === 1);
    boton('Períodos y auditoría').click(); await aceptar(); await esperar(() => campo('Mes'));
    await ingresar(campo('Motivo'), 'Cierre revisado'); boton('Bloquear mes').click(); await aceptar(); await esperar(() => bloqueos === 1);
    boton('Reabrir mes excepcionalmente').click(); await aceptar(); await esperar(() => reaperturas === 1);
    boton('Clasificación y cajas').click(); await aceptar(); await esperar(() => boton('Leer clasificación')); boton('Leer clasificación').click();
    await esperar(() => boton('Agregar clasificación')); boton('Agregar clasificación').click();
    await esperar(() => campo('Cuenta a clasificar')); await ingresar(campo('Cuenta a clasificar'), '10');
    await ingresar(campo('Rubro'), 'Disponibilidades'); boton('Vincular caja').click(); await esperar(() => campo('Caja / banco'));
    await ingresar(campo('Caja / banco'), '1'); await ingresar(campo('Cuenta de caja'), '10'); await ingresar(campo('Motivo de clasificación'), 'Balance gerencial');
    boton('Guardar clasificación y cajas').click(); await aceptar(); await esperar(() => clasificados === 1);
    boton('Conciliación e informes').click(); await aceptar(); await esperar(() => campo('Moneda del informe'));
    await ingresar(campo('Moneda del informe'), '1'); boton('Conciliar / consultar informe').click();
    await esperar(() => document.body.textContent.includes('Conciliado por origen y balance'));
    boton('Exportar PDF').click(); await esperar(() => descargas === 1);
    if (exportados !== 1) throw new Error('Exportacion duplicada');
    sinPermisos = true; root.render(<Contabilidad key="sin-permisos" />);
    await esperar(() => campo('Empresa contable'));
    await new Promise(r => setTimeout(r, 50));
    if (boton('Parametrización') || boton('Simular y registrar') || boton('Diario y reversiones') ||
        boton('Complementarios y ejercicios') || boton('Mayor y sumas y saldos') || boton('Bandeja y aprobaciones') ||
        boton('Automatización') || boton('Períodos y auditoría') || boton('Conciliación e informes')) throw new Error('Muestra acciones sin permiso');
    document.body.innerHTML = '<pre id="result">PASS: contabilidad anterior y cinco mejoras: seleccion invalida revisiones, lote con errores bloqueado, doble toque, aprobacion firmada, politicas, cierre/reapertura, clasificacion/cajas, informes/export y permisos.</pre>';
  } catch (e) { document.body.innerHTML = '<pre id="result">FAIL: ' + e.message + '</pre>'; }
})();
`, resolveDir: client, loader: 'tsx' },
  bundle: true, write: false, outfile: join(client, 'accounting-test.js'),
  define: { 'process.env.NODE_ENV': '"production"' }, format: 'iife'
});
const css = await readFile(join(client, 'src', 'styles.css'), 'utf8');
const server = createServer((req, res) => {
  const js = req.url === '/test.js';
  res.setHeader('Content-Type', js ? 'text/javascript' : 'text/html');
  res.end(js ? result.outputFiles.find(f => f.path.endsWith('.js')).text
    : '<!doctype html><meta name="viewport" content="width=device-width,initial-scale=1"><style>' + css
      + (result.outputFiles.find(f => f.path.endsWith('.css'))?.text ?? '')
      + '</style><div id="root"></div><script src="/test.js"></script>');
});
await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
const profile = await mkdtemp(join(tmpdir(), 'signet-contabilidad-'));
try {
  const output = await new Promise((resolve, reject) => {
    const child = spawn(process.env.SIGNET_TEST_BROWSER || 'C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe',
      ['--headless', '--disable-gpu', '--no-first-run', '--no-default-browser-check', '--window-size=1280,900',
        '--user-data-dir=' + profile, '--dump-dom', '--virtual-time-budget=20000', 'http://127.0.0.1:' + server.address().port]);
    let stdout = '', stderr = '';
    const timeout = setTimeout(() => { child.kill(); reject(new Error('Navegador no termino en 90 segundos:\\n' + stdout + '\\n' + stderr)); }, 90000);
    child.stdout.on('data', d => { stdout += d; }); child.stderr.on('data', d => { stderr += d; });
    child.on('error', e => { clearTimeout(timeout); reject(e); });
    child.on('close', code => { clearTimeout(timeout); code === 0 ? resolve(stdout) : reject(new Error(stderr)); });
  });
  const match = /<pre id="result">([^<]+)<\/pre>/.exec(output);
  if (!match || !match[1].startsWith('PASS:')) throw new Error(match ? match[1] : 'Prueba incompleta:\n' + output);
  console.log(match[1]);
} finally {
  server.close();
  await rm(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 200 });
}
