using MarcasAutos.Domain;
using MarcasAutos.Domain.Interfaces;
using MarcasAutos.Infrastructure.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Xunit;

namespace TestApplication
{
    public class MarcasAutosServiceTests
    {
        private readonly Mock<IMarcasAutosRepository> _mockRepository;
        private readonly MarcasAutosService _service;

        public MarcasAutosServiceTests()
        {
            _mockRepository = new Mock<IMarcasAutosRepository>();
            _service = new MarcasAutosService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetMarcasAutossAsyncService_ShouldReturnBrandsList()
        {
            // Arrange
            var mockBrands = new List<MarcasAuto>
            {
                new MarcasAuto { Id = 1, NombreMarca = "Nissan" },
                new MarcasAuto { Id = 2, NombreMarca = "BMW" }
            };

            _mockRepository.Setup(r => r.GetMarcasAutossAsyncRepository()).ReturnsAsync(mockBrands);

            // Act
            var result = await _service.GetMarcasAutossAsyncService();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Nissan", result.First().NombreMarca);
        }

        [Fact]
        public async Task AddMarcaService_ShouldCallRepositoryAddMethod()
        {
            // Arrange
            var brand = new MarcasAuto { Id = 1, NombreMarca = "Volvo" };
            _mockRepository.Setup(r => r.AddMarcaRepository(It.IsAny<MarcasAuto>())).Returns(Task.CompletedTask);

            // Act
            await _service.AddMarcaService(brand);

            // Assert
            _mockRepository.Verify(r => r.AddMarcaRepository(It.IsAny<MarcasAuto>()), Times.Once);
        }
    }
}

