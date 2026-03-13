# MarcasAutos API

Proyecto de Web API desarrollado en .NET 6 para la gestión de marcas de vehículos, utilizando PostgreSQL como base de datos y contenedores Docker para un despliegue rápido.

## 🚀 Tecnologías

- **C# / .NET 6**
- **Entity Framework Core**
- **PostgreSQL**
- **Docker & Docker Compose**
- **AutoMapper**
- **Swagger (OpenAPI)**

## 📋 Arquitectura

El proyecto sigue una arquitectura en capas para asegurar el desacoplamiento y la mantenibilidad:

- **Api**: Controladores y configuración de la aplicación.
- **Domain**: Entidades de negocio, DTOs e interfaces principales.
- **Infrastructure**: Implementación de repositorios, servicios, contexto de base de datos y mapeos.

## ⚙️ Requisitos Previos

- [Docker Desktop](https://www.docker.com/products/docker-desktop) instalado y ejecutándose.
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (opcional, para desarrollo).

## 🛠️ Instalación y Ejecución

### Opción 1: Docker Compose (Recomendado)

Desde la raíz del proyecto, ejecuta el siguiente comando:

```bash
docker-compose up --build -d
```

Esto levantará automáticamente:
1. El contenedor con la base de datos **PostgreSQL**.
2. El contenedor con el **Web API**.

### Opción 2: Visual Studio

1. Abre la solución `MarcasAutos.slnx` (o `.sln`).
2. Selecciona el perfil **docker-compose** como proyecto de inicio.
3. Presiona **F5**. Visual Studio se encargará de levantar los contenedores y depurar la aplicación.

## 📖 Documentación de la API (Swagger)

Una vez que el proyecto esté corriendo, puedes acceder a la interfaz de Swagger para probar los endpoints:

🔗 **[http://localhost:5434/swagger/index.html](http://localhost:5434/swagger/index.html)**

## 🗄️ Base de Datos

La base de datos se inicializa automáticamente al arrancar el contenedor del API mediante `EnsureCreated()`, insertando datos de semilla para pruebas.

- **Servidor**: `localhost` (o `postgres-container` dentro de la red de Docker)
- **Puerto**: `5432`
- **Base de datos**: `testCarBrands`
- **Usuario**: `danilo`
- **Contraseña**: `danilo.`

---
Desarrollado para la gestión eficiente de Marcas de Autos.
---

##Ejecución de pruebas
Guía de Pruebas y Cobertura
El proyecto ya cuenta con una suite de pruebas unitarias utilizando xUnit, Moq y Coverlet para medir la cobertura del código.

🏃 Cómo ejecutar las pruebas
Para ejecutar todas las pruebas del proyecto, abre una terminal en la carpeta raíz y ejecuta:

bash
dotnet test TestApplication/TestApplication.csproj
📊 Cómo ver el porcentaje de cobertura
Existen dos formas principales de ver la cobertura:

1. Resumen rápido en consola
Este comando mostrará una tabla directamente en la terminal con el porcentaje de líneas, ramas y métodos cubiertos.

bash
dotnet test TestApplication/TestApplication.csproj /p:CollectCoverage=true
2. Generar reporte detallado (HTML)
Si quieres ver exactamente qué líneas están cubiertas y cuáles no, puedes generar un reporte visual:

Generar el archivo de cobertura:

bash
dotnet test TestApplication/TestApplication.csproj --collect:"XPlat Code Coverage"
Esto creará un archivo coverage.cobertura.xml dentro de la carpeta TestApplication/TestResults/.

Convertir a HTML (Opcional): Si tienes instalada la herramienta ReportGenerator, puedes convertir ese XML en una página web:

bash
# Instalar herramienta si no la tienes
dotnet tool install -g dotnet-reportgenerator-globaltool
# Generar el reporte
reportgenerator -reports:"TestApplication/TestResults/**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
Luego abre coveragereport/index.html en tu navegador.
