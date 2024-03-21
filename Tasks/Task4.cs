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
        private List<Book> books;

        public Task4(string jsonContent)
        {
            books = JsonSerializer.Deserialize<List<Book>>(jsonContent);
        }

        public Book[] GetBooksStartingWithThe()
        {
            books = books.Where(b => b.title.StartsWith("The")).ToList();
            return books.ToArray();
        }
    }
}