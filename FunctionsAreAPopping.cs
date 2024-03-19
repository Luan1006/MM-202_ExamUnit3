namespace MM202ExamUnit3
{
    class FunctionsAreAPopping
    {
        public static int SquareNumber(int number)
        {
            return number * number;
        }

        public static double MillimeterToInches(double millimeters)
        {
            if (millimeters < 0) { return 0; }
            return millimeters / 25.4;
        }

        public static double RootNumber(double num)
        {
            if (0 == num) { return 0; }
            double n = (num / 2) + 1;  
            double n1 = (n + (num / n)) / 2;
            while (n1 < n)
            {
                n = n1;
                n1 = (n + (num / n)) / 2;
            }
            return n;
        } 
    }
}