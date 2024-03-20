namespace MM202ExamUnit3.Utils
{
    public class Print
    {
        public static void PrintErrorMessage(string error)
        { 
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", error);
        }
    }
}