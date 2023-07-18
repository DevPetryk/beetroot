using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace Lesson9_Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Lesson Text: Phonebook*****\r\n");
            /*
                I use library Newtonsoft.Json for serialize object to json string
                For search in phonebook I use Binary Search algorithm 
             */

            var pathToPhoneBook = "phone_book.json";

            // Create file phone book and add data
            if (!File.Exists(pathToPhoneBook))
            {
                CreatePhoneBook(pathToPhoneBook);
            }

            // Search in phonebook
            SearchInPhoneBook(pathToPhoneBook);
        }

        static List<PhoneBookEntry> FillDataForPhoneBook()
        {
            return new List<PhoneBookEntry>()
            {
                new PhoneBookEntry { firstName = "John", lastName = "Doe", phoneNumber = "1234567890" },
                new PhoneBookEntry { firstName = "Jane", lastName = "Smith", phoneNumber = "0987654321" },
                new PhoneBookEntry { firstName = "David", lastName = "Johnson", phoneNumber = "9876543210" },
                new PhoneBookEntry { firstName = "Emily", lastName = "Williams", phoneNumber = "0123456789" },
                new PhoneBookEntry { firstName = "Michael", lastName = "Brown", phoneNumber = "5678901234" },
                new PhoneBookEntry { firstName = "Olivia", lastName = "Avil", phoneNumber = "5432109876" },
                new PhoneBookEntry { firstName = "Daniel", lastName = "Taylor", phoneNumber = "4567890123" },
                new PhoneBookEntry { firstName = "Sophia", lastName = "Davis", phoneNumber = "7890123456" },
                new PhoneBookEntry { firstName = "Bob", lastName = "Miller", phoneNumber = "3210987654" },
                new PhoneBookEntry { firstName = "Alie", lastName = "Wilson", phoneNumber = "2345678901" }
            };
        }

        static void CreatePhoneBook(string pathToPhoneBook)
        { 
            var phoneBook = new PhoneBook
            {
                Entries = FillDataForPhoneBook()
            };

            var jsonSerializePhoneBook = JsonConvert.SerializeObject(phoneBook, Formatting.Indented);

            File.WriteAllText(pathToPhoneBook, jsonSerializePhoneBook);
        }

        static void SearchInPhoneBook(string pathToPhoneBook)
        {
            if (File.Exists(pathToPhoneBook))
            {
                var phoneBookData = File.ReadAllText(pathToPhoneBook);
                var phoneBook = JsonConvert.DeserializeObject<PhoneBook>(phoneBookData);

                if (phoneBook?.Entries != null)
                {
                    Console.WriteLine("Ente First Name, Last Name or Phone for search (like: Avil, Emily, 2345678901):");
                    var searchPhrase = Console.ReadLine();

                    var searchedIndex = CustomBinarySearch(phoneBook.Entries, searchPhrase ?? "none");

                    if (searchedIndex != -1)
                    {
                        Console.WriteLine("Found person:");
                        Console.WriteLine($"First name: {phoneBook.Entries[searchedIndex].firstName}");
                        Console.WriteLine($"Last name: {phoneBook.Entries[searchedIndex].lastName}");
                        Console.WriteLine($"Phone number: {phoneBook.Entries[searchedIndex].phoneNumber}");
                    }
                    else
                    {
                        Console.WriteLine("Person not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Persons data not found in phonebook!");
                }
            }
            else {
                Console.WriteLine("Phonebook not found!");
            }
        }

        static int CustomBinarySearch(List<PhoneBookEntry> phoneBookData, string searchPhrase)
        {
        
            var properties = typeof(PhoneBookEntry).GetProperties();

            foreach (var property in properties)
            {
                phoneBookData.Sort((x, y) => string.Compare(property.GetValue(x)?.ToString(), property.GetValue(y)?.ToString()));
                var leftSide = 0;
                var rightSide = phoneBookData.Count - 1;
                while (leftSide <= rightSide)
                {
                    var middle = leftSide + (rightSide - leftSide) / 2;
                    var propertyValue = property.GetValue(phoneBookData[middle])?.ToString();

                    if (propertyValue == null)
                    {
                        continue;
                    }

                    if (propertyValue.ToLower() == searchPhrase.ToLower())
                    {
                        return middle;
                    }
                    else if (string.Compare(propertyValue, searchPhrase) < 0)
                    {
                        leftSide = middle + 1;
                    }
                    else
                    {
                        rightSide = middle - 1;
                    }
                }
            }

            return -1;
        }
    }
}