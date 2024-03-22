using System.Text.Json;
using MM202ExamUnit3.Utils;
using static MM202ExamUnit3.Utils.Constants;
using static MM202ExamUnit3.Utils.ApiService;

namespace MM202ExamUnit3
{
    public class Task2
    {
        public static int[] FlattenArray(object[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return [];
            }

            var head = arr[0];
            var tail = arr.Skip(1).ToArray();

            if (head is int intValue)
            {
                return new[] { intValue }.Concat(FlattenArray(tail)).ToArray();
            }
            else if (head is object[] nestedArray)
            {
                return FlattenArray(nestedArray).Concat(FlattenArray(tail)).ToArray();
            }
            else
            {
                return FlattenArray(tail);
            }
        }

        private static int[] FlattenJsonArray(JsonDocument doc)
        {
            int[] array = ProcessJsonElement(doc.RootElement);
            object[] objectArray = array.Cast<object>().ToArray();
            return Task2.FlattenArray(objectArray);
        }

        private static int[] ProcessJsonElement(JsonElement element)
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

        public static async Task FlattenArrayWithJsonFile(string jsonFilePath)
        {
            try
            {
                Console.WriteLine(ReadJSON);

                string jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                JsonDocument doc = JsonDocument.Parse(jsonContent);

                Console.WriteLine(JaggedArray, doc.RootElement);

                int[] flattenedArray = FlattenJsonArray(doc);
                string arrayToWrite = string.Join(", ", flattenedArray);
                Console.WriteLine(FlattenedArray, arrayToWrite);
            }
            catch (Exception e)
            {
                Print.PrintErrorMessage(e.Message);
            }
        }

        public static async Task FlattenArrayWithAPICall(string APIUrl)
        {
            ApiService apiService = new ApiService(new HttpClient());
            try
            {
                Console.WriteLine(CallAPI);

                HttpResponseMessage response = await apiService.GetApiResponse(APIUrl);
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonDocument doc = apiService.ParseJsonString(responseBody);

                Console.WriteLine(JaggedArray, doc.RootElement);

                int[] flattenedArray = FlattenJsonArray(doc);
                string arrayToWrite = string.Join(", ", flattenedArray);
                Console.WriteLine(FlattenedArray, arrayToWrite);
            }
            catch (HttpRequestException e)
            {
                Print.PrintErrorMessage(e.Message);
            }
        }
    }
}