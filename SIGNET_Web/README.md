# SIGNET Web

Versión web (React) de SIGNET que **reutiliza el backend original** (`*_BL`, `VENET_Common`, `VENET_Comun`, `VENET_DataEntity`) sin copiar ni modificar su código.

## Arquitectura

**Compras por imagen/PDF:** en Comprobantes de compras, **Compra desde foto / PDF** abre un flujo nuevo
en React y WinForms. Guarda originales, lee con un modelo de visión local, propone proveedor/productos,
permite guardar correcciones, valida totales/duplicados y crea una compra **pendiente**, sin confirmarla.
BL compartido: `VENET_Gestion_BL\ComprasDocumentos*.cs`; API: `/api/compras-documentos`.
Requiere migración manual `004-ComprasDocumentos.sql` y configurar `SIGNET_COMPRAS_VISION_MODELO`;
no usa servicios externos por defecto. Ver **[activación, privacidad y límites](INSTALACION.md#compras-desde-fotopdf-web-y-winforms)**.

```
SIGNET_Web/
├─ shared/                    Proyectos SDK net48 que ENLAZAN los .cs originales
│  ├─ VENET_*.Web/            (AssemblyName = nombre original, ej. VENET_General_BL)
│  │   └─ *.Sources.props     Lista de archivos generada por tools/Sync-Sources.ps1
│  └─ VENET_Common.Web/Web/   Adaptadores web (únicos archivos nuevos del backend):
│       SignetConfigSystem    ConfigurationManager.AppSettings por usuario/petición
│       SignetRequestContext  Sesión del usuario (AsyncLocal)
│       Seguridad             Misma API que el original, estado por sesión
│       FormularioShims       frmMensaje/frmMensajeSiNo -> excepción (sin UI)
├─ src/SIGNET_Web.Api/        ASP.NET Core 2.3 sobre .NET Framework 4.8
│  ├─ Screens/                Descubre por reflexión los Managers del BL
│  └─ Controllers/            /api/auth/*, /api/catalog, /api/screens/{pantalla}/*
├─ client/                    React + TypeScript (Vite)
└─ tools/Sync-Sources.ps1     Regenera los enlaces a los fuentes originales
```

### Cómo se reutiliza el BL
Todos los Managers siguen el mismo patrón, que la API usa de forma genérica:

| BL original                                  | API                                        |
|----------------------------------------------|--------------------------------------------|
| `XManager.Buscar(ParametrosBusquedas)`        | `POST /api/screens/X/buscar`               |
| `new XManager(entidad)` + propiedad entidad   | `GET /api/screens/X/registros/{id\|nuevo}` |
| `xManager.Save()` / `Save(param)`             | `POST /api/screens/X/registros`            |
| `XManager.Eliminar(entidad)`                  | `DELETE /api/screens/X/registros/{id}`     |
| propiedades `List<KeyNamePair>` del Manager   | combos (`lookups`)                         |
| `LoginManager.VerificaUsuario` (igual que frmLogin) | `POST /api/auth/login`               |
| `SeguridadUsuariosCambioPasswordManager`      | `POST /api/auth/cambiar-clave`             |

Validaciones, reglas de negocio, encriptación de claves, filtros por empresa/sucursal asignadas y permisos
(`Seguridad.ObtenerPermiso` con el mismo Módulo/Formulario que los formularios WinForms) son los del código original.
Los formularios y grillas React se generan desde los tipos del BL (DataAnnotations: `Required`, `StringLength`, etc.).

Las bases se leen del mismo `Setup.xml` encriptado del escritorio (`Signet:SetupXmlPath`), o de `Signet:Bases` en `appsettings.json`.
Las credenciales de las bases nunca se envían al navegador.

## Requisitos
- .NET SDK (6+) y .NET Framework 4.8 (Developer Pack)
- Node.js 18+
- Acceso a SQL Server de las bases configuradas
- Ensamblados licenciados de DevExpress Reporting 23.2 para compilar los reportes. Por defecto se usan los de
  `VENET_Informes\VENET_Informes_UI\bin\Debug`; otra ubicacion: `dotnet build -p:DevExpressRuntimeDir=C:\Componentes\DevExpress`.

## Ejecutar

Desarrollo (dos consolas):
```powershell
cd src\SIGNET_Web.Api; dotnet run          # API en http://localhost:5080
cd client; npm install; npm run dev        # UI en http://localhost:5173 (proxy /api -> 5080)
```

Iniciar / detener rápido en esta PC (usa la última compilación, modo desarrollo; corre sin ventana y la salida queda en `src\SIGNET_Web.Api\App_Data\logs\consola.log`):
```powershell
powershell -ExecutionPolicy Bypass -File C:\Signet\SIGNET_Web\tools\Iniciar.ps1
powershell -ExecutionPolicy Bypass -File C:\Signet\SIGNET_Web\tools\Detener.ps1
```

Producción: ver **[INSTALACION.md](INSTALACION.md)** (paso a paso para instalar en otra PC o servidor, tarea programada, HTTPS, actualización y backup). Resumen:
```powershell
powershell -ExecutionPolicy Bypass -File tools\Publicar.ps1 -SetupXml C:\Signet\SIGNET\SIGNET\Setup.xml -Zip
# genera C:\publish\SIGNET_Web (+ .zip): copiar a la PC destino y ejecutar SIGNET_Web.Api.exe
```
Cambiar el puerto: `appsettings.json` → `Urls`, o `--urls http://0.0.0.0:8080`. Usar HTTPS (proxy inverso/IIS) en producción.

Diagnóstico: `SIGNET_Web.Api.exe --dump-schemas pantallas.json` vuelca las pantallas detectadas en el BL.

**Login de desarrollo:** con `dotnet run` (entorno `Development`, ver `Properties\launchSettings.json`) se puede ingresar con
usuario `1` y clave `1` sin validar contra la base, como administrador. Se habilita con `Signet:LoginDesarrollo` en
`appsettings.Development.json` y **no funciona en Production** aunque se active la opción.

## Configuración (`appsettings.json`, sección `Signet`)
- `SetupXmlPath`: ruta al `Setup.xml` del escritorio. `Bases`: bases adicionales (Name, DataSource, DataBase, User, Pass, Provider).
- `SessionMinutes`: inactividad máxima de la sesión. `MaxFilasBusqueda`: tope de filas por búsqueda.
- `CamposOcultos`: propiedades que no se muestran. `Formularios`: mapeo Manager → nombre de formulario para permisos cuando no coinciden.

**Logo:** el menú muestra `logo.png` (por defecto, el ícono de la aplicación de escritorio). Para usar el logo de la empresa,
reemplazar `client\public\logo.png` y recompilar el cliente, o reemplazar directamente `wwwroot\logo.png` en el sitio publicado.

## Menús Imprimir y Operaciones
Cada pantalla replica los menús de barra del formulario original (`Imprimir` y `Operaciones`), con los mismos permisos
(`Seguridad.ObtenerPermiso(Módulo, Formulario, Imprimir/Operaciones, "descripción")`), confirmaciones y validaciones del handler.
- **Imprimir → Resultado de la Búsqueda**: disponible en todas las pantallas; abre la grilla (columnas visibles, filtros y orden actuales)
  en una ventana imprimible (equivale a `ShowRibbonPrintPreview`).
- **Plantillas `.repx`**: ventas, remitos, cotizaciones, pedidos, recibos, ordenes de pago y listas de precios se renderizan
  con DevExpress en el servidor, con los datos del BL (`...Manager.Imprime...`). Se abre el PDF en el visor del navegador
  para imprimirlo o descargarlo, conservando el diseno de la plantilla. Ventas desde cuenta corriente usa el mismo flujo.
  Los reportes sin plantilla configurada (`<Ninguno>`) conservan la salida HTML existente.
- **Operaciones** (Confirmar, Anular con motivo, Depositar/Rechazar cheques, etc.) llaman a los mismos métodos del BL. Las que operan sobre
  varios registros admiten selección múltiple en la grilla con **Ctrl+clic** / **Shift+clic**.
- **Todas las opciones del escritorio están implementadas en la web** (ninguna queda "solo escritorio"):
  - Diálogos propios → formularios dinámicos (combos, fechas, selección múltiple `multi`, archivos `file`). Resultados como tablas en pantalla.
  - **PDF** (Generar PDF / adjuntos de mail): reutiliza el PDF del `.repx`; los documentos HTML sin plantilla siguen requiriendo Edge/Chrome headless.
  - **Enviar por e-mail** (comprobantes de venta, recibos, OP, rendiciones, vales, pedidos, cta. cte. de entidades): `Sistema.EnvioMail` del BL con el PDF adjunto.
  - **Importaciones Excel** (vales masivos, personal configuración/vencimientos, etc.): se sube el archivo y se procesa con el mismo método del BL.
  - **Generar comprobante / nota de crédito / duplicar**: abre el alta de la pantalla destino con cabecera y detalles precargados.
  - **AFIP – Presentar comprobantes**: `shared\VENET_WSFE_BL.Web` compila el `WSFE.cs` original (requiere certificado de la empresa y salida a internet).
  - **Sisorg** (legajos e importación de personal): `shared\VENET_Personal_Sisorg.Web`; requiere el parámetro `Personal_VerImportacionSisorg`.
  - Excepciones deliberadas: "Importar archivo" del Padrón IIBB y "Copiar tareas" de Producción Variantes no se publican porque sus handlers del escritorio están vacíos.
- Formularios secundarios del escritorio migrados:
  - **Grupos asignados** (`frmSeguridadObjetosGrupos`): operación en *Seguridad → Grupos Objetos*.
  - **Detalle de lista de precios** (`frmProductosListasPreciosDetalle`): operación *Detalle* en Listas de Precios; abre la pantalla de actualización filtrada por la lista, con *Calcular* (% o importe) e *Importar precios productos*.
  - **Lista de precio por categoría** (`frmProductosListasPreciosImprimir`): selección múltiple de categorías y clientes con mail; envía el PDF a los elegidos.
  - **Configurar talonarios** (`frmTipoIva_Configuracion`): abre `TipoIvaConfiguracion` filtrado por el tipo de IVA (con "Quitar filtro"); los altas heredan el tipo.
  - **Actualizar precios productos** de Producción: aplica la misma conversión de porcentaje que el escritorio.
  - **Imágenes** (`frmImagenes`): acción *Imágenes* en Productos, Cotizaciones y Comprobantes de Ventas (galería, alta múltiple, modificar, eliminar, rotar, imprimir, guardar). API: `api/imagenes/{tabla}/{id}`.
  - `frmTipoMovimientos` no se migró: su Manager no está compilado en el BL original (código muerto) y ningún formulario lo abre.
- Código: `src\SIGNET_Web.Api\Screens\Acciones\` (`AccionDef.cs` framework, `Acciones{Tesoreria,Gestion,Otros}*.cs` por módulo).
  Para agregar una opción: implementar `IAccionesModulo` y registrar un `AccionDef` con la clave de la pantalla (nombre del Manager sin "Manager").

### Configuracion de plantillas REPX

- En cada base, `RutaOriginalesComprobantesVentas` debe apuntar a la carpeta de reportes **accesible desde el servidor web**.
  En el talonario, `Reporte` contiene el nombre relativo, por ejemplo `Factura.repx`. Se respetan las copias del talonario
  y, en ventas, las opciones original/duplicado/triplicado. Remitos usa `Ventas_NombreRemito`; cotizaciones respeta `UtilizaReporte_B`.
- Para listas de precios se usa `ListaPrecios.repx` de esa carpeta cuando existe; si no existe se conserva el listado HTML.
- La cuenta de Windows que ejecuta la API necesita lectura de las plantillas, subreportes e imagenes y las fuentes del diseno instaladas.
  La impresora local se elige en el visor PDF: no se imprime silenciosamente desde el servidor.
- Las plantillas deben estar serializadas como XML (`SaveLayoutToXml`), sin scripts ni controles personalizados del proyecto WinForms.
  Las reglas deben estar en la BL o en expresiones del reporte. Los subreportes externos se buscan dentro de la misma carpeta configurada;
  no se admiten URLs remotas ni rutas que salgan de ella. No se aceptan plantillas enviadas por el navegador.
- Una plantilla configurada ausente o invalida produce un error; no se sustituye silenciosamente por HTML.
  Los `.repx` reales no estan incluidos en este arbol de fuentes: deben copiarse a la carpeta configurada.
- Pruebas sin base de datos: `dotnet build tests\Repx\Repx.csproj` y `tests\Repx\bin\Debug\net48\Repx.exe`.
  Generan plantillas temporales y verifican PDF real, paginas/copias, subreportes y errores.
  `node tests\Repx\browser.mjs` verifica la accion Imprimir en React con un PDF generado por esas pruebas (requiere Edge).

## Contabilidad parametrizable

Acceso: **`/#/contabilidad`** o **Contabilidad** en el menu. Los maestros tambien aparecen agrupados en el area
Contabilidad: plan de cuentas, ejercicios, asientos, tipos de asiento heredados y categorias contables.

### Separacion de proyectos

- `VENET_Contabilidad\VENET_Contabilidad_BL`: maestros migrados desde Gestion, modelo de eventos,
  motor de reglas, adaptadores de documentos y servicio transaccional.
- `VENET_Contabilidad\VENET_Contabilidad_UI`: formularios WinForms contables existentes, trasladados al nuevo ensamblado.
  Los botones del escritorio abren este modulo; conservan nombres de formulario y permisos.
- `SIGNET_Web\shared\VENET_Contabilidad_BL.Web`: enlaza las mismas fuentes BL, con el contexto por sesion de la web.
- `client\src\components\contabilidad`: interfaz React de parametrizacion, simulacion, diario y reversiones.
  Esta parametrizacion nueva se administra desde la web; los formularios nativos trasladados son los maestros existentes.

Las entidades y tablas contables existentes se conservan en DataEntity para no romper sus claves ni datos.
El codigo de maestros ya no se compila dentro de Gestion_BL/UI. Los proyectos nuevos estan en ambas soluciones.
Los tipos de asiento antiguos **no se transforman automaticamente** en reglas nuevas: el generador anterior estaba incompleto.

### Instalacion y permisos

Con respaldo previo, un administrador debe ejecutar **`database\001-Contabilidad.sql`** en cada base que vaya a usar el motor.
El archivo tambien se incluye al publicar. Crea tablas de versiones, lotes y vinculos con los asientos existentes;
no genera movimientos ni asigna permisos a grupos. Puede ejecutarse nuevamente sin duplicar esos objetos.
Si falta instalarlo, el motor muestra un error explicito; no crea tablas automaticamente.

Los permisos nuevos se registran en el modulo de seguridad **Gestion**, manteniendo la compatibilidad con los maestros:

| Formulario | Permisos |
|---|---|
| `ContabilidadConfiguracion` | Ingresar + Buscar para consultar; Ingresar + Modificar para guardar una version |
| `ContabilidadRegistracion` | Ingresar + Buscar para simular; Ingresar + Agregar para registrar |
| `ContabilidadDiario` | Ingresar + Buscar para consultar; Ingresar + Eliminar para generar una reversion |

Asignarlos desde Seguridad / matriz de permisos y volver a iniciar sesion. No son permisos del chat.
Se validan empresas asignadas, sucursales del documento y permisos de consulta sobre su pantalla original.
El diario es una consulta contable por **empresa autorizada**, no una cartera privada de vendedor.

### Modelo de parametrizacion

`OperatoriaContable` identifica el hecho de negocio, con valores persistentes: Venta, Compra, Cobranza, Pago,
CostoVenta, MovimientoStock, TransferenciaFondos, LiquidacionSueldos, Devengamiento, Ajuste, Apertura y Cierre.
Un evento puede seleccionar **N plantillas**, y cada plantilla produce un asiento independiente.
Se filtran por operatoria, vigencia, sucursal y tipo de comprobante. Ventas y compras exigen un tipo explicito;
para notas de credito se configura una plantilla especifica con **Invertir Debe/Haber**. No se adivina la naturaleza del comprobante.

Cada regla define:

- Origen: cabecera, productos, impuestos/ajustes o medios de pago.
- Magnitud: total, neto, IVA, importe de la partida o costo historico cuando el adaptador lo suministra.
- Debe/Haber y factor: `1` toma el 100%; `0,60` y `0,40` permiten distribuir con dos reglas.
- Cuenta fija **o** rol contable con una secuencia configurable de resolucion.
- Filtros opcionales de producto, categoria, impuesto o forma de pago.

Las dimensiones de resolucion son Empresa, Producto, Categoria, Cliente, Proveedor, FormaPago, Impuesto, Especie,
MedioTesoreria y Componente. Los roles son nombres definidos por el contador, por ejemplo `Ventas`, `Deudores`, `Caja`, `IVA`.
Para cada rol se asigna una cuenta del plan existente a la referencia elegida.
Las cuentas se seleccionan por codigo y descripcion; solo se admiten cuentas activas imputables
(segun la convencion actual del plan: subcuenta distinta de `000000`).

**Ejemplo de venta por producto** (neto 100, IVA 21, total 121):

| Regla | Origen / magnitud | Lado | Resolucion |
|---|---|---|---|
| 1 | Cabecera / Total | Debe 121 | Rol Deudores: Cliente -> Empresa |
| 2 | Productos / Neto | Haber 100 | Rol Ventas: Producto -> Categoria -> Empresa |
| 3 | Productos / IVA | Haber 21 | Cuenta fija IVA debito fiscal |

En Asignaciones: `Ventas + Producto 1 -> cuenta de ventas del producto 1`. Para otros productos, la misma regla
busca categoria y finalmente la cuenta general de la empresa. Si no encuentra cuenta, **bloquea**, no usa una cuenta arbitraria.
Se pueden agregar otras plantillas para el mismo evento; todas deben balancear y se guardan juntas.

Una venta a credito normalmente imputa Deudores. La cobranza posterior debita Caja/Bancos y acredita Deudores,
resolviendo el medio real del recibo. **Forma de pago "Contado" no demuestra por si sola que hubo ingreso de efectivo**:
no contabilizar caja en la venta y otra vez en el recibo. Las reglas deben reflejar la operatoria real del negocio.

Los impuestos detallados resuelven por Impuesto. Los campos heredados de cabecera de ventas/compras
(percepciones, otros impuestos, ITC, descuentos, etc.) se exponen como partidas tipadas por **Componente**.
El descuento de compra se incorpora con signo negativo. No se mezclan esos identificadores con TipoImpuestos.
Los medios de tesoreria distinguen efectivo, cheques propios/de terceros, cuenta corriente, tarjetas y retencion/percepcion.

### Registracion y controles

1. Abrir un ejercicio contable para la empresa y las fechas correspondientes.
2. Guardar la configuracion; cada guardado crea una version inmutable. Dos usuarios no pueden sobrescribir silenciosamente la misma version.
3. En **Simular y registrar**, elegir operatoria y buscar un documento confirmado por numero o concepto.
4. Simular, revisar todos los asientos, las cuentas, los importes y el origen de cada renglon.
5. Registrar: el servidor vuelve a leer el documento y recalcular la propuesta. Si cambio la firma de revision, exige simular de nuevo.
6. Consultar **Diario y reversiones** o la pantalla **Asientos**. Para corregir un lote, indicar fecha y motivo y generar el contraasiento.

Adaptadores de gestion disponibles: **ventas de clientes, compras de proveedores, recibos de clientes y ordenes de pago a proveedores**,
confirmados y no anulados. Los importes se expresan en moneda local usando las cotizaciones guardadas en el detalle del documento;
la moneda de configuracion debe ser esa moneda local. No se recotiza con valores actuales.
La fecha contable usada por los adaptadores es la fecha de confirmacion/liquidacion, sin componente horario.

Cada plantilla debe balancear exactamente despues del redondeo por renglon a dos decimales (mitades alejadas de cero).
No hay cuenta automatica de diferencias: una diferencia, incluso de un centavo, exige revisar las reglas.
Un ejercicio cerrado, una cuenta faltante/no imputable o un costo ausente impiden registrar.
El lote, sus N asientos y la trazabilidad se guardan en una unica transaccion SQL.
Una clave unica por empresa/operatoria/documento evita duplicados, incluso tras reinicios.
Un reintento devuelve el lote existente; despues de revertirlo no se permite contabilizar otra vez el mismo origen.
La numeracion se coordina por empresa entre el motor nuevo y el manager de asientos manuales.

El diario conserva usuario, documento, fecha, version, firma, reglas, cuentas resueltas y partidas de origen.
Los asientos generados no se editan ni eliminan desde el manager; se corrigen por reversion, preservando el original.
El cierre/anulacion de un documento de gestion **no revierte automaticamente** un lote contable ya registrado:
el contador debe registrar su reversion explicitamente.

### Alcance y validacion

El motor no ejecuta SQL, scripts ni formulas arbitrarias guardadas por el usuario: utiliza magnitudes y factores tipados.
Por defecto la registracion es explicita. La tercera fase agrega automatizacion **opt-in** para confirmaciones futuras,
con cola durable y politicas autorizadas; no se habilita al instalar ni existe retroactividad automatica.

La segunda fase agrega transferencias de fondos, documentos complementarios y apertura/cierre desde el libro.
La registracion recibe solamente empresa, operatoria, ID y firma; vuelve a leer los datos persistidos.
No se calcula costo historico usando el costo actual del producto: el detalle de venta heredado guarda un importe de costo
unitario, pero no una cotizacion/moneda de costo historica suficiente para inferir su valor contable con seguridad.
Tampoco se agregan en esta entrega ajuste por inflacion, libros legales, balance legal, consolidacion ni presentaciones fiscales.
La parametrizacion y el criterio de reconocimiento deben validarse con el contador de la empresa antes de usar datos reales.

Pruebas: `dotnet build tests\Contabilidad\Contabilidad.csproj`, `tests\Contabilidad\bin\Debug\net48\Contabilidad.exe`
y `node tests\Contabilidad\browser.mjs`. Cubren reglas, prioridades, distribucion, firmas, transferencias, complementarios,
traslado exacto de saldos, errores, permisos y flujo web con API simulada.
El harness opcional `tests\Contabilidad\bin\Debug\net48\Contabilidad.exe --sql ".\INSTANCIA"`
solo admite servidor local y autenticacion integrada. Crea una base temporal `SIGNET_Contabilidad_Test_<GUID>`,
valida las tres migraciones repetidas, rollback de lote/enlaces, indices unicos, applock entre conexiones, triggers de cola/costos,
inmutabilidad y bloqueo mensual, y elimina esa base.
No acepta nombres de bases existentes. Requiere permisos para crear/eliminar bases.
No se pudo ejecutar aqui: no hay SQL Server/LocalDB activo y Docker esta detenido.
Este harness valida invariantes SQL con esquema minimo; no sustituye la integracion del BL contra una copia completa de SIGNET.
Los modulos nativos pueden compilarse con dependencias ya compiladas usando
`-p:NativeDependenciesDir=C:\ruta\binarios-nativos`; `DevExpressRuntimeDir` permite indicar el runtime 23.2.
En un despliegue nativo definitivo, recompilar y distribuir tambien DataEntity y los proyectos dependientes; esa opcion no sustituye su actualizacion.

### Segunda fase: operatorias, libros y ejercicios

Instalar tambien `database\002-Contabilidad.sql` despues de `001`, con respaldo. Agrega documentos contables inmutables,
usuario/fecha de aprobacion en su contenido persistido y clave de reintento por empresa.
Se reutilizan los permisos `ContabilidadRegistracion/Agregar` para aprobar y preparar; `ContabilidadDiario/Buscar` para libros.

**TransferenciaFondos:** lee la transferencia y sus dos movimientos reales de `EspeciesCtaCte`. Exige cotizaciones historicas
positivas, cajas distintas de la misma empresa y movimientos completos; rechaza diferencias de cambio/redondeo.
No toma cotizaciones actuales. Configurar reglas `MediosPago / Total`, con filtro **Caja**: destino al Debe, origen al Haber;
resolver cuenta fija o rol con dimension Caja/Especie. `Importe` conserva signo de entrada/salida; `Total` es positivo en cada caja.
Las transferencias interempresa requieren documentos complementarios de tipo Ajuste en cada empresa y criterio contable explicito.

**Complementarios y ejercicios:** costos de ventas y movimientos de stock llevan producto y **costo total local documentado**
(no costo unitario). Sueldos, devengamientos y ajustes llevan codigos de concepto definidos por la empresa,
importe con signo, referencia y respaldo obligatorio. Se puede resolver por Producto, Categoria, Personal, Concepto o Empresa.
Para conceptos distintos (haberes, aportes, retenciones, etc.), usar el filtro Concepto en las reglas.
El respaldo es una referencia textual, no un adjunto ni una validacion automatica de su autenticidad.
La aprobacion guarda el origen pero **no genera asientos**; luego buscarlo en Simular y registrar.
Estos documentos no mueven stock fisico, no liquidan haberes, no enlazan automaticamente costos con facturas y no sustituyen
los adaptadores historicos faltantes. La captura opcional de costo de ventas nuevas se describe en la tercera fase.
Ante un resultado incierto, reintentar sin editar conserva la misma clave. Editar los datos inicia otro documento;
no hay deduplicacion por texto del respaldo. Verificar los documentos antes de aprobar otra vez.

**Mayor y sumas y saldos:** consultas por empresa, moneda y periodo (hasta un año), incluyendo asientos manuales y generados,
sin anulados ni bajas. El saldo anterior del libro incluye toda la historia previa al periodo. El mayor muestra saldo acumulado
y exige reducir el periodo si supera 2000 movimientos; no trunca silenciosamente.

**Cierre:** preparar desde el ultimo dia de un ejercicio abierto. Antes, efectuar los ajustes y la refundicion de resultados
que defina el contador, mediante documentos Ajuste; no se infieren cuentas patrimoniales ni de resultados.
Para la plantilla usar origen **Saldos**, magnitudes **SaldoDeudor** al Haber / **SaldoAcreedor** al Debe,
rol `Saldo` y prioridad **CuentaOrigen** (resuelve directamente la cuenta historica, sin asignaciones).
La simulacion y registracion comprueban el traslado exacto, sin duplicar saldos por N plantillas.
La registracion guarda el cierre y marca Cerrado en la misma transaccion; el maestro impide reabrir o alterar ese periodo.
Preparar o simular no cierra. Las correcciones posteriores deben realizarse en un ejercicio abierto; no hay reapertura automatica.

**Apertura:** origen cerrado, fecha del primer dia del nuevo ejercicio abierto, mismas reglas de Saldos con lados inversos.
Usa los movimientos del ejercicio de origen, incluida su apertura, sin arrastrar de nuevo periodos anteriores y excluyendo su
asiento de cierre. Cada ejercicio debe tener su apertura correcta; la primera debe cargarse explicitamente si se empieza
con historia externa. Bloquea monedas distintas dentro del ejercicio hasta realizar conversiones contables explicitas.
Cada ejercicio de origen admite una apertura y un cierre registrados; no se recontabilizan tras revertir.
Si los saldos cambian despues de preparar, exige preparar un documento nuevo.

**WinForms:** desde Plan de cuentas, boton **Contabilidad parametrizable**, se abre `frmContabilidad` del nuevo UI.
Incluye editor tipado de configuracion/colecciones y prioridades ordenables, revision/registro, documentos complementarios,
preparacion de apertura/cierre, mayor/saldos/diario y reversion. Se aplican los mismos permisos y el mismo BL.
El editor de escritorio utiliza IDs para cuentas, conceptos, ejercicios y documentos originales; dispone de consulta de cuentas
con ID/codigo/nombre y de documentos complementarios. La web conserva los selectores descriptivos.
Se compilo con las dependencias nativas precompiladas; falta la prueba interactiva con SQL en una copia de SIGNET.

### Tercera fase: operacion contable y controles

Requiere **`database\003-ContabilidadProductiva.sql`** despues de 001 y 002. Instalar en copia primero.
El script incluye `GO`; ejecutarlo en una sola conexion, deteniendo la ejecucion ante el primer error
(por ejemplo `sqlcmd -b -S ".\INSTANCIA" -E -d "COPIA_SIGNET" -i "database\003-ContabilidadProductiva.sql"`).
La migracion completa mantiene una transaccion entre lotes y no activa ninguna empresa ni politica.
Distribuir tambien los BL/UI actualizados a los puestos WinForms; no mezclar versiones para el doble control.

La web y `frmContabilidad` comparten estas funciones:

| Funcion | Comportamiento |
|---|---|
| Bandeja y aprobaciones | Pendientes, propuestas, errores e indicador de anulados contabilizados. Descubrimiento manual por periodo y sucursal, maximo 500 documentos; seleccion de 1 a 50, simulacion y registro transaccional completo. |
| Automatizacion | Manual / Propuesto / Automatico por empresa y operatoria. Venta, compra, cobranza, pago, transferencia y costo de venta automatico (enum 13, distinto de los costos complementarios). Control de version, actor autorizado y vigencia sin retroactividad. |
| Costos capturados | Snapshot de cantidad de venta/stock, costo unitario estandar vigente del producto, moneda y cotizacion al confirmar. Costo total local por detalle, inmutable; un cambio posterior de producto, cantidad o detalle invalida la revision. |
| Periodos y auditoria | Bloqueo mensual de cabecera/detalle en SQL y BL, aprobacion firmada por otro usuario, reapertura mensual excepcional con motivo y permiso especifico. No reabre ejercicios cerrados. |
| Conciliacion e informes | Gestion contra origen registrado y balance real de los asientos; cajas/bancos contra cuenta vinculada; balance clasificado y sumas/saldos. Exportacion PDF y XLSX compartida DevExpress, sin ejecutar formulas tomadas de textos. |

**Costeo:** se adopta costo **estandar vigente del producto al confirmar el comprobante**, por unidad de venta,
no FIFO, promedio de compras, costo real de entrega ni costo guardado al preparar el borrador.
Moneda/cotizacion ausentes producen un error persistido; no se inventa un costo cero ni se convierten documentos antiguos
con valores actuales. En confirmaciones parciales se captura el comprobante consolidado al terminar: no se genera costo por cada entrega.
Si el criterio contable requiere costear cada entrega, otra unidad o una factura antigua, usar una valuacion complementaria
con respaldo; no habilitar el costo automatico para ese circuito. Stock y sueldos siguen utilizando sus documentos complementarios.
Las plantillas de costo automatico requieren tipo de comprobante explicito, igual que Venta/Compra;
configurar por separado facturas y notas de credito, con Invertir cuando corresponda.

**Doble control:** con 003 los documentos complementarios necesitan aprobacion independiente de su firma, aunque el worker
este apagado. La politica `DobleControl` extiende esa exigencia a los otros registros manuales. Cuando esta activa,
Asientos no permite editar/agregar/eliminar directamente: preparar Ajuste con respaldo y aprobarlo en Bandeja.
Cambiar el origen, las cuentas o las plantillas exige nueva simulacion/aprobacion.
La autorizacion automatica es una politica previa auditada, no una aprobacion humana por cada comprobante;
el actor automatico debe tener permiso y ser distinto del responsable del origen, incluso si es administrador.
Las anulaciones posteriores **no generan reversiones automaticas**: quedan observables y el contador revierte el lote en Diario.

Los nuevos permisos del modulo Gestion son `ContabilidadBandeja` (Ingresar/Buscar/Agregar),
`ContabilidadAprobacion` (Ingresar/Modificar), `ContabilidadAutomatizacion` (Ingresar/Buscar/Modificar),
`ContabilidadPeriodos` (Ingresar/Buscar/Modificar/operacion Reabrir) y `ContabilidadConciliacion` (Ingresar/Buscar/Imprimir).
Asignarlos explicitamente por grupo. No se conceden al migrar; el sidebar conserva el filtro por Ingresar.
Bandeja, descubrimiento, reintento y conciliacion documental/cajas se restringen a las sucursales habilitadas.
Balance, saldos, clasificacion y auditoria son controles de **empresa completa**, igual que los libros anteriores:
no conceder sus permisos a usuarios que solo deban conocer una sucursal.

**Worker:** en `Signet:ContabilidadWorker`, `Habilitado` permanece false y `ConexionesVariables` vacia.
Para habilitarlo en el servidor probado, configurar nombres de variables de entorno con cadenas SQL de las bases autorizadas;
no guardar cadenas ni credenciales en el codigo/JSON. Ver INSTALACION A.7c.
La cola se escribe en la transaccion que confirma el origen, incluso desde WinForms. No requiere la web encendida;
el procesamiento si requiere el worker web o la accion explicita Procesar cola ahora.
Reintentos exponenciales desde 30 segundos, maximo una hora y 8 intentos; luego intervencion desde Bandeja.
Propuesto guarda revision sin registrar; Automatico registra idempotentemente. Los errores quedan visibles y se registran fallos
del servicio sin publicar cadenas de conexion. Las transferencias incompletas esperan/reintentan, sin inventar movimientos.

Clasificar Activo/Pasivo/Patrimonio/Ingreso/Gasto y rubro antes de usar el balance; cuentas no clasificadas permanecen visibles.
Cada caja requiere su propia cuenta. Saldos en otra moneda quedan **no comparables**, sin cotizacion actual inventada.
Validar moneda/unidad y saldos iniciales con el contador. Los informes son gerenciales; no sustituyen balances legales,
ajuste por inflacion, conciliacion extracto por extracto ni presentaciones fiscales.

Validacion local: motor/API, navegador con API simulada, exportaciones PDF/XLSX reales y compilacion WinForms.
**Bloqueo pendiente de habilitacion:** no se pudo ejecutar SQL aqui por falta de SQL Server/LocalDB, ni probar WinForms
interactivamente con una copia. El harness SQL minimo comprueba infraestructura, no la integracion completa del BL contra SIGNET.
Antes de produccion, ejecutar las migraciones y probar confirmacion web/WinForms, worker, concurrencia, permisos,
reintentos, aprobaciones y cierres en una copia de la base real. No activar automatico antes de aprobar esas pruebas.

**Pendiente de integracion:** probar las migraciones y la registracion completa en una copia de la base real; extender
captura historica y adaptadores operativos de costos/stock/sueldos. No se activaron hooks automaticos
al confirmar operaciones. Tampoco se incluyen libros legales, ajustes fiscales/inflacion ni balance legal.

## Portal de vendedores (celular)

Acceso dentro de la misma web: **`/#/vendedores`**, o **Portal de vendedores** en el menu.
Usa el mismo login y backend, sin instalar aplicaciones. Requiere conexion y HTTPS para acceso externo.
Son pantallas nuevas adaptadas al tacto; no se modifican las grillas administrativas.

- **Lista de precios**: seleccionar cliente y buscar producto por nombre/codigo. Usa la lista del cliente mediante
  `ComprobantesVentasDetalleManager`; muestra moneda, precio unitario sin IVA, alicuota y descuento orientativo.
- **Cuenta corriente**: seleccionar tipo de entidad, entidad, moneda y periodo (hasta un año).
  Muestra saldo anterior, movimientos y saldo al cierre; permite abrir el comprobante con los permisos habituales.
- **Nueva venta**: cliente, productos y cantidades, con revision previa. Las opciones unicas se completan;
  sucursal/comprobante/talonario se eligen si hay varias alternativas. Centro de costo, vendedor, forma de pago
  y observaciones estan en "Mas datos". Se pide cantidad de stock cuando lo requiere la configuracion.
  Los precios, descuentos, IVA e impuestos se calculan en el servidor, sin usar la IA ni necesitar su clave.
- **Guardar pendiente de confirmacion** llama a `ComprobantesVentasManager.Save()` y deja `FechaLiquidacion` vacia.
  Administracion la encuentra en **Comprobantes de Ventas** y la confirma con la operacion existente.
  No se confirma, presenta en AFIP ni cobra desde este portal. El guardado asigna numero mediante el talonario original.

Los permisos se validan en cada endpoint: Productos (Gestion: Ingresar/Buscar), EntidadesCtaCte
(Tesoreria: Ingresar/Buscar) y ComprobantesVentas (Gestion y Tesoreria: Ingresar/Agregar, siguiendo los controles existentes).
Se reutilizan las entidades habilitadas por `Sistema.ObtenerEntidades`, sucursales, centros, depositos y puntos de venta asignados.
No se agrega una relacion nueva "cliente exclusivo del vendedor": el alcance es el configurado actualmente en SIGNET.
La seleccion de vendedor usa el catalogo existente; no se infiere un vendedor a partir del usuario.

La revision vence a los 20 minutos y al crear otra en la misma sesion. Antes de guardar se recalculan precios e impuestos:
si cambiaron, se pide revisar nuevamente. El ticket evita guardar dos veces por doble toque o reintento en esa sesion
mientras el servidor conserva el ticket. No es una garantia de idempotencia entre reinicios o multiples servidores.
Si el resultado de un guardado es incierto, verificar el comprobante en administracion antes de cargarlo otra vez.
No hay trabajo sin conexion ni sincronizacion de borradores.

Pruebas: `dotnet build tests\Vendedores\Vendedores.csproj`, `tests\Vendedores\bin\Debug\net48\Vendedores.exe`
y `node tests\Vendedores\browser.mjs` (Edge). La prueba de navegador simula las respuestas API; no guarda datos reales.

## Pantalla de ingreso

Panel izquierdo con una imagen y formulario a la derecha. Se configura en `appsettings.json` → `Signet:Login`:
`Imagen` (un archivo svg/png/jpg/webp o una **carpeta** con varias imágenes: en cada ingreso se elige una al azar; ruta absoluta o relativa a la carpeta de la app; por defecto `Personalizacion\Login`, que trae 5 de distintos estilos), `Titulo`, `Mensaje`, `Color` (acento `#rrggbb`) y `Pie`. Para sumar o quitar imágenes alcanza con copiar o borrar archivos en esa carpeta (sin reiniciar). `Publicar.ps1` no pisa `Personalizacion` en una actualización.

## Pantalla principal (azulejos)

Réplica del `TileControlPrincipal` de `frmMain`: los 25 accesos originales (mismos Id, textos, grupos, tamaños y colores) se muestran en el inicio y se filtran por permiso de ingreso y por los parámetros `Menu_*` deshabilitados (`Parametro.ObtenerParamterosMenuPrincipalDeshabilitados`).

El clic derecho sobre un azulejo (o el botón ⋮ en modo personalizar, que se activa con la ruedita **⚙**) abre el mismo menú contextual del escritorio:

- tamaño: Pequeño (1×1), Mediano (2×2), Largo (4×2) o Grande (4×4);
- mover a otro grupo o a un grupo nuevo;
- Color 1, Color 2 (degradado) y color de fuente;
- eliminar (ocultar).

En modo Personalizar, además:

- los azulejos se arrastran para cambiarlos de grupo o de orden; soltarlos en "Soltar aquí para crear un grupo nuevo" crea un grupo;
- cada grupo permite editar el texto y el color de su título; también hay un color general que se aplica a todos los títulos;
- se puede mostrar u ocultar los títulos, cambiar el color de fondo, agregar accesos ocultos y restablecer el diseño original.

Persistencia:

- Visibilidad, colores de azulejo, color de fondo y mostrar títulos: BL original `TilePrincipal` (tablas `SeguridadUsuariosConfiguracion` / `SeguridadUsuarios`). Endpoints `PUT /api/inicio/tiles/{id}` y `PUT /api/inicio/preferencias`. En el login de desarrollo (1/1) no se graba en la base, igual que `GuardarConfiguracion=0` del escritorio, y queda en el `localStorage` del navegador.
- Diseño (grupo, orden y tamaño de cada azulejo, texto y color de los títulos de grupos): `PUT /api/inicio/layout`, guardado en `App_Data\inicio\{base}\{idUsuario}.json` (`desarrollo.json` para el login 1/1). El escritorio guarda su diseño como XML propietario de DevExpress en `SeguridadUsuarios.TileConfig`; escribir otro formato ahí rompería `RestoreLayoutFromStream` del escritorio, por eso la web no lo modifica y ambos diseños son independientes. Incluir `App_Data` en los backups del servidor.
- No se replica la imagen de fondo.

`GET /api/inicio` devuelve todo combinado. "Restablecer diseño" (`DELETE /api/inicio`) vuelve todo al original: diseño, colores, accesos ocultos, fondo y títulos (en la base borra la configuración de `SeguridadUsuariosConfiguracion` del usuario y `BackColor`/`TituloTile`, lo que también afecta al escritorio, igual que los demás cambios de colores y visibilidad).

## Asistente de datos (IA)
Botón flotante ✨ (abajo a la derecha) que abre un chat. El usuario pregunta en lenguaje natural ("dame los 5 productos más vendidos el último mes") y la IA arma y ejecuta consultas SQL contra la base de la empresa de la sesión, mostrando la respuesta, la tabla de datos (exportable a CSV) y el SQL usado.

**Mismo código que el escritorio:** la lógica está en el proyecto `VENET_IA\VENET_IA_BL` de `SIGNET.sln` (la web lo compila como `shared\VENET_IA_BL.Web`). En el escritorio el menú **Asistente IA** abre la pantalla nativa `frmAsistenteIA` (`VENET_IA_UI`). Web y escritorio comparten configuración, permisos y consumo.

**Cómo funciona:** el modelo no tiene acceso directo a la base. Puede pedir 3 herramientas: `listar_tablas`, `describir_tablas` (columnas y relaciones) y `ejecutar_consulta`. Cada consulta pasa por `AsistenteIASqlGuard` (sólo un `SELECT`/`WITH`; prohíbe `INSERT/UPDATE/DELETE/EXEC/INTO`, tablas de sistema y tablas excluidas) y se ejecuta dentro de una transacción que siempre se revierte, con tope de filas (500 al usuario, 50 al modelo), 30 s por consulta, 8 pasos y 60.000 tokens por pregunta.

**Configurar (una vez por base):** en **Configuración › Parámetros** (módulo Sistema). Los parámetros se crean solos la primera vez que se abre el asistente o la pantalla de parámetros.

| Parámetro | Default | Descripción |
|---|---|---|
| `IA_ApiKey` | `SinConfigurar` | Clave de API. Gratis en <https://aistudio.google.com/apikey> (Google Gemini). |
| `IA_LimiteTokensMes` | `1000000` | Tope mensual de tokens de la base; al superarlo responde "límite alcanzado" hasta el mes siguiente. `0` = sin tope. Con `gemini-2.5-flash`, 1.000.000 de tokens cuestan menos de 1 USD. |
| `IA_ConsumoTokensMes` | `AAAA-MM\|0` | Consumo del mes (lo actualiza el sistema; se reinicia solo al cambiar de mes). |
| `IA_Url` / `IA_Modelo` | Gemini / `gemini-2.5-flash` | Cualquier API compatible con OpenAI (OpenAI, Azure, Groq, Ollama local...). |
| `IA_TablasExcluidas` | `-` | Tablas que la IA no puede ver, separadas por coma (admite `*`, ej. `Sueldos*`). Siempre se excluyen `Seguridad*`, `Parametros` y tablas con `Password`. |
| `IA_Contexto` | `-` | Texto libre con aclaraciones del negocio que mejoran las respuestas. |
| `IA_ConexionSoloLectura` | `-` | **Recomendado:** cadena de conexión con un usuario SQL `db_datareader`; así la IA nunca puede modificar datos aunque fallara la validación. `-` = usa la conexión del usuario. |
| `Menu_Sistema_AsistenteIA` | `True` | `False` oculta el asistente (web y escritorio). |

`-` significa "vacío". Requiere SQL Server 2012 o superior.

**Permisos:** como cualquier menú, por grupo en **Seguridad › Grupos**: módulo *Sistema*, objeto **AsistenteIA**, permiso **Ingresar**. Los administradores siempre tienen acceso.

**Web:** botón flotante ✨ (abajo a la derecha). `Signet:Chat` en `appsettings.json` sólo tiene `Habilitado` (mostrar o no en la web) y `Razonamiento` opcional (`low`/`medium`/`high`). Cada pregunta hecha desde la web (usuario, SQL, tokens, error) queda en `App_Data\chat\registro-AAAA-MM.jsonl`.

**Privacidad:** en el nivel gratuito Google puede usar las preguntas y los datos enviados para mejorar sus productos. Con facturación activada (nivel pago) no los usa. Al modelo sólo se envían el esquema y hasta 50 filas de resultado por consulta.

## Mantenimiento
Si se agregan/quitan archivos en los proyectos originales, ejecutar:
```powershell
powershell -ExecutionPolicy Bypass -File tools\Sync-Sources.ps1
```
Un Manager nuevo con `Buscar(ParametrosBusquedas)` aparece automáticamente en el menú (según permisos).

## Limitaciones conocidas
- Pantallas (136): además de las CRUD con `Buscar` estático hay pantallas auxiliares detectadas por reflexión (`tipo` en el esquema): `consulta` (informes con `Buscar` de instancia: stock, movimientos, saldos de cta. cte., IVA ventas/compras, usuarios activos...), `hijo` (listas dependientes de un padre con alta/baja: asignaciones de usuarios, empresas de entidades, medidas de líneas; `POST .../hijos`), `proceso` (formulario + Save: cambio de clave, copiar producción, boleta de depósito; `POST .../procesar`) y `alta` (Transferencias). Pantallas sin Manager reutilizable por reflexión se registran a mano en `ScreenCatalog.Personalizadas.cs` (**Control de Gestión**: `ControlGestionManager.Buscar`, 8 tablas de controles). Inicio/Cierre de Turno no se publican: `InicioTurnoManager` y sus formularios están excluidos de la compilación del escritorio y el botón no tiene handler. Las pantallas auxiliares no se probaron contra datos reales (no hay base accesible).
- Detalles (renglones, impuestos, comprobantes asociados, contactos, etc.) se editan junto con la cabecera: el esquema expone `colecciones` y el editor agrega/edita/quita renglones. Al elegir producto/especie se ejecutan las reglas del Manager del renglón (`POST .../autocompletar-renglon`) y los combos dependientes de la cabecera se refrescan (`POST .../lookups-dependientes`). Los renglones sin propiedad `Borrado` no se pueden quitar. No hay base accesible desde el entorno de desarrollo, por lo que el guardado no se probó contra datos reales.
- `VENET_Gestion`: el `GestionContext.cs` original no declara `TipoCategoriasContables`; `Sync-Sources.ps1` enlaza en su lugar
  la copia `GestionContext (1).cs`, que sí lo hace (opción `Replace`).
- `Sistema.Mensaje`/`frmMensaje` invocados por el BL cortan la operación y se muestran como error (no hay diálogos Sí/No en el servidor).
- Los `XtraReport` (xrpt*) de DevExpress se reemplazaron por documentos HTML equivalentes con los mismos datos del BL (DevExpress no está en el servidor).
  Las importaciones Excel que usan OLEDB requieren el "Microsoft Access Database Engine" (ACE) en el servidor.
- `DbConexion` usa un estático: la API serializa con un lock solo el momento del login; el resto usa la conexión de cada sesión.
- En esta máquina el servidor SQL de `Setup.xml` cortó el handshake de inicio de sesión (posible TLS/red);
  la API responde 503 "No se pudo conectar con la base de datos" hasta que haya conectividad.
