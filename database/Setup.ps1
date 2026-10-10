param(
    [ValidateSet('Export', 'Apply', 'Verify')]
    [string]$Mode = 'Export'
)
$ErrorActionPreference = 'Stop'
$taskProject = Join-Path $PSScriptRoot 'DVLD.DatabaseSetup/DVLD.DatabaseSetup.csproj'
$taskAssembly = Join-Path $PSScriptRoot 'DVLD.DatabaseSetup/bin/Debug/net8.0/DVLD.DatabaseSetup.dll'
& dotnet build $taskProject --nologo -m:1
if ($LASTEXITCODE -ne 0) { throw 'Database setup build failed.' }
if ($Mode -ne 'Verify') {
    & dotnet $taskAssembly --export
    if ($LASTEXITCODE -ne 0) { throw 'SQL export failed.' }
}
if ($Mode -eq 'Apply') {
    & dotnet $taskAssembly --apply
    if ($LASTEXITCODE -ne 0) { throw 'Database creation or verification failed.' }
}
if ($Mode -eq 'Verify') {
    & dotnet $taskAssembly --verify
    if ($LASTEXITCODE -ne 0) { throw 'Database verification failed.' }
}
