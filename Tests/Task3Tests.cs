using Xunit;
using MM202ExamUnit3;

public class Task3Tests
{
    [Fact]
    public void Traverse_ReturnsTreeInfo_WhenBinaryTreeIsGiven()
    {
        // Arrange
        var task3 = new Task3();
        var node = new Task3.Node
        {
            Value = 67,
            Left = new Task3.Node { Value = 765 },
            Right = new Task3.Node
            {
                Value = 167,
                Left = new Task3.Node
                {
                    Value = 564,
                    Right = new Task3.Node { Value = 379 }
                }
            }
        };

        // Act
        var result = task3.Traverse(node);

        // Assert
        Assert.Equal(1942, result.Sum);
        Assert.Equal(4, result.Depth);
        Assert.Equal(5, result.Count);
    }
}