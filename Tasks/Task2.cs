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
    }
}