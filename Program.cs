using System.Text.Json;
using MM202ExamUnit3.Utils;
using static MM202ExamUnit3.Utils.Print;

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

            Console.WriteLine("Welcome to the Jagged Array Flattener!\n");

            try
            {
                Console.WriteLine("Calling the API...");

                HttpResponseMessage response = await apiService.GetApiResponse(Constants.JaggedAPIURL);
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonDocument doc = apiService.ParseJsonString(responseBody);

                Console.WriteLine($"Jagged array: {doc.RootElement}");

                int[] flattenedArray = arrayProcessor.FlattenJsonArray(doc);
                string arrayToWrite = string.Join(", ", flattenedArray);
                Console.WriteLine($"Flattened array: [{arrayToWrite}]\n");
            }
            catch (HttpRequestException e)
            {
                PrintErrorMessage(e.Message);
            }

            try
            {
                Console.WriteLine("Reading the JSON file...");

                jsonFilePath = Path.Combine("ExampleFiles", "arrays.json");
                jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                JsonDocument doc = JsonDocument.Parse(jsonContent);

                Console.WriteLine($"Jagged array:\n{doc.RootElement}");

                int[] flattenedArray = arrayProcessor.FlattenJsonArray(doc);
                string arrayToWrite = string.Join(", ", flattenedArray);
                Console.WriteLine($"Flattened array: [{arrayToWrite}]");
            }
            catch (Exception e)
            {
                PrintErrorMessage(e.Message);
            }

            Console.WriteLine("\nWelcome to the Binary Tree Traverser!\n");

            try
            {
                Console.WriteLine("Calling the API...");

                HttpResponseMessage response = await apiService.GetApiResponse(Constants.BSTAPIURL);
                string responseBody = await response.Content.ReadAsStringAsync();

                Task3 task3 = new Task3();

                Console.WriteLine($"Binary tree: {responseBody}");

                Task3.Node root = JsonSerializer.Deserialize<Task3.Node>(responseBody);

                Task3.TreeInfo treeInfo = task3.Traverse(root);

                Console.WriteLine($"Sum = {treeInfo.Sum}");
                Console.WriteLine($"Deepest level = {treeInfo.Depth}");
                Console.WriteLine($"Nodes = {treeInfo.Count}");
            }
            catch (HttpRequestException e)
            {
                PrintErrorMessage(e.Message);
            }

            try
            {
                Console.WriteLine("Reading the JSON file...");

                jsonFilePath = Path.Combine("ExampleFiles", "nodes.json");
                jsonContent = await File.ReadAllTextAsync(jsonFilePath);

                Task3 task3 = new Task3();

                Console.WriteLine($"Binary tree: {jsonContent}");

                Task3.Node root = JsonSerializer.Deserialize<Task3.Node>(jsonContent);

                Task3.TreeInfo treeInfo = task3.Traverse(root);

                Console.WriteLine($"Sum = {treeInfo.Sum}");
                Console.WriteLine($"Deepest level = {treeInfo.Depth}");
                Console.WriteLine($"Nodes = {treeInfo.Count}");
            }
            catch (Exception e)
            {
                PrintErrorMessage(e.Message);
            }

            Console.WriteLine("\nWelcome to the Book List Processor!\n");
            jsonFilePath = Path.Combine("ExampleFiles", "books.json");
            jsonContent = await File.ReadAllTextAsync(jsonFilePath);

            Task4 task4 = new Task4(jsonContent);

            IEnumerable<IGrouping<string, Book>> groups = task4.GroupBooksByAuthorLastName();

            foreach (IGrouping<string, Book> group in groups)
            {
                Console.WriteLine($"Author Last Name: {group.Key}");
                foreach (Book book in group)
                {
                    Console.WriteLine($"Title: {book.title}");
                }
                Console.WriteLine();
            }
        }
    }
}