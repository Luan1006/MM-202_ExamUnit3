using System.Text.Json;
using MM202ExamUnit3.Utils;

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

        public Book[] SortListOfBooksChronologically()
        {
            Book[] result = books.OrderBy(b => b.publication_year).ToArray();
            return result;
        }

        public IEnumerable<IGrouping<string, Book>> GroupBooksByAuthorLastName()
        {
            IEnumerable<IGrouping<string, Book>> result = books.GroupBy(b =>
            {
                string author = b.author.Split(" (Translated by")[0];
                string lastName = author.Split(" ").Last();
                return lastName;
            }).ToArray();

            return result;
        }

        public IEnumerable<IGrouping<string, Book>> GroupBooksByAuthorFirstName()
        {
            IEnumerable<IGrouping<string, Book>> result = books.GroupBy(b =>
            {
                string firstName = b.author.Split(" ").First();
                return firstName;
            }).ToArray();

            return result;
        }

        public static async Task GroupBooksByAuthorLastNameUsingJsonFile(string jsonFilePath)
        {
            string jsonContent = await File.ReadAllTextAsync(jsonFilePath);

            Task4 task4 = new Task4(jsonContent);

            IEnumerable<IGrouping<string, Book>> lastNameGroups = task4.GroupBooksByAuthorLastName();

            foreach (IGrouping<string, Book> group in lastNameGroups)
            {
                Console.WriteLine(Constants.AuthorLastName + group.Key);
                foreach (Book book in group)
                {
                    Console.WriteLine(Constants.Title + book.title);
                }
                Console.WriteLine();
            }
        }
    }
}