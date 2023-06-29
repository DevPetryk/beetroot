namespace Lesson5_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Methods *****");
            Console.WriteLine();

            int a = 4;
            int b = 5;
            int c = 50;
            int d = 8;

            /*
                Method that will return max value among all the parameters
                … min value …
                Overload this methods with 3 and 4 parameters
             */
            Console.WriteLine($"Max parametr val from 2 parameters is: {GetMaxParametrValue(a, b) }");
            Console.WriteLine($"Max parametr val from 3 parameters is: {GetMaxParametrValue(a, b, c)}");
            Console.WriteLine($"Max parametr val from 4 parameters is: {GetMaxParametrValue(a, b, c, d)}");

            Console.WriteLine($"Min parametr val from 2 parameters is: {GetMinParametrValue(a, b) }");
            Console.WriteLine($"Min parametr val from 3 parameters is: {GetMinParametrValue(a, b, c)}");
            Console.WriteLine($"Min parametr val from 4 parameters is: {GetMinParametrValue(a, b, c, d)}");

            // Modernize Method use params keyword
            Console.WriteLine($"Max parametr val from 2 parameters is: {GetMax(a, b)}");
            Console.WriteLine($"Max parametr val from 3 parameters is: {GetMax(a, b, c)}");
            Console.WriteLine($"Max parametr val from 4 parameters is: {GetMax(a, b, c, d)}");

            Console.WriteLine($"Min parametr val from 2 parameters is: {GetMin(a, b)}");
            Console.WriteLine($"Min parametr val from 3 parameters is: {GetMin(a, b, c)}");
            Console.WriteLine($"Min parametr val from 4 parameters is: {GetMin(a, b, c, d)}");

            /*
               Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd, otherwise false, sum return as out parameter
            */
            bool isSummOdd = TrySumIfOdd(a, b, out int sum);
;           Console.WriteLine($"Sum is odd: {isSummOdd}. Sum = {sum}");
            isSummOdd = TrySumIfOdd(c, d, out int sum1);
            Console.WriteLine($"Sum is odd: {isSummOdd}. Sum = {sum1}");
        }

        private static int GetMaxParametrValue(int a, int b)
        {
            return Math.Max(a, b);
        }

        private static int GetMaxParametrValue(int a, int b, int c)
        {
            int firstMax = Math.Max(a, b);
            return Math.Max(firstMax, c);
        }

        private static int GetMaxParametrValue(int a, int b, int c, int d)
        {
            int firstMax = Math.Max(a, b);
            int secondMax = Math.Max(firstMax, c);
            return Math.Max(secondMax, d);
        }

        private static int GetMinParametrValue(int a, int b)
        {
            return Math.Min(a, b);
        }

        private static int GetMinParametrValue(int a, int b, int c)
        {
            int firstMin = Math.Min(a, b);
            return Math.Min(firstMin, c);
        }

        private static int GetMinParametrValue(int a, int b, int c, int d)
        {
            int firstMin = Math.Min(a, b);
            int secondMin = Math.Min(firstMin, c);
            return Math.Min(secondMin, d);
        }

        private static int GetMax(params int[] paramValues)
        {
            if (paramValues.Length == 0)
            {
                Console.WriteLine("Warning: Parametr is epmty!");
                return -1;
            }

            int max = paramValues[0];
            for (int i = 1; i < paramValues.Length; i++)
            {
                max = Math.Max(max, paramValues[i]);
            }

            return max;
        }

        private static int GetMin(params int[] paramValues)
        {
            if (paramValues.Length == 0)
            {
                Console.WriteLine("Warning: Parametr is epmty!");
                return -1;
            }

            int min = paramValues[0];
            for (int i = 1; i < paramValues.Length; i++)
            {
                min = Math.Max(min, paramValues[i]);
            }

            return min;
        }

        private static bool TrySumIfOdd(int a, int b, out int sum)
        {
            sum = a + b;

            return !(sum % 2 == 0);
        }
    }
}