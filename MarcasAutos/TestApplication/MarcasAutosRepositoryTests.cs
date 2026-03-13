using MarcasAutos.Domain;
using MarcasAutos.Domain.Exceptions;
using MarcasAutos.Infrastructure.Context;
using MarcasAutos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestApplication
{
    public class MarcasAutosRepositoryTests
    {
        private ProjectDbContext GetInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new ProjectDbContext(options);
        }

        [Fact]
        public async Task GetMarcasAutossAsyncRepository_ShouldReturnSeededData()
        {
            // Arrange
            var dbName = Guid.NewGuid().ToString();
            using (var context = GetInMemoryDbContext(dbName))
            {
                context.MarcasAutos.Add(new MarcasAuto { Id = 1, NombreMarca = "Ford" });
                context.MarcasAutos.Add(new MarcasAuto { Id = 2, NombreMarca = "Chevrolet" });
                await context.SaveChangesAsync();
            }

            using (var context = GetInMemoryDbContext(dbName))
            {
                var repository = new MarcasAutosRepository(context);

                // Act
                var result = await repository.GetMarcasAutossAsyncRepository();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task AddMarcaRepository_ShouldAddNewBrand()
        {
            // Arrange
            var dbName = Guid.NewGuid().ToString();
            var newBrand = new MarcasAuto { Id = 10, NombreMarca = "Audi" };

            using (var context = GetInMemoryDbContext(dbName))
            {
                var repository = new MarcasAutosRepository(context);

                // Act
                await repository.AddMarcaRepository(newBrand);
            }

            // Assert
            using (var context = GetInMemoryDbContext(dbName))
            {
                var brandInDb = await context.MarcasAutos.FirstOrDefaultAsync(b => b.Id == 10);
                Assert.NotNull(brandInDb);
                Assert.Equal("Audi", brandInDb.NombreMarca);
            }
        }

        [Fact]
        public async Task AddMarcaRepository_ShouldThrowBusinessException_WhenErrorOccurs()
        {
            // Arrange
            // Providing a null brand to trigger failure intentionally, 
            // the Context Add operation will throw An Exception, which is caught and re-thrown as BusinessException
            var dbName = Guid.NewGuid().ToString();

            using (var context = GetInMemoryDbContext(dbName))
            {
                var repository = new MarcasAutosRepository(context);

                // Act & Assert
                await Assert.ThrowsAsync<BusinessException>(async () =>
                {
                    await repository.AddMarcaRepository(null);
                });
            }
        }
    }
}
