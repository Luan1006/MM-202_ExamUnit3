using Xunit;
using MM202ExamUnit3;

public class FlattenThoseNumbersTests
{
    [Fact]
    public void FlattenArray_ReturnsFlatArray_WhenJaggedArrayIsGiven()
    {
        // Arrange
        object[] input = { 1, new object[] { 2, 3 }, 4, new object[] { new object[] { 5, 6 }, 7 } };
        int[] expected = { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        int[] actual = FlattenThoseNumbers.FlattenArray(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}