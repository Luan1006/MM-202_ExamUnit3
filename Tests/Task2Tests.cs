using Xunit;
using MM202ExamUnit3;

namespace MM202ExamUnit3Tests
{
    public class Task2Tests
    {
        [Fact]
        public void FlattenArray_ReturnsFlatArray_WhenJaggedArrayIsGiven()
        {
            // Arrange
            object[] input = { 1, new object[] { 2, 3 }, 4, new object[] { new object[] { 5, 6 }, 7 } };
            int[] expected = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            int[] actual = Task2.FlattenArray(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}