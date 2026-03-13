using MarcasAutos.Domain.Exceptions;
using Xunit;

namespace TestApplication
{
    public class ExceptionTests
    {
        [Fact]
        public void BusinessException_DefaultConstructor_CreatesInstance()
        {
            // Act
            var exception = new BusinessException();

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void BusinessException_MessageConstructor_SetsMessage()
        {
            // Arrange
            var message = "Test message";

            // Act
            var exception = new BusinessException(message);

            // Assert
            Assert.Equal(message, exception.Message);
        }
    }
}
