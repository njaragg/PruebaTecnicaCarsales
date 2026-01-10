# PruebaTecnicaCarsales.Bff (.NET 8) — BFF Rick & Morty

Backend-for-Frontend (BFF) en **.NET 8** que consume la API pública de Rick and Morty y expone endpoints propios para **Episodes** y **Characters** con **paginación**, **filtro por nombre**, **manejo de errores** y **configuración por appsettings**.

---

## Requisitos

- **.NET SDK 8.x**
- (Opcional) Visual Studio 2022 / VS Code
- API externa utilizada: Rick and Morty API

---

## Configuración

La configuración se encuentra en `appsettings.json`:

```json
{
  "RickAndMortyApi": {
    "BaseUrl": "https://rickandmortyapi.com/api/",
    "TimeoutSeconds": 10
  }
}
```

---

## Scripts de desarrollo

Primer uso (despues de clonar):
1. Abrir PowerShell o CMD en la raiz del repo
2. Ejecutar:

```powershell
powershell -ExecutionPolicy Bypass -File .\setup-and-run.ps1
```

Uso diario:
- Iniciar dev: `start-dev.bat` (levanta frontend y backend)
- Detener y liberar puertos (4200/7257/5296): `stop-dev.bat`

El script `setup-and-run.ps1` instala dependencias del frontend (npm install), restaura el backend (dotnet restore) y luego levanta ambos servicios.
