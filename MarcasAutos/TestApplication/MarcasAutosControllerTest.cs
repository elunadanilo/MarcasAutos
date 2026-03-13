using AutoMapper;
using CarsProject.Controllers;
using MarcasAutos.Api.Responses;
using MarcasAutos.Domain;
using MarcasAutos.Domain.DTO;
using MarcasAutos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Xunit;

namespace TestApplication
{
    public class MarcasAutosControllerTest
    {
        private readonly Mock<IMarcasAutosService> _mockService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MarcasAutosController _controller;

        public MarcasAutosControllerTest()
        {
            _mockService = new Mock<IMarcasAutosService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new MarcasAutosController(_mockService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetMarcas_ShouldReturnOkResult_WithListOfBrands()
        {
            // Arrange
            var mockBrands = new List<MarcasAuto>
            {
                new MarcasAuto { Id = 1, NombreMarca = "Toyota" },
                new MarcasAuto { Id = 2, NombreMarca = "Honda" }
            };

            _mockService.Setup(s => s.GetMarcasAutossAsyncService()).ReturnsAsync(mockBrands);

            // Act
            var result = await _controller.GetMarcas();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBrands = Assert.IsAssignableFrom<IEnumerable<MarcasAuto>>(okResult.Value);
            Assert.Equal(2, returnedBrands.Count());
            Assert.Equal("Toyota", returnedBrands.First().NombreMarca);
        }

        [Fact]
        public async Task AddMarcasAutos_ShouldReturnOkResult_WithApiResponse()
        {
            // Arrange
            var brandDto = new MarcasAutosDto { Id = 1, NombreMarca = "Ford" };
            var mappedBrand = new MarcasAuto { Id = 1, NombreMarca = "Ford" };

            _mockMapper.Setup(m => m.Map<MarcasAuto>(It.IsAny<MarcasAutosDto>())).Returns(mappedBrand);
            _mockMapper.Setup(m => m.Map<MarcasAutosDto>(It.IsAny<MarcasAuto>())).Returns(brandDto);
            _mockService.Setup(s => s.AddMarcaService(It.IsAny<MarcasAuto>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddMarcasAutos(brandDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponse<MarcasAutosDto>>(okResult.Value);
            Assert.Equal("Ford", response.Data.NombreMarca);
            _mockService.Verify(s => s.AddMarcaService(It.IsAny<MarcasAuto>()), Times.Once);
        }
    }
}
