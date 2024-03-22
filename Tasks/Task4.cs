using System.Text.Json;

namespace MM202ExamUnit3
{
    public class Book
    {
        public string title { get; set; }
        public int publication_year { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
    }
    public class Task4
    {
        public List<Book> books;

        public Task4(string jsonContent)
        {
            books = JsonSerializer.Deserialize<List<Book>>(jsonContent);
        }

        public Book[] GetBooksStartingWithThe()
        {
            Book[] result = books.Where(b => b.title.StartsWith("The")).ToArray();
            return result;
        }

        public Book[] GetBooksWrittenByAuthorsWithATInTheirName()
        {
            Book[] result = books.Where(b => b.author.Contains("t")).ToArray();
            return result;
        }

        public Book[] GetBooksWrittenAfter1992()
        {
            Book[] result = books.Where(b => b.publication_year > 1992).ToArray();
            return result;
        }

        public Book[] GetBooksWrittenBefore2004()
        {
            Book[] result = books.Where(b => b.publication_year < 2004).ToArray();
            return result;
        }

        public string[] GetIsbnNumberByAuthor(string author)
        {
            string[] result = books.Where(b => b.author == author).Select(b => b.isbn).ToArray();
            return result;
        }

        public Book[] SortListOfBooksAlphabetically()
        {
            Book[] result = books.OrderBy(b => b.title).ToArray();
            return result;
        }

        internal Book[] SortListOfBooksChronologically()
        {
            throw new NotImplementedException();
        }
    }
}