@echo off
setlocal EnableExtensions EnableDelayedExpansion

REM ==== Puertos a cerrar ====
set "PORTS=4200 7257 5296"

echo Stopping services on ports: %PORTS%
echo.

for %%P in (%PORTS%) do (
  call :KILL_PORT %%P
)

echo.
echo Done !!.
exit /b 0

:KILL_PORT
set "PORT=%~1"
set "FOUND=0"

REM Busca procesos que estén LISTENING en el puerto (servidor)
for /f "tokens=5" %%A in ('netstat -ano ^| findstr /R /C:":%PORT% .*LISTENING"') do (
  set "FOUND=1"
  set "PID=%%A"
  echo - Port %PORT% -> PID !PID! (killing)
  taskkill /PID !PID! /F >nul 2>&1
)

if "!FOUND!"=="0" (
  echo - Port %PORT% -> no LISTENING process found
)

exit /b 0
