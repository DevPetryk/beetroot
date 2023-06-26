namespace Lesson2_DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Data types and variables *****");
            PrintMathFunctios();

            Console.WriteLine();

            /*
                Write to console how many days left to New Year and how many days passed from New Year. 
                Result in console should look like this:
                X days left to New Year
                Y days passed from New Year
            */

            DateTime currentDate = DateTime.Today;
            int daysLeftToNewYear = DaysLeftToNewYear(currentDate);
            int daysPassedFromNewYear = DaysPassedFromNewYear(currentDate);

            Console.WriteLine($"{daysLeftToNewYear} days left to New Year");
            Console.WriteLine($"{daysPassedFromNewYear} days passed from New Year");
        }

        private static void PrintMathFunctios()
        {
            // 1) -6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15
            int x = 5;
            double cubicPolynomialResult = (-6 * Math.Pow(x, 3)) + (5 * Math.Pow(x, 2)) - (10 * x) + 15;
            Console.WriteLine($"Cubic polynomial result is: {cubicPolynomialResult}");

            // 2) abs(x)*sin(x)
            double radians = 4.0;
            double sinResult = Math.Abs(radians) * Math.Sin(radians);
            Console.WriteLine($"Result for sinus of radians is: {sinResult}");

            // 3) 2*pi*x
            double radius = 7.0;
            double circumference = 2 * Math.PI * radians;
            Console.WriteLine($"Circumference is: {circumference}");

            // 4) max(x, y)
            int a = 10;
            int b = 15;
            Console.WriteLine($"Out of the numbers {a} and {b}, the largest is: {Math.Max(a, b)} ");

        }

        private static int DaysLeftToNewYear(DateTime currentDate)
        {
            DateTime lastDateOfYear = new DateTime(currentDate.Year, 12, 31);
            return (lastDateOfYear - currentDate).Days;
        }

        private static int DaysPassedFromNewYear(DateTime currentDate)
        {
            DateTime firstDateOfYear = new DateTime(currentDate.Year, 1, 1);
            return (currentDate - firstDateOfYear).Days;

        }
    }
}