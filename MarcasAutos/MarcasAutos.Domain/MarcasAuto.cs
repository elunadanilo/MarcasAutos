namespace MarcasAutos.Domain
{
    /// <summary>
    /// Representa un vehículo de una marca.
    /// </summary>
    public class MarcasAuto
    {
        #region Public Properties

        /// <summary>
        /// Obtiene o establece el identificador del vehículo de la marca.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la marca del vehículo.
        /// </summary>
        public string NombreMarca { get; set; }

        #endregion Public Properties
    }
}
