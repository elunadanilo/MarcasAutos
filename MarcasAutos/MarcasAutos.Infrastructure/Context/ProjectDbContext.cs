using MarcasAutos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MarcasAutos.Infrastructure.Context
{
    /// <summary>
    /// Contexto de base de datos para el proyecto.
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        #region Public Constructors

        /// <summary>
        /// Constructor de la clase ProjectDbContext.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Conjunto de datos para los vehículos de marca.
        /// </summary>
        public DbSet<MarcasAuto> MarcasAutos { get; set; }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Configura el modelo mediante el ModelBuilder.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MarcasAuto>().HasData(
                new MarcasAuto { Id = 1, NombreMarca = "Toyota" },
                new MarcasAuto { Id = 2, NombreMarca = "Mazda" },
                new MarcasAuto { Id = 3, NombreMarca = "JAC" },
                new MarcasAuto { Id = 4, NombreMarca = "Mitsubishi" },
                new MarcasAuto { Id = 5, NombreMarca = "Datsun" }
            );
        }

        #endregion Protected Methods
    }
}
