using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Calling the API...");

            HttpResponseMessage response = await GetApiResponse("https://crismo-turquoisejaguar.web.val.run/arrayI");
            JsonDocument doc = await ParseJsonResponse(response);

            Console.WriteLine($"Jagged array: {doc.RootElement}");

            int[] flattenedArray = FlattenJsonArray(doc);
            string arrayToWrite = string.Join(", ", flattenedArray);
            Console.WriteLine($"Flattened array: [{arrayToWrite}]");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }

    static async Task<HttpResponseMessage> GetApiResponse(string url)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return response;
    }

    static async Task<JsonDocument> ParseJsonResponse(HttpResponseMessage response)
    {
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(responseBody);
    }

    static int[] FlattenJsonArray(JsonDocument doc)
    {
        int[] array = ProcessJsonElement(doc.RootElement);
        object[] objectArray = array.Cast<object>().ToArray();
        return MM202ExamUnit3.FlattenThoseNumbers.FlattenArray(objectArray);
    }

    static int[] ProcessJsonElement(JsonElement element)
    {
        var result = new List<int>();

        if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement childElement in element.EnumerateArray())
            {
                result.AddRange(ProcessJsonElement(childElement));
            }
        }
        else if (element.ValueKind == JsonValueKind.Number)
        {
            result.Add(element.GetInt32());
        }

        return result.ToArray();
    }
}