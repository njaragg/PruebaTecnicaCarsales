$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $repoRoot

$frontendPath = Join-Path $repoRoot 'frontend\PruebaTecnicaCarsales-Frontend'
$backendSln = Join-Path $repoRoot 'backend\PruebaTecnicaCarsales.Backend\PruebaTecnicaCarsales.Backend.slnx'

if (-not (Test-Path $frontendPath)) {
  Write-Error "Frontend path not found: $frontendPath"
  exit 1
}

Write-Host "Installing frontend deps..."
npm install --prefix $frontendPath

if (Test-Path $backendSln) {
  Write-Host "Restoring backend packages..."
  dotnet restore $backendSln
} else {
  Write-Warning "Backend solution not found: $backendSln. Skipping dotnet restore."
}

Write-Host "Starting dev servers..."
& (Join-Path $repoRoot 'start-dev.bat')
