<#
.SYNOPSIS
  Regenera los archivos *.Sources.props que enlazan (sin copiar) el código fuente original
  de VENET_DataEntity, VENET_Comun, VENET_Common y de los proyectos *_BL
  dentro de los proyectos web de SIGNET_Web\shared.

  También genera src\SIGNET_Web.Api\permissions.generated.json (Formulario -> Módulo) a partir
  de las llamadas Seguridad.ObtenerPermiso(...) de los proyectos *_UI originales.

  Ejecutar cada vez que se agreguen/quiten archivos en los proyectos originales:
      powershell -ExecutionPolicy Bypass -File .\tools\Sync-Sources.ps1
#>
param(
    [string]$SignetRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..')).Path
)

$ErrorActionPreference = 'Stop'
$webRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path
$sharedRoot = Join-Path $webRoot 'shared'

# Proyecto original -> proyecto web
$map = @(
    # GestionContext.cs original no declara DbSet<TipoCategoriasContables> (que usa TipoCategoriasContablesManager);
    # se excluye y se compila shared\VENET_DataEntity.Web\GestionContext.Web.cs (copia idéntica + esa línea).
    @{ Orig = 'VENET_DataEntity\VENET_DataEntity\VENET_DataEntity.csproj';         Web = 'VENET_DataEntity.Web';
       Exclude = @('Context\GestionContext.cs') },
    @{ Orig = 'VENET_Comun\VENET_Comun.csproj';                                     Web = 'VENET_Comun.Web' },
    # Seguridad.cs se reemplaza por una versión con estado por sesión (shared\VENET_Common.Web\Web\Seguridad.cs)
    @{ Orig = 'VENET_Common\VENET_Common.csproj';                                   Web = 'VENET_Common.Web'; Exclude = @('Seguridad.cs') },
    @{ Orig = 'VENET_General\VENET_General_BL\VENET_General_BL.csproj';             Web = 'VENET_General_BL.Web' },
    @{ Orig = 'VENET_Seguridad\VENET_Seguridad_BL\VENET_Seguridad_BL.csproj';       Web = 'VENET_Seguridad_BL.Web' },
    @{ Orig = 'VENET_Clientes\VENET_Clientes_BL\VENET_Clientes_BL.csproj';          Web = 'VENET_Clientes_BL.Web' },
    @{ Orig = 'VENET_Proveedores\VENET_Proveedores_BL\VENET_Proveedores_BL.csproj'; Web = 'VENET_Proveedores_BL.Web' },
    @{ Orig = 'VENET_ProvFinancieros\VENET_ProvFinancieros_BL\VENET_ProvFinancieros_BL.csproj'; Web = 'VENET_ProvFinancieros_BL.Web' },
    @{ Orig = 'VENET_Personal\VENET_Personal_BL\VENET_Personal_BL.csproj';          Web = 'VENET_Personal_BL.Web' },
    @{ Orig = 'VENET_Produccion\VENET_Produccion_BL\VENET_Produccion_BL.csproj';    Web = 'VENET_Produccion_BL.Web' },
    @{ Orig = 'VENET_Tesoreria\VENET_Tesoreria_BL\VENET_Tesoreria_BL.csproj';       Web = 'VENET_Tesoreria_BL.Web' },
    @{ Orig = 'VENET_Gestion\VENET_Gestion_BL\VENET_Gestion_BL.csproj';             Web = 'VENET_Gestion_BL.Web' },
    @{ Orig = 'VENET_IA\VENET_IA_BL\VENET_IA_BL.csproj';                         Web = 'VENET_IA_BL.Web' }
)

function Get-CompileItems([string]$csprojPath, [string[]]$exclude, [hashtable]$replace) {
    [xml]$x = Get-Content -LiteralPath $csprojPath
    $dir = Split-Path $csprojPath -Parent
    $items = @()
    foreach ($ig in $x.Project.ItemGroup) {
        foreach ($c in $ig.Compile) {
            if (-not $c) { continue }
            $inc = $c.Include
            # Excluir formularios WinForms, sus diseñadores y archivos de Properties
            if ($c.SubType -in @('Form', 'UserControl', 'Component')) { continue }
            if ($c.DependentUpon) { continue }
            if ($inc -like 'Properties\*') { continue }
            if ($exclude -and ($exclude -contains $inc)) { continue }
            if ($replace -and $replace.ContainsKey($inc)) { $inc = $replace[$inc] }
            $full = Join-Path $dir $inc
            if (-not (Test-Path -LiteralPath $full)) { Write-Warning "No existe: $full"; continue }
            $items += [pscustomobject]@{ Include = $inc; Full = (Resolve-Path -LiteralPath $full).Path }
        }
    }
    return $items
}

foreach ($m in $map) {
    $orig = Join-Path $SignetRoot $m.Orig
    $webDir = Join-Path $sharedRoot $m.Web
    if (-not (Test-Path $webDir)) { New-Item -ItemType Directory $webDir | Out-Null }
    $items = @(Get-CompileItems $orig $m.Exclude $m.Replace)

    $origDirRel = Split-Path $m.Orig -Parent
    $sb = New-Object System.Text.StringBuilder
    [void]$sb.AppendLine('<!-- GENERADO por tools\Sync-Sources.ps1. No editar a mano. -->')
    [void]$sb.AppendLine('<Project>')
    [void]$sb.AppendLine('  <ItemGroup>')
    foreach ($i in $items) {
        $inc = [Security.SecurityElement]::Escape("`$(SignetRoot)$origDirRel\$($i.Include)")
        $link = [Security.SecurityElement]::Escape("Original\$($i.Include)")
        [void]$sb.AppendLine("    <Compile Include=`"$inc`" Link=`"$link`" />")
    }
    [void]$sb.AppendLine('  </ItemGroup>')
    [void]$sb.AppendLine('</Project>')
    $out = Join-Path $webDir "$($m.Web).Sources.props"
    [IO.File]::WriteAllText($out, $sb.ToString(), (New-Object System.Text.UTF8Encoding($false)))
    Write-Host ("{0,-28} {1,4} archivos enlazados" -f $m.Web, $items.Count)
}

# --- Mapa de permisos Formulario -> Modulo extraído de los *_UI originales ---
$perm = @{}
$uiProjects = Get-ChildItem $SignetRoot -Recurse -Filter '*_UI.csproj' | Where-Object { $_.FullName -notmatch '\\SIGNET_Web\\' }
$rx = [regex]'ObtenerPermiso\(\s*(?:VENET_Comun\.)?Enums\.Modulos\.(\w+)\s*,\s*"([^"]+)"'
foreach ($p in $uiProjects) {
    [xml]$x = Get-Content -LiteralPath $p.FullName
    foreach ($ig in $x.Project.ItemGroup) {
        foreach ($c in $ig.Compile) {
            if (-not $c) { continue }
            $full = Join-Path $p.DirectoryName $c.Include
            if (-not (Test-Path -LiteralPath $full)) { continue }
            $txt = [IO.File]::ReadAllText($full)
            foreach ($mt in $rx.Matches($txt)) {
                $form = $mt.Groups[2].Value
                if (-not $perm.ContainsKey($form)) { $perm[$form] = $mt.Groups[1].Value }
            }
        }
    }
}
$apiDir = Join-Path $webRoot 'src\SIGNET_Web.Api'
$sorted = [ordered]@{}
foreach ($k in ($perm.Keys | Sort-Object)) { $sorted[$k] = $perm[$k] }
$json = $sorted | ConvertTo-Json
[IO.File]::WriteAllText((Join-Path $apiDir 'permissions.generated.json'), $json, (New-Object System.Text.UTF8Encoding($false)))
Write-Host ("permissions.generated.json: {0} formularios" -f $perm.Count)

# --- Origen de los combos de cada formulario (Formulario -> Campo -> Sistema.X / manager.X / Enums.X) ---
# El escritorio llena los combos con DataSource = Sistema.TiposIva, Enums.ToList(...), etc.; la web usa este mapa
# para mostrar el texto en lugar del Id.
$combos = @{}
$rxDs = [regex]'(?<c>\w+)\.(?:Properties\.)?DataSource\s*=\s*(?<e>[^;]+);'
foreach ($p in $uiProjects) {
    [xml]$x = Get-Content -LiteralPath $p.FullName
    foreach ($ig in $x.Project.ItemGroup) {
        foreach ($c in $ig.Compile) {
            if (-not $c -or $c.Include -notmatch '(^|\\)frm[^\\]*\.cs$' -or $c.Include -match 'Designer\.cs$') { continue }
            $full = Join-Path $p.DirectoryName $c.Include
            if (-not (Test-Path -LiteralPath $full)) { continue }
            $code = [IO.File]::ReadAllText($full)
            $desPath = $full -replace '\.cs$', '.Designer.cs'
            $des = if (Test-Path -LiteralPath $desPath) { [IO.File]::ReadAllText($desPath) } else { '' }
            $form = ([IO.Path]::GetFileNameWithoutExtension($full) -replace '^frm', '') -replace '_AddMod$', ''
            foreach ($m in $rxDs.Matches($code)) {
                $ctl = $m.Groups['c'].Value; $e = $m.Groups['e'].Value.Trim()
                if ($ctl -match 'BindingSource$' -or $e -eq 'null' -or $e -match '^new ') { continue }
                $src = $null
                if ($e -match '^Sistema\.(\w+)$') { $src = "Sistema.$($Matches[1])" }
                elseif ($e -match '^manager\.(\w+)$') { $src = "manager.$($Matches[1])" }
                elseif ($e -match 'typeof\(Enums\.(\w+)\)') { $src = "Enums.$($Matches[1])" }
                else { continue }
                $b = [regex]::Match($des, 'this\.' + [regex]::Escape($ctl) + '\.DataBindings\.Add\(new System\.Windows\.Forms\.Binding\("(?:EditValue|SelectedValue|Text|SelectedItem)",\s*[^,]+,\s*"(?<p>[^"]+)"')
                if ($b.Success) { $field = ($b.Groups['p'].Value -split '\.')[-1] }
                else {
                    $field = $ctl -creplace '(LookUpEdit|ComboBoxEdit|ComboBox)\d*$', ''
                    $field = $field.Substring(0, 1).ToUpper() + $field.Substring(1)
                }
                if (-not $combos.ContainsKey($form)) { $combos[$form] = @{} }
                if (-not $combos[$form].ContainsKey($field)) { $combos[$form][$field] = $src }
            }
        }
    }
}
$sortedCombos = [ordered]@{}
foreach ($k in ($combos.Keys | Sort-Object)) {
    $f = [ordered]@{}
    foreach ($k2 in ($combos[$k].Keys | Sort-Object)) { $f[$k2] = $combos[$k][$k2] }
    $sortedCombos[$k] = $f
}
[IO.File]::WriteAllText((Join-Path $apiDir 'combos.generated.json'), ($sortedCombos | ConvertTo-Json -Depth 3), (New-Object System.Text.UTF8Encoding($false)))
Write-Host ("combos.generated.json: {0} formularios" -f $combos.Count)
