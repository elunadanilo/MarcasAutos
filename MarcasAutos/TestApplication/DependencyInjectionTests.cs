using MarcasAutos.Domain.Interfaces;
using MarcasAutos.Infrastructure.Context;
using MarcasAutos.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace TestApplication
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void AddServices_RegistersRequiredServices()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddDbContext<ProjectDbContext>(options => options.UseInMemoryDatabase("TestDb"));

            // Act
            services.AddServices();
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            var brandService = serviceProvider.GetService<IMarcasAutosService>();
            var brandRepository = serviceProvider.GetService<IMarcasAutosRepository>();

            Assert.NotNull(brandService);
            Assert.NotNull(brandRepository);
        }
    }
}
