using System.Linq.Expressions;
using System.Text;

namespace exercises_049
{
    internal class Exercises_049
    {
        /// <summary>
        /// 1- Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. 
        /// Display the count on the console.
        /// </summary>
        public static void Exercise01()
        {
            StringBuilder listOfDivisibles = new StringBuilder();
            int countOfDivisibles = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    countOfDivisibles++;
                    listOfDivisibles.Append(" ");
                    listOfDivisibles.Append(i.ToString());
                }
            }
            if (countOfDivisibles != 0)
            {
                Console.WriteLine($"Number of divisible numbers: {countOfDivisibles}: {listOfDivisibles.ToString()}");
            }
            else
            {
                Console.WriteLine("No divisible numbers here.");
            }
        }

        /// <summary>
        /// 2- Write a program and continuously ask the user to enter a number or "ok" to exit. 
        /// Calculate the sum of all the previously entered numbers and display it on the console.
        /// </summary>
        public static void Exercise02()
        {
            string? userInput = "";
            float sum = 0.0f;
            float temp = 0.0f;
            try
            {
                do
                {
                    Console.Write("Type a number or type \"ok\" to end: ");

                    // https://www.reddit.com/r/csharp/comments/z5g07c/cs8600/
                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types
                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving
                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/nullable-reference-types
                    // what the hell
                    // Looks like "?" makes legal for a string to be "null", but it could be null anyway. You can do "string a = null" and it compiles. 
                    // It's just that compiler will issue a warning when it could be null, because it is concerned about your code validity.
                    // "!" on another hand, warns compiler that "null" is being passed and you know it, so it does not need to be worried about this. 
                    // (you'd put "!" at the end, eg: string userInput = Console.ReadLine()!;
                    userInput = Console.ReadLine();
                    if (userInput is not null && userInput == "ok")
                    {
                        Console.WriteLine("Summing up...");
                    }
                    else if (float.TryParse(userInput, out temp))
                    {
                        sum += temp;
                    }
                    else
                    {
                        Console.WriteLine("That couldn't be parsed as a number");
                    }
                } while (userInput is not null && userInput.ToLower() != "ok");
                Console.WriteLine($"The sum is {sum}");
            } catch (Exception e) { Console.WriteLine($"Something went horribly wrong: {e}"); }
        }

        /// <summary>
        /// 3- Write a program and ask the user to enter a number. 
        /// Compute the factorial of the number and print it on the console. For example, if the user enters 5, 
        /// the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
        /// </summary>
        public static void Exercise03()
        {
            int sum = 1;
            try
            {
                int userNumber = Convert.ToInt32(Console.ReadLine());
                if (userNumber < 0) { throw new FormatException(); }
                if (userNumber == 0)
                {
                    Console.WriteLine(sum);
                }
                else
                {
                    for (int i = 1; i <= userNumber; i++)
                    {
                        sum *= i;
                    }
                    Console.WriteLine(sum);
                }

            } catch (FormatException)
            {
                Console.WriteLine("That doesn't seem to be a proper number.");
            }
        }

        /// <summary>
        /// 4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. 
        /// If the user guesses the number, display “You won"; otherwise, display “You lost". 
        /// (To make sure the program is behaving correctly, you can display the secret number on the console first.)
        /// </summary>
        public static void Exercise04()
        {
            Random rnd = new Random();
            int pickedNumber = rnd.Next(1, 10);
            int chancesLeft = 4;
            int choosenNumber = 0;

            Console.WriteLine($"Picked: {pickedNumber}");

            while (chancesLeft > 0)
            {
                try
                {
                    if (int.TryParse(Console.ReadLine(), out choosenNumber))
                    {
                        if (choosenNumber != pickedNumber)
                        {
                            Console.Write("No... ");
                            chancesLeft--;
                        }
                        else
                        {
                            Console.WriteLine("You did it!");
                            break;
                        }
                    } 
                } catch (FormatException e) { Console.WriteLine($"Not a correct number. {e}"); }
            }
            if (chancesLeft == 0)
            {
                Console.WriteLine("You lost");
            }
            else
            {
                Console.WriteLine("You won");
            }
        }

        /// <summary>
        /// 5- Write a program and ask the user to enter a series of numbers separated by comma. 
        /// Find the maximum of the numbers and display it on the console. For example, 
        /// if the user enters “5, 3, 8, 1, 4", the program should display 8.
        /// </summary>
        public static void Exercise05()
        {
            Console.WriteLine("Enter list of integers separated with whitespace (and commas optionally)");
            string? userInput = Console.ReadLine();
            if (userInput == null) return;

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
            Console.WriteLine($"Max: {ints.Max()}");
        }

        /// <summary>
        /// Prints all exercises.
        /// </summary>
        public static void PrintAll()
        {
            Console.WriteLine("\tPrinting exercises \"049_exercises\":\n");
            Console.WriteLine("Exercise 1 (Divisible):\n");
            Exercise01();
            Console.WriteLine("\nExercise 2 (Sum):\n");
            Exercise02();
            Console.WriteLine("\nExercise 3 (Strong (!)):\n");
            Exercise03();
            Console.WriteLine("\nExercise 4 (Random number):\n");
            Exercise04();
            Console.WriteLine("\nExercise 5 (Max):\n");
            Exercise05();
        }
    }
}
