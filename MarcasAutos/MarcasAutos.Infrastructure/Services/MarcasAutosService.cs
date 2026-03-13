using MarcasAutos.Domain;
using MarcasAutos.Domain.Interfaces;
using MarcasAutos.Domain.Interfaces;

namespace MarcasAutos.Infrastructure.Services
{
    /// <summary>
    /// Servicio para las marcas de autos.
    /// </summary>
    public class MarcasAutosService : IMarcasAutosService
    {
        #region Private Fields

        private readonly IMarcasAutosRepository _marcasAutosRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Constructor de la clase MarcasAutosService.
        /// </summary>
        /// <param name="marcasAutosRepository">Repositorio de marcas de autos.</param>
        public MarcasAutosService(IMarcasAutosRepository marcasAutosRepository)
        {
            _marcasAutosRepository = marcasAutosRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Obtiene la lista de vehículos de una marca.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea contiene una colección de MarcasAutos.</returns>
        public async Task<IEnumerable<MarcasAuto>> GetMarcasAutossAsyncService()
        {
            return await _marcasAutosRepository.GetMarcasAutossAsyncRepository();
        }

        /// <summary>
        /// Servicio para agregar un registro de MarcasAutos.
        /// </summary>
        /// <returns>Una tarea que representa la operación de agregado asincrónica</returns>
        public async Task AddMarcaService(MarcasAuto brand)
        {
            await _marcasAutosRepository.AddMarcaRepository(brand);
        }

        #endregion Public Methods
    }
}
