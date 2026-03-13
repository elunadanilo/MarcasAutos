using AutoMapper;
using MarcasAutos.Domain;
using MarcasAutos.Domain.DTO;
using MarcasAutos.Infrastructure.Mappings;
using Xunit;

namespace TestApplication
{
    public class MappingTests
    {
        private readonly IMapper _mapper;

        public MappingTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();
            });
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map_MarcasAuto_To_MarcasAutosDto()
        {
            // Arrange
            var entity = new MarcasAuto { Id = 1, NombreMarca = "Toyota" };

            // Act
            var dto = _mapper.Map<MarcasAutosDto>(entity);

            // Assert
            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.NombreMarca, dto.NombreMarca);
        }

        [Fact]
        public void Map_MarcasAutosDto_To_MarcasAuto()
        {
            // Arrange
            var dto = new MarcasAutosDto { Id = 1, NombreMarca = "Toyota" };

            // Act
            var entity = _mapper.Map<MarcasAuto>(dto);

            // Assert
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.NombreMarca, entity.NombreMarca);
        }
    }
}
