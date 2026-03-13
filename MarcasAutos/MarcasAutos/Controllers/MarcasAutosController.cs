using AutoMapper;
using MarcasAutos.Api.Responses;
using MarcasAutos.Domain;
using MarcasAutos.Domain.DTO;
using MarcasAutos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarsProject.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes relacionadas con los vehículos de marcas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MarcasAutosController : ControllerBase
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IMarcasAutosService _service;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Constructor de la clase MarcasAutosController.
        /// </summary>
        /// <param name="service">Servicio de marcas de autos.</param>
        public MarcasAutosController(IMarcasAutosService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Graba un nuevo registro de MarcasAutos
        /// </summary>
        [HttpPost(Name = "AddMarca")]
        public async Task<IActionResult> AddMarcasAutos(MarcasAutosDto brandDto)
        {
            var post = _mapper.Map<MarcasAuto>(brandDto);

            await _service.AddMarcaService(post);

            brandDto = _mapper.Map<MarcasAutosDto>(post);

            var response = new ApiResponse<MarcasAutosDto>(brandDto);

            return Ok(response);
        }

        /// <summary>
        /// Obtiene la lista de vehículos de marcas.
        /// </summary>
        /// <returns>Un IActionResult que contiene la lista de vehículos de marcas.</returns>
        [HttpGet(Name = "GetMarcas")]
        public async Task<IActionResult> GetMarcas()
        {
            var response = await _service.GetMarcasAutossAsyncService();
            return Ok(response);
        }

        #endregion Public Methods
    }
}
