$bin = (Get-ChildItem 'C:\Signet\SIGNET_Web\src\SIGNET_Web.Api\bin' -Recurse -Filter 'VENET_Gestion_BL.dll' | Sort-Object LastWriteTime -Descending | Select-Object -First 1).DirectoryName
[AppDomain]::CurrentDomain.add_AssemblyResolve({ param($s, $e)
    $n = ($e.Name -split ',')[0]; $f = Join-Path $bin ($n + '.dll')
    if (Test-Path $f) { return [Reflection.Assembly]::LoadFrom($f) }; return $null })
$out = @()
foreach ($dll in Get-ChildItem $bin -Filter 'VENET_*_BL.dll') {
    $asm = [Reflection.Assembly]::LoadFrom($dll.FullName)
    try { $types = $asm.GetTypes() } catch [Reflection.ReflectionTypeLoadException] { $types = $_.Exception.Types | ? { $_ } }
    foreach ($t in $types | ? { $_.IsClass -and $_.IsPublic -and -not $_.IsAbstract -and -not $_.IsNested -and $_.Name -match 'Manager$' }) {
        $b = $t.GetMethods('Public,Static,Instance,DeclaredOnly') | ? { $_.Name -eq 'Buscar' }
        $stat = ($b | ? { $_.IsStatic }).Count
        $ctors = ($t.GetConstructors() | % { '(' + (($_.GetParameters() | % { $_.ParameterType.Name + ' ' + $_.Name }) -join ', ') + ')' }) -join ' '
        $bs = ($b | % { ($(if ($_.IsStatic) { 'S' } else { 'I' })) + ':' + (($_.GetParameters() | % { $_.ParameterType.Name }) -join ',') }) -join ';'
        $saves = ($t.GetMethods('Public,Instance,DeclaredOnly') | ? { $_.Name -match '^(Save|Guardar|Agregar)' } | % { $_.Name + '(' + (($_.GetParameters() | % { $_.ParameterType.Name + ' ' + $_.Name }) -join ', ') + ')' }) -join ';'
        $out += "$($dll.BaseName.Replace('VENET_','').Replace('_BL',''))|$($t.Name)|B=$bs|C=$ctors|S=$saves"
    }
}
$out
