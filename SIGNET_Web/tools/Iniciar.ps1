# Inicia SIGNET Web en esta PC (modo desarrollo) en una ventana aparte y espera a que responda.
param([string]$Entorno = 'Development')

$api = Join-Path $PSScriptRoot '..\src\SIGNET_Web.Api'
$exe = Join-Path $api 'bin\Debug\net48\SIGNET_Web.Api.exe'
if (-not (Test-Path $exe)) { throw "No se encontró $exe. Compile primero con tools\Build-Api.ps1." }
if (Get-Process SIGNET_Web.Api -ErrorAction SilentlyContinue) { Write-Host 'SIGNET Web ya está en ejecución: http://localhost:5080'; return }

$env:ASPNETCORE_ENVIRONMENT = $Entorno
# Sin ventana: la salida de consola queda en App_Data\logs (se reemplaza en cada inicio).
$logs = Join-Path $api 'App_Data\logs'
New-Item -ItemType Directory -Force -Path $logs | Out-Null
Start-Process -FilePath $exe -WorkingDirectory (Resolve-Path $api) -WindowStyle Hidden `
    -RedirectStandardOutput (Join-Path $logs 'consola.log') -RedirectStandardError (Join-Path $logs 'errores.log') | Out-Null

Write-Host 'Iniciando SIGNET Web' -NoNewline
for ($i = 0; $i -lt 60; $i++) {
    Start-Sleep 1
    Write-Host '.' -NoNewline
    try { Invoke-WebRequest 'http://localhost:5080' -UseBasicParsing -TimeoutSec 2 | Out-Null; Write-Host "`nListo: http://localhost:5080"; return } catch { }
}
Write-Warning "La aplicación no respondió en 60 segundos. Revise $logs\consola.log y errores.log."
