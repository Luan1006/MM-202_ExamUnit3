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

            await FindTreeInfoWithAPICall(BSTAPIURL);

            jsonFilePath = Path.Combine(ExampleFilesDirectory, NodesJsonExampleFile);

            await FindTreeInfoWithJsonFile(jsonFilePath);

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

        private static async Task FindTreeInfoWithJsonFile(string jsonFilePath)
        {
            try
            {
                Console.WriteLine(ReadJSON);

                jsonFilePath = Path.Combine(ExampleFilesDirectory, NodesJsonExampleFile);
                jsonContent = await File.ReadAllTextAsync(jsonFilePath);

                Task3 task3 = new Task3();

                Console.WriteLine(BinaryTree, jsonContent);

                Task3.Node root = JsonSerializer.Deserialize<Task3.Node>(jsonContent);

                Task3.TreeInfo treeInfo = task3.Traverse(root);

                Console.WriteLine(Sum, treeInfo.Sum);
                Console.WriteLine(DeepestLevel, treeInfo.Depth);
                Console.WriteLine(Nodes, treeInfo.Count);
            }
            catch (Exception e)
            {
                PrintErrorMessage(e.Message);
            }
        }

        private static async Task FindTreeInfoWithAPICall(string BSTAPIURL)
        {
            try
            {
                Console.WriteLine(CallAPI);

                HttpResponseMessage response = await apiService.GetApiResponse(BSTAPIURL);
                string responseBody = await response.Content.ReadAsStringAsync();

                Task3 task3 = new Task3();

                Console.WriteLine(BinaryTree, responseBody);

                Task3.Node root = JsonSerializer.Deserialize<Task3.Node>(responseBody);

                Task3.TreeInfo treeInfo = task3.Traverse(root);

                Console.WriteLine(Sum, treeInfo.Sum);
                Console.WriteLine(DeepestLevel, treeInfo.Depth);
                Console.WriteLine(Nodes, treeInfo.Count);
            }
            catch (HttpRequestException e)
            {
                PrintErrorMessage(e.Message);
            }
        }
    }
}