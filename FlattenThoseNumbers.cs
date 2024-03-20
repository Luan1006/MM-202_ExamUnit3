namespace MM202ExamUnit3
{
    public class FlattenThoseNumbers
    {
        public static int[] FlattenArray(object[] arr)
        {
            List<int> result = new List<int>();

            foreach (var item in arr)
            {
                if (item is int)
                {
                    result.Add((int)item);
                }
                else if (item is object[])
                {
                    result.AddRange(FlattenArray((object[])item));
                }
            }

            return result.ToArray();
        }
    }
}