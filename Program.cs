﻿using System.Text.Json;
using MM202ExamUnit3.Utils;

namespace MM202ExamUnit3
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static readonly ApiService apiService = new ApiService(client);
        static readonly ArrayProcessor arrayProcessor = new ArrayProcessor();

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
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            try
            {
                Console.WriteLine("Reading the JSON file...");

                string jsonFilePath = Path.Combine("ExampleFiles", "arrays.json");
                string jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                JsonDocument doc = JsonDocument.Parse(jsonContent);

                Console.WriteLine($"Jagged array:\n{doc.RootElement}");

                int[] flattenedArray = arrayProcessor.FlattenJsonArray(doc);
                string arrayToWrite = string.Join(", ", flattenedArray);
                Console.WriteLine($"Flattened array: [{arrayToWrite}]");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            Console.WriteLine("\nWelcome to the Binary Tree Traverser!\n");

            try
            {
                Console.WriteLine("Calling the API...");

                HttpResponseMessage response = await apiService.GetApiResponse(Constants.BSTAPIURL);
                string responseBody = await response.Content.ReadAsStringAsync();

                Task3 task3 = new Task3();

                Console.WriteLine($"Binary tree: {responseBody}");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                Task3.Node root = JsonSerializer.Deserialize<Task3.Node>(responseBody, options);

                Task3.TreeInfo treeInfo = task3.Traverse(root);

                Console.WriteLine($"Sum = {treeInfo.Sum}");
                Console.WriteLine($"Deepest level = {treeInfo.Depth}");
                Console.WriteLine($"Nodes = {treeInfo.Count}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}