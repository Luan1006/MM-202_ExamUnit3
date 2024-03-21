using Xunit;

namespace MM202ExamUnit3.Tests
{
    public class Task3Tests
    {
        [Fact]
        public void Traverse_ReturnsTreeInfo_WhenBinaryTreeIsGiven()
        {
            // Arrange
            Task3 task3 = new Task3();
            Task3.Node node = new Task3.Node
            {
                value = 67,
                left = new Task3.Node { value = 765 },
                right = new Task3.Node
                {
                    value = 167,
                    left = new Task3.Node
                    {
                        value = 564,
                        right = new Task3.Node { value = 379 }
                    }
                }
            };

            // Act
            Task3.TreeInfo result = task3.Traverse(node);

            // Assert
            Assert.Equal(1942, result.Sum);
            Assert.Equal(4, result.Depth);
            Assert.Equal(5, result.Count);
        }
    }
}