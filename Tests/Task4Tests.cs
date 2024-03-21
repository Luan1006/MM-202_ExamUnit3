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
            Task4 task4 = new Task4();
            string jsonFilePath = Path.Combine("..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Act
            string result = task4.GetBooksStartingWithThe(jsonContent);

            // Parse the result back into a list of books
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(result);

            // Assert that all book titles start with "The"
            foreach (Book book in books)
            {
                Assert.True(book.title.StartsWith("The"));
            }
        }
    }
}