using System.Security.Cryptography;

namespace Lesson_7_Array
{
    enum OrderBy
    {
        ASC,
        DESC
    }

    enum SortAlgorithmType
    {
        Bubble,
        Insertion,
        Selection
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Arrays ***** \r\n");
            var arrSelection = new[] { 3, 5, 7, 4, 1, 2, 6 };
            Console.WriteLine("Source array");
            PrintArray(arrSelection);

            Console.WriteLine("--- Select Sort ---");
            Sort(arrSelection, SortAlgorithmType.Selection);
            Console.WriteLine("Sorted array by ASC");
            PrintArray(arrSelection);
            Console.WriteLine("Sorted array by DESC");
            Sort(arrSelection, SortAlgorithmType.Selection, OrderBy.DESC);
            PrintArray(arrSelection);

            Console.WriteLine("--- Bubble sort ---");
            var arrBubble = new[] { 3, 5, 7, 4, 1, 2, 6 };
            Console.WriteLine("Sorted array by ASC");
            Sort(arrBubble, SortAlgorithmType.Bubble);
            PrintArray(arrBubble);
            Console.WriteLine("Sorted array by DESC");
            Sort(arrBubble, SortAlgorithmType.Bubble, OrderBy.DESC);
            PrintArray(arrBubble);

            Console.WriteLine("--- Insertion sort ---");
            var arrInsertion = new[] { 3, 5, 7, 4, 1, 2, 6 };
            Console.WriteLine("Sorted array by ASC");
            Sort(arrInsertion, SortAlgorithmType.Insertion);
            PrintArray(arrInsertion);
            Console.WriteLine("Sorted array by DESC");
            Sort(arrInsertion, SortAlgorithmType.Insertion, OrderBy.DESC);
            PrintArray(arrInsertion);
        }

        static private void PrintArray(int[] arr)
        {
            string arrStr = "";
            for (int i = 0; i < arr.Length; i++)
            {
               arrStr += (arr[i] + " ");
            }

            Console.WriteLine(arrStr.TrimEnd());
            Console.WriteLine();
        }

        static private void SelectionSort(int[] arr, OrderBy orderBy)
        {
            int arrLength = arr.Length;
            for (int i = 0; i < arrLength - 1; i++)
            {
                int minIndex = i;
                bool isAscending = orderBy == OrderBy.ASC;

                for (int j = i + 1; j < arrLength; j++)
                {
                    if ((isAscending && arr[j] < arr[minIndex]) || (!isAscending && arr[j] >  arr[minIndex]))
                    {
                        minIndex = j;
                    }
                }

                int tempElement = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = tempElement;
            }
        }

        static private void BubbleSort(int[] arr, OrderBy orderBy)
        {
            int n = arr.Length;
            bool checkIfSorted;
            bool isAscending = orderBy == OrderBy.ASC;

            for (int i = 0; i < n - 1; i++)
            {
                checkIfSorted = true;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if ((isAscending && arr[j] > arr[j + 1]) || (!isAscending && arr[j] < arr[j + 1]))
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        checkIfSorted = false;
                    }
                }

                if (checkIfSorted)
                {
                    break;
                }
            }
        }

        static private void InsertionSort(int[] arr, OrderBy orderBy)
        {
            bool isAscending = orderBy == OrderBy.ASC;
            for (int i = 1; i < arr.Length; i++)
            {
                int element = arr[i];
                int j = i - 1;

      
                while (j >= 0 && ((isAscending && arr[j] > element) || (!isAscending && arr[j] < element)))
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = element;
            }
        }

        static private void Sort(int[] arr, SortAlgorithmType sortAlgorithmType, OrderBy orderBy = OrderBy.ASC)
        {
            switch(sortAlgorithmType)
            {
                case SortAlgorithmType.Selection:
                    SelectionSort(arr, orderBy);
                    break;
                case SortAlgorithmType.Bubble:
                    BubbleSort(arr, orderBy);
                    break;
                case SortAlgorithmType.Insertion:
                    InsertionSort(arr, orderBy);
                    break;
            }
        }
    }
}