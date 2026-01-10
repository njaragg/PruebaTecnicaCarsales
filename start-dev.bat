@echo off
setlocal

echo Starting BFF (.NET)...
start "BFF" cmd /k "dotnet watch --project backend\PruebaTecnicaCarsales.Backend\PruebaTecnicaCarsales.Bff\PruebaTecnicaCarsales.Bff.csproj --launch-profile https"

echo Starting Frontend (Angular)...
start "FRONT" cmd /k "npm start --prefix frontend\PruebaTecnicaCarsales-Frontend"

echo.
echo ✅ Both started.
echo - Stop with Ctrl+C in each window, or run stop-dev.bat to kill ports 4200/7257/5296.
endlocal
