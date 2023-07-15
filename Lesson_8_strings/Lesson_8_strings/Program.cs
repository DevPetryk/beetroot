namespace Lesson_8_strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Strings *****");

            // Strings compare
            string str0 = "Hello";
            string str1 = "World";
            string str2 = "World";
            Console.WriteLine($"String {str0} and {str1} is equal: {CustomCompare(str0, str1)} \r\n");
            Console.WriteLine($"String {str1} and {str2} is aqual: {CustomCompare(str1, str2)} \r\n");

            // String analyze
            string str3 = "Lorem, ipsum 777!!!";
            var resultAnalyze = CustomAnalyze(str3);
            foreach (KeyValuePair<string, int> ra in resultAnalyze)
            {
                Console.WriteLine(ra.Key + ": " + ra.Value);
            }

            // String Sort
            var str4 = "File System Info";
            Console.WriteLine($"CustomSort result from str {str4} to {CustomSort(str4)}");

            // String Duplicate
            var str5 = "Hello and hi";
            var duplicatesArr = CustomDuplicate(str5);
            string.Join(", ", duplicatesArr);
            Console.WriteLine($"Duplicates in string \"{str5}\" is: [ {string.Join(",", duplicatesArr)}]");
        }

        static bool CustomCompare(string firstStr, string secondStr)
        {
            if (firstStr.Length != secondStr.Length)
            {
                return false;
            }

            for (var i = 0; i < firstStr.Length; i++)
            {
                if (firstStr[i] != secondStr[i])
                {
                    return false;
                }
            }

            return true;
        }

        static Dictionary<string, int> CustomAnalyze (string str)
        {
            var analyzeResult = new Dictionary<string, int>()
            {
                ["letters"] = 0,
                ["digits"] = 0,
                ["special"] = 0
            };

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    analyzeResult["letters"]++;
                }
                else if (char.IsDigit(str[i]))
                {
                    analyzeResult["digits"]++;
                }
                else
                {
                    analyzeResult["special"]++;
                }
            }

            return analyzeResult;
        }
        static string CustomSort(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
        
        static char[] CustomDuplicate(string str)
        {
            string lowerStr = str.ToLower();
            string duplicates = "";
            int count;

            for (var i = 0; i < lowerStr.Length; i++)
            {
                if (duplicates.Contains(lowerStr[i]))
                {
                    continue;
                }

                count = 0;

                for (var j = 0; j < lowerStr.Length; j++)
                {
                    if (lowerStr[i] == lowerStr[j])
                    {
                        count++;
                    }

                    if(count > 1)
                    {
                        break;
                    }
                }

                if (count > 1 && !duplicates.Contains(lowerStr[i]))
                {
                    duplicates += lowerStr[i];
                }
            }

            return duplicates.ToCharArray();
        }

    }
}