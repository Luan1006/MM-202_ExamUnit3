namespace MM202ExamUnit3.Utils
{
    public class Print
    {
        public static void PrintErrorMessage(string error)
        { 
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", error);
        }

        public static void PrintPauseMessage()
        {
            Console.WriteLine("\n\nLoading next task...");
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}