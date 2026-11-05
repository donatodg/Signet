# Instalación de SIGNET Web en otra PC

## Compras desde foto/PDF (web y WinForms)

Esta función se abre desde **Comprobantes de compras → Compra desde foto / PDF** en ambas interfaces.
Requiere permisos **Ingresar y Agregar** sobre `Gestion / ComprobantesCompras`, además de una sucursal asignada.
Cada usuario puede retomar solamente sus propias cargas, dentro de las sucursales que tenga habilitadas.

### Activación

1. Hacer respaldo y probar primero en una **copia** de la base de gestión. Ejecutar manualmente
   `database\004-ComprasDocumentos.sql` sobre esa base con SQL Server Management Studio.
   No se ejecuta al arrancar la web ni crea compras por sí mismo. Requiere SQL Server 2016 SP1 o posterior.
2. Instalar en la misma PC que ejecuta la API un servidor de **visión multimodal local** compatible con
   `POST /v1/chat/completions`, imágenes `image_url` y salida JSON. Por ejemplo, Ollama con un modelo de visión
   como `qwen2.5vl:7b`, descargado por el administrador. No alcanza con un modelo que solo admite texto.
   Dimensionar RAM/GPU según el modelo y probar la calidad con facturas representativas.
   **No se instala ni se descarga un modelo automáticamente.**
3. Configurar las variables en el proceso/cuenta que ejecuta SIGNET:

   ```powershell
   $env:SIGNET_COMPRAS_VISION_URL = 'http://127.0.0.1:11434/v1/chat/completions'
   $env:SIGNET_COMPRAS_VISION_MODELO = 'qwen2.5vl:7b'
   # Solo si el servidor LOCAL exige autenticacion:
   # $env:SIGNET_COMPRAS_VISION_CLAVE = '<clave del servidor local>'
   # Ejecutar la API desde esta misma consola para heredar las variables:
   .\SIGNET_Web.Api.exe
   ```

   La URL predeterminada es la del ejemplo; el modelo es obligatorio. Solo se admiten direcciones **loopback**,
   sin redirecciones ni proxy: no se aceptan endpoints en Internet. Un modelo local no debe usar a su vez un
   servicio remoto. Los celulares envían el archivo a SIGNET, no directamente al lector.
   Para una tarea programada/servicio configurar las variables para su cuenta o a nivel de máquina y reiniciar
   el proceso: las variables de una consola no se aplican a un proceso que ya estaba iniciado.
4. **WinForms utiliza el mismo BL y la misma migración**, pero el lector debe estar instalado/configurado en
   **cada PC donde se ejecute el escritorio**. En este primer alcance no se envían documentos desde WinForms
   a otra máquina. Abrir el ejecutable habitual desde el entorno que tenga esas variables.
5. Publicar/copiar los binarios nuevos completos. Se agregó `Docnet.Core` para rasterizar PDF localmente:
   incluir `Docnet.Core.dll` y `pdfium.dll`. El paquete habitual es para **Windows x64**; no mezclar una DLL
   PDF x64 con un ejecutable x86. Para una compilación x86 usar `DocnetRuntime=win-x86` y el ejecutable x86.
   Si falta el runtime nativo, instalar Microsoft Visual C++ Redistributable 2015–2022 de la misma arquitectura.
   El BL de escritorio está firmado: se agregó `StrongNamer` como dependencia **solo de compilación**
   para generar una copia firmada de `Docnet.Core` en `SignedAssemblies` dentro de `obj`, sin modificar el paquete
   NuGet original. Distribuir la DLL resultante junto al BL nativo; no reemplazarla por la DLL sin firma
   del caché NuGet ni mezclar DLL del paquete web con las del escritorio.

### Uso y controles

Seleccionar sucursal y hasta **6 archivos JPEG/PNG/PDF, 6 páginas en total y 12 MB** por comprobante.
También se permite tomar fotos desde el navegador del celular. HEIC, TIFF y PDF con contraseña no están
soportados: convertirlos a JPEG/PNG o PDF sin clave. Máximo 30 megapíxeles por imagen.
Primero **Guardar originales**, luego **Leer documento**. Las páginas se muestran junto a la propuesta;
el original se puede descargar. La lectura tiene un límite de tres minutos y puede reintentarse.

Revisar CUIT/proveedor, factura o nota de crédito, letra/numeración, fechas, moneda/cotización, depósito,
centro de costo, forma de pago, todos los productos y cantidades. Los precios son **netos sin IVA**.
El total impreso de cada renglón se marca **Neto** o **ConIva**: en una factura A suele ser neto.
Se conserva ese importe impreso y se calcula aparte el total con IVA que utiliza el BL.
No se crean proveedores ni productos automáticamente. Un campo vacío significa desconocido, no cero:
completar explícitamente IVA, descuentos e impuestos ausentes después de mirar el original.
Los productos con unidad de stock requieren su cantidad de stock/conversión revisada.

Se comparan ítems, IVA, neto y total con el recálculo del BL (tolerancia $0,02); se comprueba CUIT y
duplicidad por proveedor/tipo/letra/punto/número, también con ceros iniciales.
El modelo heredado admite punto de venta de hasta 9999 y número de hasta ocho dígitos; un punto impreso
como `00001` se guarda como `0001`, sin perder su valor. No se truncan puntos de venta mayores.
El modelo EF heredado persiste decimales con escala dos: la importación rechaza precios, cantidades,
porcentajes, cotizaciones o impuestos que requieran más decimales, en lugar de truncarlos silenciosamente.
Adaptar ese modelo y validar el esquema SQL sería una ampliación posterior; no redondear para forzar una factura que deje de coincidir.
La moneda extranjera con
percepciones/impuestos/descuento de cabecera debe cargarse por el circuito habitual: no se infiere su
conversión. La selección correcta de factura/nota de crédito y moneda sigue siendo responsabilidad del revisor.
No se valida autenticidad fiscal, CAE ni QR.

**Guardar correcciones** conserva un borrador incompleto sin crear una compra. **Validar borrador** exige
revisión humana y devuelve una firma de los datos; cualquier edición obliga a revisar y validar otra vez.
Es un hash de revisión, no una firma digital fiscal.
**Crear compra pendiente** reutiliza `ComprobantesComprasManager.Save()` en una transacción con el vínculo,
las equivalencias elegidas y la auditoría. Nunca invoca `Confirmar()`: no paga, no mueve stock, no registra
cuenta corriente ni asientos. Continuar desde el circuito normal de Comprobantes de compras para confirmar.

La opción **Recordar código del proveedor** guarda la equivalencia al crear la compra. Si ya existía para
ese proveedor/código, la selección revisada la reemplaza y se auditan el valor anterior y el nuevo.
Los originales y auditorías son de solo agregado en SQL; cada relectura registra la lectura/revisión anterior.
Las correcciones actuales se reemplazan al releer, previa confirmación. Se conserva el modelo utilizado.

### Privacidad, respaldo y aceptación

Las imágenes/PDF originales se guardan en la base como `varbinary(max)`, junto con SHA-256, propietario,
sucursal y auditoría. **Aumentan el tamaño de la base y de sus backups.** Restringir acceso SQL, cifrar
transporte/backups y definir retención con el responsable contable. No hay eliminación automática: los
triggers impiden editar/borrar originales y auditorías. No exponer el puerto del lector a la red;
para celulares solo se necesita el acceso HTTPS a SIGNET.

Antes de habilitar en producción, probar en copia: factura A/C y nota de crédito, multipágina, IVA mixto,
descuentos/percepciones, duplicado, corte de conexión/reintento, reapertura del borrador y confirmación
habitual, verificando que guardar pendiente no generó movimientos. La exactitud depende de la foto/modelo;
**no omitir la revisión humana**.

Validaciones de desarrollo:

```powershell
dotnet build .\tests\ComprasDocumentos\ComprasDocumentos.csproj
.\tests\ComprasDocumentos\bin\Debug\net48\ComprasDocumentos.exe
node .\tests\ComprasDocumentos\browser.mjs
# Solo en SQL LOCAL: crea y elimina una base temporal, nunca usa una existente.
.\tests\ComprasDocumentos\bin\Debug\net48\ComprasDocumentos.exe --sql '(localdb)\MSSQLLocalDB'
```

El arnés SQL prueba migración/relaciones/inmutabilidad/rollback; no reemplaza el ensayo de guardado y
confirmación del BL completo contra una copia. Las pruebas del lector usan imágenes/PDF sintéticos y
un servidor local simulado, no certifican la precisión de un modelo real.

Arnés de fuentes nativas (Developer PowerShell de Visual Studio, desde `SIGNET_Web`):

```powershell
MSBuild ..\VENET_DataEntity\VENET_DataEntity\VENET_DataEntity.csproj /t:Build /v:minimal
MSBuild .\tests\ComprasDocumentos\Native\Native.csproj /restore /v:minimal
.\tests\ComprasDocumentos\Native\bin\Debug\net48\ComprasDocumentos.Native.Tests.exe
```

Compila el formulario nuevo y los BL originales contra dependencias de escritorio, firma el ensamblado
y ejecuta las mismas pruebas de lectura/cálculo con PDF nativo x64. No sustituye compilar `SIGNET.sln`
ni probar interactivamente el formulario con una base configurada.

Hay dos escenarios. Elegí el que corresponda:

| Escenario | Para qué | Qué se copia |
|---|---|---|
| **A. Servidor / PC de uso** | Que los usuarios usen la web desde el navegador | Solo el paquete compilado (sin código fuente) |
| **B. PC de desarrollo** | Modificar y compilar el sistema | Todo el código fuente (`C:\Signet` completo) |

---

## A. Instalar en un servidor (producción)

### A.1. Requisitos de la PC destino

1. **Windows 10 (1903+) / Windows Server 2016+** con **.NET Framework 4.8**. Ya viene en Windows 10 1903+, 11 y Server 2022.
   Para verificarlo, ejecutar en PowerShell:
   ```powershell
   (Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full').Release -ge 528040
   ```
   Si da `False`, instalar el runtime de .NET Framework 4.8 desde https://dotnet.microsoft.com/download/dotnet-framework/net48.
2. **Acceso de red al SQL Server** de las bases que usa el escritorio, con los mismos servidores y puertos del `Setup.xml`.
3. **No** hace falta instalar Node.js, .NET SDK, Visual Studio ni el IDE de DevExpress.
   El paquete debe incluir los ensamblados redistribuibles licenciados de DevExpress Reporting 23.2, copiados al publicar.
4. **Reportes REPX**: copiar las plantillas a la carpeta indicada por el parametro de base `RutaOriginalesComprobantesVentas`.
   Dar permiso de lectura a la cuenta que ejecuta la API (incluidos subreportes e imagenes) e instalar las fuentes del diseno.
   `Reporte` en cada talonario indica el nombre del archivo; los remitos usan `Ventas_NombreRemito` y las listas `ListaPrecios.repx`.
   Las plantillas son XML sin scripts; ver README, "Configuracion de plantillas REPX".

### A.2. Generar el paquete (en la PC de desarrollo)

En la PC donde está el código (`C:\Signet\SIGNET_Web`), abrir PowerShell y ejecutar:

```powershell
cd C:\Signet\SIGNET_Web
powershell -ExecutionPolicy Bypass -File tools\Publicar.ps1 -SetupXml C:\Signet\SIGNET\SIGNET\Setup.xml -Zip
```

El script:

- compila el cliente React;
- publica la API en modo Release en `C:\publish\SIGNET_Web`;
- copia el `Setup.xml`;
- configura la aplicación para escuchar en `http://0.0.0.0:5080` (todas las interfaces de red);
- genera **`C:\publish\SIGNET_Web.zip`**.

Parámetros opcionales:

- `-Destino D:\otra\carpeta`
- `-Urls http://0.0.0.0:8080` (otro puerto)

> ⚠️ El ZIP contiene `Setup.xml`, que tiene las credenciales (encriptadas) de las bases. Trasladalo por un medio seguro y no lo publiques.

Si en lugar del `Setup.xml` preferís declarar las bases a mano, omití `-SetupXml` y completá `Signet:Bases` en `appsettings.json` (ver A.4).

### A.3. Copiar a la PC destino

1. Copiar `SIGNET_Web.zip` a la PC destino.
2. Clic derecho → **Propiedades** → si aparece, tildar **Desbloquear** → Aceptar. Así Windows no bloquea las DLL descargadas.
3. Descomprimir en la carpeta de instalación, por ejemplo **`C:\SIGNET_Web`**.

### A.4. Configurar `C:\SIGNET_Web\appsettings.json`

Abrirlo con el Bloc de notas. Valores principales:

| Clave | Qué es | Ejemplo |
|---|---|---|
| `Urls` | Dirección y puerto en que escucha. `0.0.0.0` = accesible desde otras PCs; `localhost` = solo esa PC | `"http://0.0.0.0:5080"` |
| `Signet:SetupXmlPath` | Ruta del `Setup.xml` (relativa a la carpeta o absoluta) | `"Setup.xml"` |
| `Signet:Bases` | Bases adicionales o en reemplazo del `Setup.xml` | ver abajo |
| `Signet:SessionMinutes` | Minutos de inactividad antes de cerrar la sesión | `480` |
| `Signet:MaxFilasBusqueda` | Tope de filas por búsqueda | `5000` |

Ejemplo de base declarada a mano:

```json
"Bases": [
  { "Name": "ERSA", "DataSource": "SERVIDORSQL,1433", "DataBase": "ERSA", "User": "usuario", "Pass": "clave", "Provider": "System.Data.SqlClient" }
]
```

> El login de desarrollo (usuario `1` / clave `1`) **no funciona** en el paquete publicado: siempre se valida contra la base.

### A.5. Probar que arranca

En PowerShell:

```powershell
cd C:\SIGNET_Web
.\SIGNET_Web.Api.exe
```

Debe mostrar `Now listening on: http://0.0.0.0:5080`. Abrir **http://localhost:5080** en el navegador de esa PC: debe aparecer el login con las bases en el combo. Ingresar con un usuario real del sistema.

Si no aparecen bases, falta el `Setup.xml` o `Signet:Bases`. Si el login responde *"No se pudo conectar con la base de datos"*, revisar la conectividad con el SQL Server (firewall, puerto, instancia).

Cerrar con **Ctrl+C**.

### A.6. Abrir el puerto 5080 para PCs y celulares

Estos pasos se hacen en **la PC donde se aloja la web**. El celular debe estar conectado al mismo Wi-Fi/red local
que esa PC (la PC puede estar conectada por cable). No usar datos móviles ni una red Wi-Fi de invitados con aislamiento.

1. Verificar en `appsettings.json` que `Urls` sea **`http://0.0.0.0:5080`**, no `http://localhost:5080`.
   Reiniciar SIGNET Web si se cambia la configuración y dejarlo ejecutándose.
   Si se configuró `Kestrel:Endpoints`, ese apartado tiene prioridad: debe incluir el endpoint HTTP del paso A.8
   para escuchar en 5080.
2. Abrir Inicio, buscar **PowerShell** y elegir **Ejecutar como administrador**. Crear la regla de entrada:

```powershell
New-NetFirewallRule -Name "SIGNET-Web-5080" -DisplayName "SIGNET Web TCP 5080 (red local)" -Direction Inbound -Protocol TCP -LocalPort 5080 -Action Allow -Profile Private,Domain -RemoteAddress LocalSubnet
```

   La regla permite conexiones desde la subred local en perfiles **Privado** o **Dominio**.
   En Configuración de Windows > Red e Internet > propiedades de la conexión, verificar el perfil.
   Marcarlo como **Privado** únicamente si es una red de confianza; en redes administradas consultar al responsable.
   No es necesario desactivar el firewall ni abrir el puerto de SQL Server.
   Si Windows indica que la regla `SIGNET-Web-5080` ya existe, no hace falta volver a crearla.
3. En esa misma PC ejecutar:

```powershell
ipconfig
```

   Buscar la **Dirección IPv4** del adaptador Ethernet o Wi-Fi conectado a la red, por ejemplo `192.168.1.50`.
   No usar `0.0.0.0`, direcciones de adaptadores virtuales ni `localhost` en el celular:
   `localhost` apuntaría al propio teléfono.
4. Abrir Safari o Chrome en el celular e ingresar, reemplazando la IP por la de esa PC:

   **Web completa:** `http://192.168.1.50:5080`

   **Portal de vendedores:** `http://192.168.1.50:5080/#/vendedores`

El portal está dentro de la misma instalación y usa el mismo login.
Conviene reservar la IP de la PC en el router para que el enlace no cambie.

**Si no conecta:** comprobar primero `http://localhost:5080` en el servidor; luego comprobar desde otra PC de la misma red:

```powershell
Test-NetConnection -ComputerName 192.168.1.50 -Port 5080
```

`TcpTestSucceeded: True` confirma que el puerto es accesible desde esa PC. Si devuelve `False`, revisar que SIGNET Web
esté ejecutándose, la IP sea correcta, el perfil/regla del firewall y que el router no aísle los dispositivos.
Si hay un antivirus con firewall propio, también debe permitir TCP 5080 según las políticas de la red.
En redes con varias subredes/VLAN, la regla `LocalSubnet` puede no alcanzar: el responsable de red debe autorizar
las subredes necesarias y su comunicación, sin abrir el acceso indiscriminadamente.

**Acceso desde fuera de la red:** esta regla no habilita Internet. No redirigir el puerto HTTP 5080 en el router;
usar una VPN o publicar mediante HTTPS correctamente configurado (paso A.8). HTTP no cifra credenciales ni datos.
Precios, cuenta corriente y alta de ventas requieren los permisos detallados en README, "Portal de vendedores".
Las ventas se guardan pendientes de confirmacion por administracion; el portal requiere conexion, no trabaja offline.

### A.7. Que arranque solo con Windows

Opción recomendada: **tarea programada**, que corre aunque no haya nadie logueado y se reinicia si se cae. En PowerShell **como administrador**:

```powershell
$dir = 'C:\SIGNET_Web'
$accion   = New-ScheduledTaskAction -Execute "$dir\SIGNET_Web.Api.exe" -WorkingDirectory $dir
$inicio   = New-ScheduledTaskTrigger -AtStartup
$opciones = New-ScheduledTaskSettingsSet -ExecutionTimeLimit ([TimeSpan]::Zero) -RestartCount 999 `
            -RestartInterval (New-TimeSpan -Minutes 1) -AllowStartIfOnBatteries -DontStopIfGoingOnBatteries -StartWhenAvailable
$cuenta   = New-ScheduledTaskPrincipal -UserId 'SYSTEM' -LogonType ServiceAccount -RunLevel Highest
Register-ScheduledTask -TaskName 'SIGNET Web' -Action $accion -Trigger $inicio -Settings $opciones -Principal $cuenta
Start-ScheduledTask -TaskName 'SIGNET Web'
```

- Para detenerla: `Stop-ScheduledTask -TaskName 'SIGNET Web'`.
- Para quitarla: `Unregister-ScheduledTask -TaskName 'SIGNET Web' -Confirm:$false`.
- La cuenta `SYSTEM` alcanza cuando las bases usan usuario y clave de SQL, que es como las define el `Setup.xml`. Si usan **seguridad integrada de Windows**, reemplazar `-UserId 'SYSTEM' -LogonType ServiceAccount` por una cuenta de dominio con acceso al SQL (`-UserId 'DOMINIO\usuario' -LogonType Password`). Al registrar la tarea, Windows pide la clave de esa cuenta.

### A.7b. Asistente de datos (IA, opcional)
Necesita salida a Internet hacia `generativelanguage.googleapis.com` (desde el servidor web y desde las PCs que usen el escritorio). La clave y el tope mensual se cargan en **Configuración › Parámetros** (`IA_ApiKey`, `IA_LimiteTokensMes`), son los mismos para la web y el escritorio. El acceso se da por grupo en **Seguridad › Grupos** (Sistema / *AsistenteIA* / Ingresar).

Detalle de parámetros, usuario de sólo lectura y límites: ver README, sección «Asistente de datos (IA)». Para ocultarlo sólo en la web: `"Habilitado": false` en `Signet:Chat`; en ambos: parámetro `Menu_Sistema_AsistenteIA` = `False`.
### A.7c. Modulo de Contabilidad (opcional)

Antes de usar `/#/contabilidad`, realizar un respaldo y ejecutar **`database\001-Contabilidad.sql`** y luego
**`database\002-Contabilidad.sql`** y **`database\003-ContabilidadProductiva.sql`** en cada base
que vaya a utilizar el motor, desde SQL Server Management Studio con una cuenta autorizada.
Los tres scripts se incluyen en el paquete publicado; no se ejecutan automaticamente al iniciar la web.
No generan asientos de documentos existentes ni asignan permisos a grupos.

Asignar los permisos `ContabilidadConfiguracion`, `ContabilidadRegistracion` y `ContabilidadDiario`
en Seguridad (modulo Gestion), segun las funciones de cada usuario; luego volver a iniciar sesion.
Los permisos de plan de cuentas, ejercicios y asientos conservan sus nombres originales.
Abrir el ejercicio, seleccionar la moneda contable local y cargar plantillas y asignaciones de cuentas.
Validar primero las simulaciones en una **copia de la base**, con el contador, antes de registrar en produccion.
Por defecto la registracion es explicita; instalar no habilita automatico.
La segunda fase incorpora Complementarios y ejercicios y Mayor y sumas y saldos.
Preparar un cierre no cierra el ejercicio: registrar sus asientos revisados si lo hace y bloquea el periodo.
Probar primero cierre/apertura y reversiones en la copia, nunca como ensayo en la base productiva.
Ver README, "Contabilidad parametrizable", para ejemplos, controles, adaptadores disponibles y limitaciones.

**Fase operativa:** 003 contiene lotes `GO` dentro de una unica transaccion. Usar una sola conexion y
detener el script al primer error (por ejemplo `sqlcmd -b`, indicado en README).
Probarlo primero en una copia: en este entorno no hay SQL Server/LocalDB disponible para validar su ejecucion.
La instalacion agrega Bandeja, Automatizacion, Periodos/auditoria, Clasificacion/cajas y Conciliacion/PDF/XLSX.
Asignar sus permisos de Gestion por grupo (tabla de README); no se conceden automaticamente.
Actualizar tambien los BL/UI WinForms de todos los puestos.

Para habilitar el procesamiento automatico **solo despues de las pruebas en copia**:

1. Configurar las plantillas, ejercicio abierto, moneda base y cuentas; revisar simulaciones con el contador.
2. Configurar variables de entorno para la identidad que ejecuta el servicio con las cadenas SQL autorizadas,
   por ejemplo una variable llamada `SIGNET_CONTABILIDAD_COPIA`. Ingresar su valor de forma segura en la configuracion
   del servidor; nunca incluir la cadena/clave en el repositorio, en instrucciones compartidas o en logs.
   La variable debe ser visible para la cuenta de la tarea/pool, no solo para una consola interactiva.
3. En `Signet` de `appsettings.json`, configurar:
   ```json
   "ContabilidadWorker": {
     "Habilitado": true,
     "IntervaloSegundos": 30,
     "ConexionesVariables": ["SIGNET_CONTABILIDAD_COPIA"]
   }
   ```
4. En Automatizacion, autorizar la empresa y politicas. Empezar con **Propuesto** y verificar Bandeja.
   Automatico exige seleccionar usuario contable autorizado y distinto del responsable del origen;
   registra confirmaciones futuras sin aprobacion humana individual. Reiniciar el servicio solo despues de autorizarlo.
5. Probar desde web y WinForms: confirmaciones, costos faltantes, doble control, bloqueo/reapertura, reintentos,
   apagado/reinicio del worker, concurrencia y ausencia de duplicados. Verificar caja/mayor y exportaciones.

No configurar costo automatico para circuitos que necesiten costo real por entrega/FIFO/promedio o distinta unidad:
el snapshot es **costo estandar vigente al confirmar el comprobante completo**, no reconstruccion historica.
003 exige aprobacion independiente de complementarios aun sin worker; con DobleControl los ajustes manuales
se preparan como documentos respaldados, no por edicion directa de Asientos.
El bloqueo mensual tambien se controla por triggers SQL; la reapertura requiere motivo y operacion Reabrir.
El descubrimiento historico no encola automaticamente operaciones anteriores a la autorizacion.
Para detener el worker, poner `Habilitado: false` y reiniciar la web: la cola y los snapshots se conservan.

### A.8. HTTPS (recomendado)

Las claves de los usuarios viajan en el login. En una red que no sea de total confianza, usá HTTPS. Necesitás un certificado `.pfx`, emitido por la CA de la empresa o comprado, con el nombre del servidor.

1. Copiar el `.pfx` a `C:\SIGNET_Web\certificado.pfx`.
2. Agregar en `appsettings.json`, al mismo nivel que `"Urls"`:
   ```json
   "Kestrel": {
     "Endpoints": {
       "Https": { "Url": "https://0.0.0.0:443", "Certificate": { "Path": "certificado.pfx", "Password": "CLAVE-DEL-PFX" } }
     }
   },
   ```
   Cuando existe la sección `Kestrel:Endpoints`, se **ignora `Urls`**: la aplicación queda **solo en HTTPS**. Si también querés HTTP, agregá otro endpoint: `"Http": { "Url": "http://0.0.0.0:5080" }`.
3. Abrir el puerto 443 en el firewall (paso A.6 con `-LocalPort 443`) y reiniciar la tarea.
4. Restringir el acceso a la carpeta, porque `appsettings.json` contiene la clave del certificado:
   ```powershell
   icacls C:\SIGNET_Web /inheritance:r /grant:r "*S-1-5-32-544:(OI)(CI)F" "*S-1-5-18:(OI)(CI)F"
   ```
   `S-1-5-32-544` = Administradores y `S-1-5-18` = SYSTEM. Funciona en Windows en cualquier idioma. Si la tarea corre con otra cuenta, agregar también esa cuenta.

### A.9. Alternativa: publicar en IIS

Para usar IIS en lugar de la tarea programada:

1. Instalar el rol IIS y el **ASP.NET Core Hosting Bundle** (incluye el *ASP.NET Core Module*).
2. Crear un **Application Pool** con *.NET CLR version* = **No Managed Code**.
3. Crear un sitio que apunte a `C:\SIGNET_Web`. El paquete ya incluye `web.config`. Configurar el binding HTTPS con el certificado en IIS.
4. Dar a la identidad del pool permiso de **modificación** sobre `C:\SIGNET_Web\App_Data`.
5. No usar la sección `Kestrel` de A.8; IIS maneja los puertos y el certificado.

> La opción probada es la de A.5–A.8 (ejecutable + tarea programada). El hospedaje en IIS no se probó en este entorno.

### A.10. Actualizar a una versión nueva

1. Detener la aplicación: `Stop-ScheduledTask -TaskName 'SIGNET Web'`, o detener el sitio en IIS.
2. Tenés dos opciones:
   - **Misma PC del código:** ejecutar `tools\Publicar.ps1 -Destino C:\SIGNET_Web`.
   - **Otra PC:** generar el ZIP en la PC de desarrollo con `tools\Publicar.ps1 -Destino C:\publish\SIGNET_Web_nuevo -Zip`. Luego, en el servidor, reemplazar **todo excepto** `appsettings.json`, `Setup.xml`, `certificado.pfx` y la carpeta `App_Data`.
3. Iniciar: `Start-ScheduledTask -TaskName 'SIGNET Web'`.

Al actualizar, el script **conserva** `appsettings.json`, `Setup.xml` y `App_Data`. La configuración nueva queda como `appsettings.json.nuevo`, como referencia, por si hay claves nuevas.

### A.11. Backup

Incluir en el backup del servidor:

- **`C:\SIGNET_Web\App_Data`**: diseño personalizado de la pantalla principal de cada usuario;
- **`appsettings.json`**, `Setup.xml` y el certificado.

El resto de los datos está en las bases SQL, igual que en el escritorio.

### A.12. Problemas frecuentes

| Síntoma | Causa / solución |
|---|---|
| La ventana se cierra al iniciar | Ejecutarlo desde PowerShell (A.5) para ver el error. Puerto ocupado: cambiar `Urls`. |
| `Could not load file or assembly` | Falta .NET Framework 4.8, o el ZIP no se desbloqueó (A.3 paso 2). |
| No aparecen bases en el login | Falta `Setup.xml` o `Signet:Bases` en `appsettings.json`. |
| "No se pudo conectar con la base de datos" | El servidor no llega al SQL Server: firewall, puerto o nombre de instancia. |
| Desde otra PC no abre | `Urls` con `localhost` en lugar de `0.0.0.0`, o falta la regla de firewall (A.6). |
| Se ve una versión vieja tras actualizar | Recargar con **Ctrl+F5**. |

---

## B. Preparar una PC de desarrollo

El proyecto web **no copia** el código del backend: compila los `.cs` originales de `C:\Signet\VENET_*` directamente. Por eso hace falta la estructura completa de carpetas.

### B.1. Instalar

1. **.NET SDK** 8 o superior: https://dotnet.microsoft.com/download
2. **.NET Framework 4.8 Developer Pack**: https://dotnet.microsoft.com/download/dotnet-framework/net48
   Alternativa: Visual Studio 2022 con la carga *Desarrollo de escritorio de .NET*, que lo incluye.
3. **Node.js 18+ LTS**: https://nodejs.org
4. Opcional: Visual Studio 2022 o VS Code.

### B.2. Copiar el código

Copiar **toda la carpeta `C:\Signet`**, desde el repositorio o una copia, respetando la estructura. Como mínimo debe tener:

```
C:\Signet\
├─ SIGNET_Web\            (este proyecto)
├─ SIGNET\SIGNET\Setup.xml
├─ VENET_DataEntity\  VENET_Comun\  VENET_Common\
├─ VENET_General\  VENET_Seguridad\  VENET_Clientes\  VENET_Proveedores\  VENET_ProvFinancieros\
└─ VENET_Personal\  VENET_Produccion\  VENET_Tesoreria\  VENET_Gestion\
```

La ruta puede ser otra, por ejemplo `D:\Fuentes\Signet`. Lo que importa es que **`SIGNET_Web` quede dentro de la misma carpeta que los `VENET_*`**.

### B.3. Compilar y ejecutar

```powershell
cd C:\Signet\SIGNET_Web
cd client;  npm install;  npm run build;  cd ..
cd src\SIGNET_Web.Api;  dotnet run
```

- Abrir **http://localhost:5080**.
- En desarrollo se puede entrar con usuario **`1`** y clave **`1`** sin validar contra la base.
- Para trabajar en la interfaz con recarga automática, ejecutar `npm run dev` en `client` (en otra consola) y abrir **http://localhost:5173**.

### B.4. Cuando cambia el código original

Si se agregan o quitan archivos `.cs` en los proyectos `VENET_*` originales, regenerar los enlaces:

```powershell
powershell -ExecutionPolicy Bypass -File C:\Signet\SIGNET_Web\tools\Sync-Sources.ps1
```

Los cambios **dentro** de archivos existentes no requieren este paso: alcanza con volver a compilar.

Para generar un paquete de instalación nuevo, seguir el paso A.2.
