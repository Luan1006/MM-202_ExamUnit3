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
            string[] isbnNumbers = task4.GetIsbnNumberByAuthor("Terry Pratchett");

            // Assert
            Assert.Empty(isbnNumbers);
        }

        [Fact]
        public void GetIsbnNumberByAuthor_ReturnsIsbnNumber_WhenJsonOfBooksAreGiven()
        {
            // Arrange
            string author = "Terry Pratchett";
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            // Act
            string[] isbnNumbers = task4.GetIsbnNumberByAuthor(author);

            // Assert
            foreach (string isbn in isbnNumbers)
            {
                Book book = task4.books.First(b => b.isbn == isbn);
                Assert.Contains(author, book.author);
            }
        }

        [Fact]
        public void SortListOfBooksAlphabetically_ReturnsEmptyList_WhenEmptyJsonIsGiven()
        {
            //Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            //Act
            Book[] books = task4.SortListOfBooksAlphabetically();

            //Assert
            Assert.Empty(books);
        }

        [Fact]
        public void SortListOfBooksAlphabetically_ReturnsSortedBooks_WhenJsonOfBooksAreGiven()
        {
            //Arrange
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            //Act
            Book[] books = task4.SortListOfBooksAlphabetically();

            //Assert
            for (int i = 0; i < books.Length - 1; i++)
            {
                Assert.True(string.Compare(books[i].title, books[i + 1].title) <= 0);
            }
        }

        [Fact]
        public void SortListOfBooksChronologically_ReturnsEmptyList_WhenEmptyJsonIsGiven()
        {
            //Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            //Act
            Book[] books = task4.SortListOfBooksChronologically();

            //Assert
            Assert.Empty(books);
        }

        [Fact]
        public void SortListOfBooksChronologically_ReturnsSortedBooks_WhenJsonOfBooksAreGiven()
        {
            //Arrange
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            //Act
            Book[] books = task4.SortListOfBooksChronologically();

            //Assert
            for (int i = 0; i < books.Length - 1; i++)
            {
                Assert.True(books[i].publication_year <= books[i + 1].publication_year);
            }
        }

        [Fact]
        public void GroupListOfBooksByAuthorsLastName_ReturnsEmptyGroup_WhenEmptyJsonIsGiven()
        {
            //Arrange
            string jsonContent = "[]";
            Task4 task4 = new Task4(jsonContent);

            //Act
            IEnumerable<IGrouping<string, Book>> groupedBooks = task4.GroupListOfBooksByAuthorsLastName();

            //Assert
            Assert.Empty(groupedBooks);
        }

        [Fact]
        public void GroupListOfBooksByAuthorsLastName_ReturnsGroupedBooks_WhenJsonOfBooksAreGiven()
        {
            //Arrange
            string jsonFilePath = Path.Combine("..", "..", "..", "ExampleFiles", "books.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            Task4 task4 = new Task4(jsonContent);

            //Act
            IEnumerable<IGrouping<string, Book>> groupedBooks = task4.GroupListOfBooksByAuthorsLastName();

            //Assert
            foreach (IGrouping<string, Book> group in groupedBooks)
            {
                foreach (Book book in group)
                {
                    Assert.Contains(group.Key, book.author);
                }
            }
        }
    }
}