using System.Text.Json;
using Xunit;

namespace MM202ExamUnit3.Tests
{
    public class Task4Tests
    {
        [Fact]
        public void GetBooksStartingWithThe_ReturnsJsonWithBooksStartingWithThe_WhenJsonOfBooksAreGiven()
        {
            // Arrange
            string jsonFilePath = Path.Combine("..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksStartingWithThe();

            // Assert that all book titles start with "The"
            foreach (Book book in books)
            {
                Assert.True(book.title.StartsWith("The"));
            }
        }

        [Fact]
        public void GetBooksWrittenByAuthorsWithATInTheirName_ReturnsJsonWithBooksWrittenByAuthorsWithATInTheirName_WhenJsonOfBooksAreGiven()
        {
            // Arrange
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksWrittenByAuthorsWithATInTheirName();

            // Assert that all book authors have "t" in their name
            foreach (Book book in books)
            {
                Assert.True(book.author.Contains("t"));
            }
        }
    }
}