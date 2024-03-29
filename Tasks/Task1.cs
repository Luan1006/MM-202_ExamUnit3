using MM202ExamUnit3.Utils;

namespace MM202ExamUnit3
{
    class Task1
    {
        public static double SquareNumber(double number)
        {
            return number * number;
        }

        public static double MillimeterToInches(double millimeters)
        {
            if (millimeters < 0) throw new ArgumentException("Cannot convert negative millimeters to inches");
            return millimeters / 25.4;
        }

        public static double RootNumber(double number)
        {
            if (number < 0) throw new ArgumentException("Cannot calculate the square root of a negative number");
            if (number == 0) throw new ArgumentException("Cannot calculate the square root of zero");

            double guess = (number / 2) + 1;
            double refinedGuess = (guess + (number / guess)) / 2;

            while (refinedGuess < guess)
            {
                guess = refinedGuess;
                refinedGuess = (guess + (number / guess)) / 2;
            }

            return guess;
        }

        public static double CubedNumber(double number)
        {
            return number * number * number;
        }

        public static double AreaOfCircle(double radius)
        {
            if (radius < 0) throw new ArgumentException("Cannot calculate the area of a circle with a negative radius");
            return Constants.PI * (radius * radius);
        }

        public static string Greet(string name)
        {
            return $"Hello, {name}!";
        }
    }
}