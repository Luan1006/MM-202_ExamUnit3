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
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
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
        public void GetBooksStartingWithThe_ReturnsEmptyJson_WhenEmptyJsonIsGiven()
        {
            // Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksStartingWithThe();

            // Assert
            Assert.Empty(books);
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

        [Fact]
        public void GetBooksWrittenByAuthorsWithATInTheirName_ReturnsEmptyJson_WhenEmptyJsonIsGiven()
        {
            // Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksWrittenByAuthorsWithATInTheirName();

            // Assert
            Assert.Empty(books);
        }

        [Fact]
        public void GetBooksWrittenAfter1992_ReturnsJsonWithBooksWrittenAfter1992_WhenJsonOfBooksAreGiven()
        {
            // Arrange
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksWrittenAfter1992();

            // Assert that all book publication years are after 1992
            foreach (Book book in books)
            {
                Assert.True(book.publication_year > 1992);
            }
        }

        [Fact]
        public void GetBooksWrittenAfter1992_ReturnsEmptyJson_WhenEmptyJsonIsGiven()
        {
            // Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksWrittenAfter1992();

            // Assert
            Assert.Empty(books);
        }

        [Fact]
        public void GetBooksWrittenBefore2004_ReturnsJsonWithBooksWrittenBefore2004_WhenJsonOfBooksAreGiven()
        {
            // Arrange
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksWrittenBefore2004();

            // Assert that all book publication years are before 2004
            foreach (Book book in books)
            {
                Assert.True(book.publication_year < 2004);
            }
        }

        [Fact]
        public void GetBooksWrittenBefore2004_ReturnsEmptyJson_WhenEmptyJsonIsGiven()
        {
            // Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetBooksWrittenBefore2004();

            // Assert
            Assert.Empty(books);
        }

        [Fact]
        public void GetIsbnNumberByAuthor_ReturnsEmptyArray_WhenEmptyJsonIsGiven()
        {
            // Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetIsbnNumberByAuthor("Terry Pratchett");

            // Assert
            Assert.Empty(books);
        }

        [Fact]
        public void GetIsbnNumberByAuthor_ReturnsIsbnNumber_WhenJsonOfBooksAreGiven()
        {
            // Arrange
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            // Act
            Book[] books = task4.GetIsbnNumberByAuthor("Terry Pratchett");

            // Assert that all book authors have "t" in their name
            foreach (Book book in books)
            {
                Assert.True(book.author.Contains("Terry Pratchett"));
            }
        }
    }
}