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

        [Fact]
        public void MillimeterToInches_ReturnsInches_WhenMillimetersIsGiven()
        {
            // Arrange
            double millimeters = 25.4;
            double expected = 1;

            // Act
            double result = FunctionsAreAPopping.MillimeterToInches(millimeters);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RootNumber_ReturnsRootedNumber_WhenNumberIsGiven()
        {
            // Arrange
            int number = 16;
            int expected = 4;

            // Act
            int result = FunctionsAreAPopping.RootNumber(number);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}