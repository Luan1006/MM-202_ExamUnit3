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
        static readonly ArrayProcessor arrayProcessor = new ArrayProcessor();
        static string jsonFilePath = "";
        static string jsonContent = "";

        static async Task Main()
        {
            Console.Clear();

            Console.WriteLine(WelcomeToJaggedArrayFlattener);

            try
            {
                Console.WriteLine(CallAPI);

                HttpResponseMessage response = await apiService.GetApiResponse(Constants.JaggedAPIURL);
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonDocument doc = apiService.ParseJsonString(responseBody);

                Console.WriteLine(JaggedArray, doc.RootElement);

                int[] flattenedArray = arrayProcessor.FlattenJsonArray(doc);
                string arrayToWrite = string.Join(", ", flattenedArray);
                Console.WriteLine(FlattenedArray, arrayToWrite);
            }
            catch (HttpRequestException e)
            {
                PrintErrorMessage(e.Message);
            }

            try
            {
                Console.WriteLine(ReadJSON);

                jsonFilePath = Path.Combine(ExampleFilesDirectory, ArraysJsonExampleFile);
                jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                JsonDocument doc = JsonDocument.Parse(jsonContent);

                Console.WriteLine(JaggedArray, doc.RootElement);

                int[] flattenedArray = arrayProcessor.FlattenJsonArray(doc);
                string arrayToWrite = string.Join(", ", flattenedArray);
                Console.WriteLine(FlattenedArray, arrayToWrite);
            }
            catch (Exception e)
            {
                PrintErrorMessage(e.Message);
            }

            Console.WriteLine(WelcomeToTheBinaryTreeTraverser);

            try
            {
                Console.WriteLine(CallAPI);

                HttpResponseMessage response = await apiService.GetApiResponse(Constants.BSTAPIURL);
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