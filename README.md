# Billetera API - Prueba Técnica
Este proyecto es una API REST desarrollada en .NET 8 para gestionar transferencias de saldo entre billeteras. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre las billeteras y operaciones CR (Crear, Leer) sobre el historial de movimientos. Además, maneja casos de errores comunes y sigue los principios de Clean Architecture y SOLID.




## Requisitos de la prueba

* **Framework:** .NET 8
* **Arquitectura:** Clean Architecture
* **Persistencia:** Entity Framework Core
* **Base de datos:** SQL Server
* **Enfoque de desarrollo:** Principios SOLID y buenas prácticas

## Requisitos de la aplicación 
* **Framework:** .NET 8
* **Base de datos:** SQL Server
* **IDE:** Visual Studio 2022 o Visual Studio Code



## Pasos para Configurar el Proyecto
1. Clonar el Repositorio:
```
git clone https://github.com/rpalav/TestBilletera.git
cd billetera-api
```
2. Configurar la Base de Datos:
```
  "ConnectionStrings": {
    "DefaultConnection": "Server=DireccionServer;Database=Wallet;Trusted_Connection=True;MultipleActi  veResultSets=true;TrustServerCertificate=True"
  }
```
 
3. Aplicar Migraciones:
```
dotnet ef database update --project src/BilleteraAPI.Infrastructure
```

4. Ejecutar la Aplicación:
```
dotnet run --project src/BilleteraAPI.WebApi
```

