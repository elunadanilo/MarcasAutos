namespace MarcasAutos.Domain.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de marcas de autos.
    /// </summary>
    public interface IMarcasAutosService
    {
        #region Public Methods

        /// <summary>
        /// Obtiene la lista de vehículos de una marca.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea contiene una colección de MarcasAutos.</returns>
        Task<IEnumerable<MarcasAuto>> GetMarcasAutossAsyncService();

        /// <summary>
        /// Servicio para agregar un registro de MarcasAutos.
        /// </summary>
        /// <returns>Una tarea que representa la operación de agregado asincrónica</returns>
        Task AddMarcaService(MarcasAuto brand);

        #endregion Public Methods
    }
}
