using System.Text.Json;
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
            try
            {
                Console.Clear();
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
        }
    }
}