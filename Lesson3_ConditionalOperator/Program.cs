namespace Lesson3_ConditionalOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Conditional operators and loops ***** \n\n");

            /*
                Create a program that will start with declaration of two constants (X and Y) 
                and will count the sum of all numbers between these constants. 
                If they are equal then sum should be one of them
             
             */
            const int X = 10;
            const int Y = 12;
            PrintSumResult(X, Y);

            const int A = 5;
            const int B = 2;
            PrintSumResult(A, B);

            const int C = 10;
            const int D = 10;
            PrintSumResult(C, D);


            /*
                Extra:
                Read values of X and Y from the console. 
                If output is invalid - write to console Invalid input and exit the program.
             */

            Console.WriteLine();
            Console.WriteLine("Enter first whole number:");
            int firstNumber;

            if(!int.TryParse(Console.ReadLine(), out firstNumber))
            {
                Console.WriteLine("Invalid input");
                Thread.Sleep(1500);
                return;
            }

            Console.WriteLine("Enter second whole number:");
            int secondNumber;

            if (!int.TryParse(Console.ReadLine(), out secondNumber))
            {
                Console.WriteLine("Invalid input");
                Thread.Sleep(1500);
                return; 
            }

            PrintSumResult(firstNumber, secondNumber);
            Console.ReadLine();
        }

        private static string CalculateSumBetweenMumbers(int a, int b)
        {
            int startNumber;
            int endNumber;
            int sum = 0;
            string sumStr = "Sum = ";

            if (a == b)
            {
                return sumStr + a;
            }
            else if (a < b)
            {
                startNumber = a;
                endNumber = b;
            }
            else
            {
                startNumber = b;
                endNumber = a;
            }


            for (int i = startNumber; i <= endNumber; i++)
            {
                sum += i;
                sumStr += i;

                if (i < endNumber)
                {
                    sumStr += "+";
                }
            }

            return sumStr + " = " + sum;
        }

        private static void PrintSumResult(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"First number = {firstNumber}");
            Console.WriteLine($"Second number = {secondNumber}");
            Console.WriteLine(CalculateSumBetweenMumbers(firstNumber, secondNumber));
            Console.WriteLine();
        }
    }
}