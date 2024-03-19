using MM202ExamUnit3;
using Xunit;

namespace MM202ExamUnit3Tests
{
    public class FunctionsAreAPoppingTests
    {
        [Fact]
        public void SquareNumber_ReturnsSquaredNumber_WhenNumberIsGiven()
        {
            // Arrange
            int number = 4;
            int expected = 16;

            // Act
            int result = FunctionsAreAPopping.SquareNumber(number);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}