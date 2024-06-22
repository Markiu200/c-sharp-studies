using CSharp1Exercises.ArraysAndLists;
using System.ComponentModel.DataAnnotations;
namespace exercises_056
{
    internal class Exercises_056
    {
        /// <summary>
        /// 1- When you post a message on Facebook, depending on the number of people who like your post, Facebook displays 
        /// different information.
        /// * If no one likes your post, it doesn't display anything.
        /// * If only one person likes your post, it displays: [Friend's Name] likes your post.
        /// * If two people like your post, it displays: [Friend 1] and[Friend 2] like your post.
        /// * If more than two people like your post, it displays: [Friend 1], [Friend 2] and[Number of Other People] others like your post.
        /// Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying a name). 
        /// Depending on the number of names provided, display a message based on the above pattern.
        /// </summary>
        public static void Exercise01()
        {
            Console.WriteLine("Exercise 1: Facebook");
            Console.Write("Enter usernames one by one (random words really) ");
            List<string> listOfNames = new List<string>();
            string? input = Console.ReadLine();
            while (input != "")
            {
                if (input is not null) listOfNames.Add(input);
                input = Console.ReadLine();
            }
            Exercise01_Body(listOfNames);
        }
        public static void Exercise01_Test()
        {
            List<string> longList = new List<string>();
            for (int i=97; i<=109; i++) { longList.Add(Convert.ToString((char)i)); }

            List<string>[] listOfInputs = new List<string>[]
            {
                new List<string> {null!},
                new List<string> {"oneName"},
                new List<string> {"oneName", "secondName"},
                longList
            };
            Exercise01_Body(null!);
            foreach (List<string> i in listOfInputs)
            {
                Exercise01_Body(i);
            } 
        }
        private static void Exercise01_Body(List<string> listOfNames)
        {
            try
            {
                int count = listOfNames.Count;
                if (count == 1)
                {
                    Console.WriteLine($"{listOfNames[0]} likes your post");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"{listOfNames[0]} and {listOfNames[1]} like your post");
                }
                else if (count > 2)
                {
                    Console.WriteLine($"{listOfNames[0]} and {listOfNames[1]} and {count - 2} others like your post");
                }
            }
            catch (Exception e) { Console.WriteLine(e.GetType()); }
        }

        /// <summary>
        /// 2- Write a program and ask the user to enter their name. 
        /// Use an array to reverse the name and then store the result in a new string. 
        /// Display the reversed name on the console.
        /// </summary>
        public static void Exercise02()
        {
            Console.WriteLine("Exercise 2: Reverse");
            Console.Write("Enter your name good sir or madam: ");
            string? name = Console.ReadLine();
            if (name is null) { return; }
            Exercise02_Body(name);
        }
        public static void Exercise02_Test()
        {
            string[] listOfInputs = { "Good", null!, "a", "sada", " ", "Adam", "Kasmok" };
            foreach (string n in listOfInputs)
            {
                Exercise02_Body(n);
            }
        }
        private static void Exercise02_Body(string name)
        {
            if (name is null) { return; }
            char[] nameChar = name.ToCharArray();
            Array.Reverse(nameChar);
            Console.WriteLine(nameChar);
        }

        /// <summary>
        /// 3- Write a program and ask the user to enter 5 numbers. 
        /// If a number has been previously entered, display an error message and ask the user to re-try. 
        /// Once the user successfully enters 5 unique numbers, sort them and display the result on the console.
        /// </summary>
        public static void Exercise03()
        {
            Console.WriteLine("Exercise 3: Sorted unique numbers");
            int unique = 0;
            int[] numbers = new int[5];
            Console.Write("Type number: ");
            do
            {
                int selected = 0;
                bool duplicate = true;
                if (int.TryParse(Console.ReadLine(), out selected))
                {
                    foreach (int i in numbers)
                    {
                        if (i == selected)
                        {
                            Console.Write("Try again: ");
                            break;
                        }
                        duplicate = false;
                    }
                }
                if (!duplicate) { 
                    numbers[unique++] = selected;
                    Console.Write("Type number: ");
                }
            } while (unique < 5);

            Array.Sort(numbers);
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
        }

        /// <summary>
        /// 4- Write a program and ask the user to continuously enter a number or type "Quit" to exit. 
        /// The list of numbers may include duplicates. Display the unique numbers that the user has entered.
        /// </summary>
        public static void Exercise04()
        {
            Console.WriteLine("Exercise 4: Unique numbers");
            List<int> numbers = new List<int>();
            // Get all the inputs
            string? input = "";
            while (input != "quit")
            {
                int inted = 0;
                input = Console.ReadLine();
                if (int.TryParse(input, out inted) && input is not null)
                {
                    numbers.Add(inted);
                }
            }

            // Remove duplicates
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i+1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j]) {
                        numbers.Remove(numbers[i--]);
                        break;
                    }
                }
            }

            // Display unique
            foreach(int i in numbers) {  Console.WriteLine(i + " "); }
        }

        /// <summary>
        /// 5- Write a program and ask the user to supply a list of comma separated numbers 
        /// (e.g 5, 1, 9, 2, 10). If the list is empty or includes less than 5 numbers, 
        /// display "Invalid List" and ask the user to re-try; otherwise, display the 3 smallest numbers in the list. 
        /// </summary>
        public static void Exercise05()
        {
            Console.WriteLine("Exercise 5: Three smallest numbers");
            Console.WriteLine("Type more than 4 number separated with comas");
            // Get user input
            string? userInput = Console.ReadLine();
            if (userInput == null) return;
            // Make it into array of ints
            string[] splitted = userInput.Replace(" ", "").Split(',');
            int[] ints = new int[splitted.Length];
            int slot = 0; int got = 0;
            foreach (string s in splitted)
            {
                if (int.TryParse(s, out got))
                {
                    ints[slot++] = got;
                }
            }
            // Check for size
            if (ints.Length < 5)
            {
                Console.WriteLine("You did too short.");
                return;
            }
            // Get three smallest ones
            int[] smallest = new int[3];
            for (int i=0; i<3; i++)
            {
                smallest[i] = ints.Min();
                ints[Array.IndexOf(ints, smallest[i])] = ints.Max();
            }
            // Print it
            foreach (int i in smallest) { Console.Write(i+" "); }
        }

        public static void PrintAll()
        {
            Console.WriteLine(); Exercise01();
            Console.WriteLine("\n"); Exercise02();
            Console.WriteLine("\n"); Exercise03();
            Console.WriteLine("\n"); Exercise04();
            Console.WriteLine("\n"); Exercise05();
        }

        public static void PrintAllTests()
        {
            Console.WriteLine(); Exercise01_Test();
            Console.WriteLine("\n"); Exercise02_Test();
            Console.WriteLine("\n"); Exercise03();
            Console.WriteLine("\n"); Exercise04();
            Console.WriteLine("\n"); Exercise05();
        }

        public static void PrintSome()
        {
            return;
        }

        public static void PrintSome(int[] select)
        {
            foreach (int i in select)
            {
                if (i < 1 || i > 5) continue;
                switch (i)
                {
                    case 1: Console.WriteLine(); Exercise01(); break;
                    case 2: Console.WriteLine("\n"); Exercise02(); break;
                    case 3: Console.WriteLine("\n"); Exercise03(); break;
                    case 4: Console.WriteLine("\n"); Exercise04(); break;
                    case 5: Console.WriteLine("\n"); Exercise05(); break;
                }
            }
        }
    }
}
