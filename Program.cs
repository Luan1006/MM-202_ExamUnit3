using System.Text.Json;
using MM202ExamUnit3.Utils;
using static MM202ExamUnit3.Utils.Print;
using static MM202ExamUnit3.Utils.Constants;

namespace MM202ExamUnit3
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static readonly ApiService apiService = new ApiService(client);
        static string jsonFilePath = "";
        static string jsonContent = "";

        static async Task Main()
        {
            Console.Clear();

            Console.WriteLine(WelcomeToJaggedArrayFlattener);

            await Task2.FlattenArrayWithAPICall(JaggedAPIURL);

            jsonFilePath = Path.Combine(ExampleFilesDirectory, ArraysJsonExampleFile);

            await Task2.FlattenArrayWithJsonFile(jsonFilePath);

            Thread.Sleep(5000);
            Console.Clear();

            Console.WriteLine(WelcomeToTheBinaryTreeTraverser);

            await Task3.FindTreeInfoWithAPICall(BSTAPIURL);

            jsonFilePath = Path.Combine(ExampleFilesDirectory, NodesJsonExampleFile);

            await Task3.FindTreeInfoWithJsonFile(jsonFilePath);

            Thread.Sleep(5000);
            Console.Clear();

            Console.WriteLine(WelcomeToTheBookListProcessor);
            jsonFilePath = Path.Combine(ExampleFilesDirectory, BooksJsonExampleFile);
            jsonContent = await File.ReadAllTextAsync(jsonFilePath);

            Task4 task4 = new Task4(jsonContent);

            IEnumerable<IGrouping<string, Book>> lastNameGroups = task4.GroupBooksByAuthorLastName();

            foreach (IGrouping<string, Book> group in lastNameGroups)
            {
                Console.WriteLine(AuthorLastName + group.Key);
                foreach (Book book in group)
                {
                    Console.WriteLine(Title + book.title);
                }
                Console.WriteLine();
            }
        }
    }
}