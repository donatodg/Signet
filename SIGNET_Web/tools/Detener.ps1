# Detiene SIGNET Web en esta PC.
$procesos = Get-Process SIGNET_Web.Api -ErrorAction SilentlyContinue
if (-not $procesos) { Write-Host 'SIGNET Web no está en ejecución.'; return }
$procesos | ForEach-Object { Stop-Process -Id $_.Id }
Start-Sleep 1
if (Get-Process SIGNET_Web.Api -ErrorAction SilentlyContinue) { Write-Warning 'No se pudo detener (¿requiere administrador?).' } else { Write-Host 'SIGNET Web detenido.' }
