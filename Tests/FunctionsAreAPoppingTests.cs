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
        public void MillimeterToInches_ThrowsException_WhenNegativeMillimetersIsGiven()
        {
            // Arrange
            double millimeters = -25.4;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => FunctionsAreAPopping.MillimeterToInches(millimeters));
        }

        [Fact]
        public void RootNumber_ReturnsRootedNumber_WhenNumberIsGiven()
        {
            // Arrange
            double number = 16;
            double expected = 4;

            // Act
            double result = FunctionsAreAPopping.RootNumber(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RootNumber_ThrowsException_WhenNegativeNumberIsGiven()
        {
            // Arrange
            double number = -16;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => FunctionsAreAPopping.RootNumber(number));
        }

        [Fact]
        public void ThrowsException_WhenZeroIsGiven()
        {
            // Arrange
            double number = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => FunctionsAreAPopping.RootNumber(number));
        }

        [Fact]
        public void CubedNumber_ReturnsCubedNumber_WhenNumberIsGiven()
        {
            // Arrange
            int number = 4;
            int expected = 64;

            // Act
            int result = FunctionsAreAPopping.CubedNumber(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AreaOfCircle_ReturnsArea_WhenRadiusIsGiven()
        {
            // Arrange
            double radius = 5;
            double expected = 78.54;

            // Act
            double result = FunctionsAreAPopping.AreaOfCircle(radius);

            // Assert
            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void AreaOfCircle_ThrowsException_WhenNegativeRadiusIsGiven()
        {
            // Arrange
            double radius = -5;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => FunctionsAreAPopping.AreaOfCircle(radius));
        }
    }
}