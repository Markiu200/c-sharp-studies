using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace exercises_068
{
    internal class Exercises_068
    {
        /* Universal methods */
        private static List<int>? signIntSeparator(string? input, char sign)
        {
            // Null or WhiteSpace scenario
            if (String.IsNullOrWhiteSpace(input)) return null;

            // Whitespace fix
            input = input.Trim();

            // Split string by '-'
            string[] numbers = input.Split(sign);

            // Get the numbers
            List<int> actualNumbers = new();
            foreach (string number in numbers)
            {
                // Skip "no values"
                if (number.Trim().Length == 0) continue;

                // Try to parse whatever there is. Stop at non-parsables
                int get = 0;
                if (int.TryParse(number, out get))
                {
                    actualNumbers.Add(get);
                }
                else
                {
                    return null;
                }
            }
            return actualNumbers;
        }

        /// <summary>
        /// 1- Write a program and ask the user to enter a few numbers separated by a hyphen. 
        /// Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9" 
        /// or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".
        /// </summary>
        public static void Exercise01()
        {
            Console.Write("Enter a series of numbers separated by \"-\", eg. \"1-2-3\": ");
            Console.WriteLine(Exercise01_Body(Console.ReadLine()));
        }
        private static string Exercise01_Body(string? input)
        {
            // Parse received string
            List<int>? actualNumbers = signIntSeparator(input, '-');

            if (actualNumbers is null) return "";

            // Check for consecutiveness
            // Assuming at this point we have valid list of actual numbers
            for (int i=0; i<actualNumbers.Count-1; i++)
            {
                if (actualNumbers[i+1] != actualNumbers[i] - 1 &&
                    actualNumbers[i + 1] != actualNumbers[i] + 1)
                {
                    return "Not Consecutive";
                } 
            }
            return "Consecutive";

        }
        public static void Exercise01_Test()
        {
            string?[] tests =
            {
                // Expected inputs
                "1-2-3-4", "Consecutive",
                "9-8-7-6", "Consecutive",
                "1-3-2-4", "Not Consecutive",
                "1", "Consecutive",
                // IsNullOrWhiteSpace
                "", "",
                " ", "",
                null!, "",
                // Wrong formatting
                "1-2-3-", "Consecutive",
                "--1-2-3", "Consecutive",
                "1--2-3", "Consecutive",
                " 1-2-3", "Consecutive",
                "1-2-3 ", "Consecutive",
                "-1-2-3", "Consecutive",
                "1-2-3-", "Consecutive",
                " - - -1-2", "Consecutive",
                // Wrong kind of inputs
                "a-b-c", "",
                "abc", ""
            };

            // Loop through tests
            Console.WriteLine("Testing Exercises_086.exercise01 (consecutiveness):");
            bool[] results = new bool[tests.Length/2];
            for (int i=0,bi=0; i<tests.Length; i+=2,bi++)
            {
                string resultString = Exercise01_Body(tests[i]!);
                results[bi] = (resultString == tests[i + 1]!) ? true : false;
                Console.WriteLine($"Test {(tests[i] is null ? "null" : $"\"{tests[i]}\"")} " +
                    $"should be \"{tests[i + 1]}\", got \"{resultString}\" " +
                    $"{(results[bi] ? "OK" : "FAIL")}");
            }

            // Print results
            Console.WriteLine($"\nSuccessful tests: {results.Where(c => c).Count()}\n" +
                $"Failed tests    : {results.Where(c => !c).Count()}");
        }

        /// <summary>
        /// 2- Write a program and ask the user to enter a few numbers separated by a hyphen. 
        /// If the user simply presses Enter, without supplying an input, exit immediately; 
        /// otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console. 
        /// </summary>
        public static void Exercise02()
        {
            Console.Write("Enter a series of numbers separated by \"-\", eg. \"1-2-3\": ");
            Console.WriteLine(Exercise02_Body(Console.ReadLine()));
        }
        private static string Exercise02_Body(string? input)
        {
            // Parse received string
            List<int>? actualNumbers = signIntSeparator(input, '-');

            // List is considered to not have duplicates if it's broken or has no elements
            if (actualNumbers is null) return "";

            // Check for duplicates
            // Assuming at this point we have valid list of actual numbers
            for (int i = 0; i < actualNumbers.Count - 1; i++)
            {
                for (int j = i+1; j < actualNumbers.Count; j++)
                {
                    if (actualNumbers[i] == actualNumbers[j]) return "Duplicate";
                }
            }
            return "";
        }
        public static void Exercise02_Test()
        {
            string?[] tests =
            {
                // Expected inputs
                "1-2-3-4", "",
                "9-8-7-6", "",
                "1-3-2-4", "",
                "1", "",
                "1-1", "Duplicate",
                "1-2-3-4-0-1", "Duplicate",
                // IsNullOrWhiteSpace
                "", "",
                " ", "",
                null!, "",
                // Wrong formatting
                "1-2-3-", "",
                "--1-2-3", "",
                "1--2-3", "",
                " 1-2-3", "",
                "1-2-3 ", "",
                "-1-2-3", "",
                "1-2-3-", "",
                " - - -1-2", "",
                "0- - -1-0- ", "Duplicate",
                // Wrong kind of inputs
                "a-b-c", "",
                "abc", ""
            };

            // Loop through tests
            Console.WriteLine("Testing Exercises_086.exercise02 (duplicates):");
            bool[] results = new bool[tests.Length / 2];
            for (int i = 0, bi = 0; i < tests.Length; i += 2, bi++)
            {
                string resultString = Exercise02_Body(tests[i]!);
                results[bi] = (resultString == tests[i + 1]!) ? true : false;
                Console.WriteLine($"Test {(tests[i] is null ? "null" : $"\"{tests[i]}\"")} " +
                    $"should be \"{tests[i + 1]}\", got \"{resultString}\" " +
                    $"{(results[bi] ? "OK" : "FAIL")}");
            }

            // Print results
            Console.WriteLine($"\nSuccessful tests: {results.Where(c => c).Count()}\n" +
                $"Failed tests    : {results.Where(c => !c).Count()}");
        }

        /// <summary>
        /// 3- Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00). 
        /// A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; 
        /// otherwise, display "Invalid Time". If the user doesn't provide any values, consider it as invalid time. 
        /// </summary>
        public static void Exercise03()
        {
            Console.Write("Enter time in format hh:MM : ");
            Console.WriteLine(Exercise03_Body(Console.ReadLine()));
        }
        public static string Exercise03_Body(string? input)
        {
            // Get null scenarios
            if (String.IsNullOrWhiteSpace(input)) return "Invalid Time";

            // Whitespace fix
            input = input.Trim();

            // Split string by ':' and check the amount
            string[] numbers = input.Split(':');
            if (numbers.Length != 2) return "Invalid Time";

            // Get the hour
            int get = -1;
            if (int.TryParse(numbers[0], out get))
            {
                // Check if hour is out of bounds
                if (get < 0 || get > 23) return "Invalid Time";
            } else { return "Invalid Time"; }

            // Get the minute
            // Minute must be two digits
            if (numbers[1].Length != 2) return "Invalid Time";

            // Minute must be a number in bounds of minuteness
            if (int.TryParse(numbers[1], out get))
            {
                // Check if minute is out of bounds
                if (get < 0 || get > 59) return "Invalid Time";
            }
            else { return "Invalid Time"; }

            return "OK";
        }
        public static void Exercise03_Test()
        {
            string?[] tests =
            {
                // Expected inputs
                "16:00", "OK",
                "00:00", "OK",
                "0:00", "OK",
                "6:00", "OK",
                "6:0", "Invalid Time",
                "25:00", "Invalid Time",
                "16:60", "Invalid Time",
                "16:70", "Invalid Time",
                "24:00", "Invalid Time", // should be 0:00 here
                // IsNullOrWhiteSpace
                "", "Invalid Time",
                " ", "Invalid Time",
                null!, "Invalid Time",
                // Wrong formatting
                " 16:00 ", "OK",
                "16: 00", "Invalid Time",
                "16:0 0", "Invalid Time",
                "16::00", "Invalid Time",
                "6:00:", "Invalid Time",
                // Wrong kind of inputs
                "a-b-c", "Invalid Time",
                "a:00", "Invalid Time"
            };

            // Loop through tests
            Console.WriteLine("Testing Exercises_086.exercise03 (time validation):");
            bool[] results = new bool[tests.Length / 2];
            for (int i = 0, bi = 0; i < tests.Length; i += 2, bi++)
            {
                string resultString = Exercise03_Body(tests[i]!);
                results[bi] = (resultString == tests[i + 1]!) ? true : false;
                Console.WriteLine($"Test {(tests[i] is null ? "null" : $"\"{tests[i]}\"")} " +
                    $"should be \"{tests[i + 1]}\", got \"{resultString}\" " +
                    $"{(results[bi] ? "OK" : "FAIL")}");
            }

            // Print results
            Console.WriteLine($"\nSuccessful tests: {results.Where(c => c).Count()}\n" +
                $"Failed tests    : {results.Where(c => !c).Count()}");
        }

        /// <summary>
        /// 4- Write a program and ask the user to enter a few words separated by a space. 
        /// Use the words to create a variable name with PascalCase. For example, 
        /// if the user types: "number of students", display "NumberOfStudents". 
        /// Make sure that the program is not dependent on the input. 
        /// So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents". 
        /// </summary>
        public static void Exercise04()
        {
            Console.WriteLine("Enter a few words: ");
            Console.WriteLine(Exercise04_Body(Console.ReadLine()));
        }
        public static string Exercise04_Body(string? input)
        {
            // Get null scenarios
            if (String.IsNullOrWhiteSpace(input)) return "";

            char[] result = new char[input.Length]; int index = 0;
            bool wasWhitespace = true; int resultLength = 0;

            foreach (char symbol in input)
            {
                // Symbols
                if (char.IsWhiteSpace(symbol) || !char.IsLetterOrDigit(symbol)) 
                { 
                    wasWhitespace = true; continue; 
                }
                if (char.IsDigit(symbol)) 
                { 
                    result[index++] = symbol; resultLength++;
                    wasWhitespace = true; continue; 
                }
                // Letter
                if (char.IsLetter(symbol)) 
                {
                    if (wasWhitespace) 
                    {
                        result[index++] = char.ToUpper(symbol);
                    } 
                    else 
                    { 
                        result[index++] = char.ToLower(symbol);
                    }
                    wasWhitespace = false; resultLength++;
                }
            }
            // Make resulting array of desired length
            char[] final = new char[resultLength];
            Array.Copy(result, final, resultLength);
            return new string(final);
        }
        public static void Exercise04_Test()
        {
            string?[] tests =
            {
                // Expected inputs
                "a", "A",
                "a a", "AA",
                "aAaAaA3aAaA", "Aaaaaa3Aaaa",
                "aAaAaA3aAaA ", "Aaaaaa3Aaaa",
                "3", "3",
                "3aes5rap", "3Aes5Rap",
                "A", "A",
                "AMANT", "Amant",
                "AMERICAN pie 6", "AmericanPie6",
                // IsNullOrWhiteSpace
                "", "",
                " ", "",
                null!, "",
                // Symbols and whitespaces
                "a,a", "AA",
                " a. 3- e", "A3E",
                " small Dragon .", "SmallDragon",
                "a    a", "AA"
            };

            // Loop through tests
            Console.WriteLine("Testing Exercises_086.exercise04 (pascal case):");
            bool[] results = new bool[tests.Length / 2];
            for (int i = 0, bi = 0; i < tests.Length; i += 2, bi++)
            {
                string resultString = Exercise04_Body(tests[i]!);
                results[bi] = (resultString.Equals(tests[i + 1]!)) ? true : false;
                Console.WriteLine($"Test {(tests[i] is null ? "null" : $"\"{tests[i]}\"")} " +
                    $"should be \"{tests[i + 1]}\", got \"{resultString}\" " +
                    $"{(results[bi] ? "OK" : "FAIL")}");
            }

            // Print results
            Console.WriteLine($"\nSuccessful tests: {results.Where(c => c).Count()}\n" +
                $"Failed tests    : {results.Where(c => !c).Count()}");
        }

        /// <summary>
        /// 5- Write a program and ask the user to enter an English word. 
        /// Count the number of vowels (a, e, o, u, i) in the word. 
        /// So, if the user enters "inadequate", the program should display 6 on the console.
        /// </summary>
        public static void Exercise05()
        {
            Console.WriteLine("Enter one word in which vowel will be count: ");
            Console.WriteLine(Exercise05_Body(Console.ReadLine()));
        }
        private static int Exercise05_Body(string? input)
        {
            // Get null scenarios
            if (String.IsNullOrWhiteSpace(input)) return 0;

            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
            int count = 0;
            foreach (char vowel in input)
            {
                if (vowels.Contains(char.ToLower(vowel))) count++;
            }
            return count;
        }
        public static void Exercise05_Test()
        {
            Dictionary<string, int> tests = new Dictionary<string, int>();
            // Expected inputs
            tests.Add("a", 1);
            tests.Add("A", 1);
            tests.Add("AMANT", 2);
            // IsNullOrWhiteSpace
            tests.Add("", 0);
            tests.Add(" ", 0);
            // Symbols and whitespaces
            tests.Add("a,a", 2);
            tests.Add(" iya 3- eg", 4);
            tests.Add("a a", 2);
            tests.Add("3", 0);
            tests.Add("AbcE1", 2);

            // Loop through tests
            Console.WriteLine("Testing Exercises_086.exercise05 (vowel count):");
            bool[] results = new bool[tests.Count + 1];
            int index = 0; int resultNum = 0;
            foreach (KeyValuePair<string,int> kvp in tests)
            {
                resultNum = Exercise05_Body(kvp.Key);
                results[index] = resultNum == kvp.Value;
                Console.WriteLine(
                    $"Test \"{kvp.Key}\" " +
                    $"should be {kvp.Value}, got {resultNum} " +
                    $"{(results[index] ? "OK" : "FAIL")}"
                );
                index++;
            }
            // Test for null
            resultNum = Exercise05_Body(null!);
            results[index] = resultNum == 0;
            Console.WriteLine(
                $"Test null " +
                $"should be 0, got {resultNum} " +
                $"{(results[index] ? "OK" : "FAIL")}"
            );

            // Print results
            Console.WriteLine($"\nSuccessful tests: {results.Where(c => c).Count()}\n" +
                $"Failed tests    : {results.Where(c => !c).Count()}");
        }
    }
}
