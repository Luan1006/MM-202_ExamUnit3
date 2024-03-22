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

        static async Task Main()
        {
            Console.Clear();

            Console.WriteLine(WelcomeToJaggedArrayFlattener);

            await Task2.FlattenArrayWithAPICall(JaggedAPIURL);

            jsonFilePath = Path.Combine(ExampleFilesDirectory, ArraysJsonExampleFile);

            await Task2.FlattenArrayWithJsonFile(jsonFilePath);

            PrintPauseMessage();

            Console.WriteLine(WelcomeToTheBinaryTreeTraverser);

            await Task3.FindTreeInfoWithAPICall(BSTAPIURL);

            jsonFilePath = Path.Combine(ExampleFilesDirectory, NodesJsonExampleFile);

            await Task3.FindTreeInfoWithJsonFile(jsonFilePath);

            PrintPauseMessage();

            Console.WriteLine(WelcomeToTheBookListProcessor);

            jsonFilePath = Path.Combine(ExampleFilesDirectory, BooksJsonExampleFile);

            await Task4.GroupBooksByAuthorLastNameUsingJsonFile(jsonFilePath);
        }
    }
}