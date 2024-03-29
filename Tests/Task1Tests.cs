using Xunit;

namespace MM202ExamUnit3.Tests
{
    public class Task1Tests
    {
        [Fact]
        public void SquareNumber_ReturnsSquaredNumber_WhenNumberIsGiven()
        {
            // Arrange
            double number = 4;
            double expected = 16;

            // Act
            double result = Task1.SquareNumber(number);

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
            double result = Task1.MillimeterToInches(millimeters);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MillimeterToInches_ThrowsException_WhenNegativeMillimetersIsGiven()
        {
            // Arrange
            double millimeters = -25.4;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Task1.MillimeterToInches(millimeters));
        }

        [Fact]
        public void RootNumber_ReturnsRootedNumber_WhenNumberIsGiven()
        {
            // Arrange
            double number = 16;
            double expected = 4;

            // Act
            double result = Task1.RootNumber(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RootNumber_ThrowsException_WhenNegativeNumberIsGiven()
        {
            // Arrange
            double number = -16;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Task1.RootNumber(number));
        }

        [Fact]
        public void ThrowsException_WhenZeroIsGiven()
        {
            // Arrange
            double number = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Task1.RootNumber(number));
        }

        [Fact]
        public void CubedNumber_ReturnsCubedNumber_WhenNumberIsGiven()
        {
            // Arrange
            double number = 4;
            double expected = 64;

            // Act
            double result = Task1.CubedNumber(number);

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
            double result = Task1.AreaOfCircle(radius);

            // Assert
            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void AreaOfCircle_ThrowsException_WhenNegativeRadiusIsGiven()
        {
            // Arrange
            double radius = -5;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Task1.AreaOfCircle(radius));
        }
    }
}