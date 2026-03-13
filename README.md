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
