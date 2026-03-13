using MarcasAutos.Domain;
using MarcasAutos.Domain.Exceptions;
using MarcasAutos.Domain.Interfaces;
using MarcasAutos.Infrastructure.Context;
using MarcasAutos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutos.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para las marcas de autos.
    /// </summary>
    public class MarcasAutosRepository : IMarcasAutosRepository
    {
        #region Private Fields

        private readonly ProjectDbContext _projectDbContext;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Constructor de la clase MarcasAutosRepository.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public MarcasAutosRepository(ProjectDbContext context)
        {
            _projectDbContext = context;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Obtiene la lista de vehículos de una marca.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea contiene una colección de MarcasAutos.</returns>
        public async Task<IEnumerable<MarcasAuto>> GetMarcasAutossAsyncRepository()
        {
            var listado = await _projectDbContext.MarcasAutos.ToListAsync();
            return listado;
        }

        /// <summary>
        /// Agrega un registro de MarcasAutos.
        /// </summary>
        /// <returns>Una tarea que representa la operación de agregado asincrónica</returns>
        public async Task AddMarcaRepository(MarcasAuto brand)
        {
            try
            {
                _projectDbContext.Add(brand);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception exc)
            {

                throw new BusinessException("Error al grabar encabezado de encuesta" + exc);
            }
        }

        #endregion Public Methods
    }
}
