namespace MM202ExamUnit3
{
    public class FlattenThoseNumbers
    {
        public static int[] FlattenArray(object[] arr)
        {
            List<int> result = new List<int>();

            foreach (var item in arr)
            {
                if (item is int intValue)
                {
                    result.Add(intValue);
                }
                else if (item is object[] nestedArray)
                {
                    foreach (var nestedItem in FlattenArray(nestedArray))
                    {
                        result.Add(nestedItem);
                    }
                }
            }

            return result.ToArray();
        }
    }
}