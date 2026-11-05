<#
.SYNOPSIS
  Genera el paquete de instalación de SIGNET Web (cliente React + API) listo para copiar a otra PC/servidor.

.EXAMPLE
  # Paquete nuevo en C:\publish\SIGNET_Web + ZIP para llevar a otra PC
  powershell -ExecutionPolicy Bypass -File tools\Publicar.ps1 -SetupXml C:\Signet\SIGNET\SIGNET\Setup.xml -Zip

.EXAMPLE
  # Actualizar una instalación existente (conserva appsettings.json, Setup.xml y App_Data)
  powershell -ExecutionPolicy Bypass -File tools\Publicar.ps1 -Destino D:\SIGNET_Web
#>
param(
    # Carpeta de instalación. Si ya existe se actualiza conservando la configuración y los datos.
    [string]$Destino = 'C:\publish\SIGNET_Web',
    # Setup.xml del sistema de escritorio (bases de datos). Se copia junto al ejecutable.
    [string]$SetupXml,
    # Dirección en la que escucha la aplicación (solo en instalaciones nuevas). Ej.: http://0.0.0.0:5080
    [string]$Urls = 'http://0.0.0.0:5080',
    # Genera además <Destino>.zip para copiar a otra PC.
    [switch]$Zip
)

$ErrorActionPreference = 'Stop'
$raiz = Split-Path $PSScriptRoot -Parent
$api = Join-Path $raiz 'src\SIGNET_Web.Api'
$cliente = Join-Path $raiz 'client'
$temp = Join-Path ([IO.Path]::GetTempPath()) ('SIGNET_Web_publish_' + [guid]::NewGuid().ToString('N'))

function Paso($texto) { Write-Host "`n==> $texto" -ForegroundColor Cyan }
function Ejecutar($exe, [string[]]$argumentos) {
    & $exe @argumentos
    if ($LASTEXITCODE -ne 0) { throw "Falló: $exe $($argumentos -join ' ') (código $LASTEXITCODE)" }
}

if ($SetupXml -and -not (Test-Path $SetupXml)) { throw "No existe el archivo Setup.xml indicado: $SetupXml" }
if ((Get-Process SIGNET_Web.Api -ErrorAction SilentlyContinue | Where-Object { $_.Path -and $_.Path.StartsWith($Destino, 'OrdinalIgnoreCase') })) {
    throw "SIGNET Web se está ejecutando desde $Destino. Deténgalo antes de actualizar."
}

try {
    Paso 'Compilando el cliente React'
    Push-Location $cliente
    try {
        if (-not (Test-Path 'node_modules')) { Ejecutar 'npm' @('ci', '--no-audit', '--no-fund') }
        Ejecutar 'npm' @('run', 'build')
    } finally { Pop-Location }

    Paso 'Publicando la API (.NET Framework 4.8, Release)'
    Ejecutar 'dotnet' @('publish', $api, '-c', 'Release', '-o', $temp, '--nologo', '-v', 'q')
    if (-not (Test-Path (Join-Path $temp 'wwwroot\index.html'))) { throw 'El paquete no contiene wwwroot\index.html.' }

    $nueva = -not (Test-Path (Join-Path $Destino 'SIGNET_Web.Api.exe'))
    Paso ($(if ($nueva) { "Instalando en $Destino" } else { "Actualizando $Destino (se conservan appsettings.json, Setup.xml y App_Data)" }))
    New-Item -ItemType Directory -Force -Path $Destino | Out-Null

    $appsettings = Join-Path $temp 'appsettings.json'
    if ($nueva) {
        $txt = Get-Content $appsettings -Raw -Encoding UTF8
        $txt = $txt -replace '"Urls"\s*:\s*"[^"]*"', ('"Urls": "' + $Urls + '"')
        $txt = $txt -replace '"SetupXmlPath"\s*:\s*"[^"]*"', '"SetupXmlPath": "Setup.xml"'
        [IO.File]::WriteAllText($appsettings, $txt, (New-Object Text.UTF8Encoding($false)))
    } else {
        # La configuración del servidor no se pisa; la nueva queda como referencia.
        Move-Item $appsettings (Join-Path $temp 'appsettings.json.nuevo') -Force
    }

    # Reemplaza binarios y sitio. wwwroot se limpia para no dejar bundles viejos.
    if (Test-Path (Join-Path $Destino 'wwwroot')) { Remove-Item (Join-Path $Destino 'wwwroot') -Recurse -Force }
    # Personalizacion (imagen de login) solo se copia si no existe, para no pisar la del cliente.
    $excluir = @('App_Data')
    if (Test-Path (Join-Path $Destino 'Personalizacion')) { $excluir += 'Personalizacion' }
    & robocopy $temp $Destino /E /NFL /NDL /NJH /NJS /NP /XD $excluir | Out-Null
    if ($LASTEXITCODE -ge 8) { throw "robocopy falló (código $LASTEXITCODE)" }

    New-Item -ItemType Directory -Force -Path (Join-Path $Destino 'App_Data') | Out-Null
    if ($SetupXml) { Copy-Item $SetupXml (Join-Path $Destino 'Setup.xml') -Force }
    if (-not (Test-Path (Join-Path $Destino 'Setup.xml'))) {
        Write-Warning "Falta Setup.xml en $Destino. Cópielo desde la instalación del escritorio o configure Signet:Bases en appsettings.json."
    }

    if ($Zip) {
        Paso 'Generando ZIP'
        $zipFile = $Destino.TrimEnd('\') + '.zip'
        if (Test-Path $zipFile) { Remove-Item $zipFile -Force }
        Compress-Archive -Path (Join-Path $Destino '*') -DestinationPath $zipFile
        Write-Host "ZIP: $zipFile"
    }

    Paso 'Listo'
    Write-Host "Ejecutable: $(Join-Path $Destino 'SIGNET_Web.Api.exe')"
    Write-Host 'Ver INSTALACION.md para los pasos en la PC destino.'
}
finally {
    if (Test-Path $temp) { Remove-Item $temp -Recurse -Force -ErrorAction SilentlyContinue }
}
