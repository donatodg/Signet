# Compila la API serializando builds concurrentes (varios procesos compilando a la vez se pisan los obj\).
$m = New-Object System.Threading.Mutex($false, 'Global\SIGNET_Web_Build')
[void]$m.WaitOne()
try {
    Push-Location (Join-Path $PSScriptRoot '..\src\SIGNET_Web.Api')
    dotnet build -v q --nologo 2>&1 | Select-String -Pattern 'error|Compilación|Build' | Select-Object -First 60 | ForEach-Object { $_.Line }
}
finally { Pop-Location; $m.ReleaseMutex() }
