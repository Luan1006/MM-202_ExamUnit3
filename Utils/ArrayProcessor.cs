using System.Text.Json;

namespace MM202ExamUnit3.Utils
{
    public class ArrayProcessor
    {
        public int[] FlattenJsonArray(JsonDocument doc)
        {
            int[] array = ProcessJsonElement(doc.RootElement);
            object[] objectArray = array.Cast<object>().ToArray();
            return Task2.FlattenArray(objectArray);
        }

        private int[] ProcessJsonElement(JsonElement element)
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
}