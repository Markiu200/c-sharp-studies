namespace exercises_043
{
    internal class Exercises_043
    {
        /// <summary>
        /// 1- Write a program and ask the user to enter a number. The number should be between 1 to 10.
        /// If the user enters a valid number, display "Valid" on the console. Otherwise, display "Invalid".
        /// (This logic is used a lot in applications where values entered into input boxes need to be validated.)
        /// </summary>
        public static void Exercise01()
        {
            try
            {
                Console.WriteLine("Enter a number between and including 1 and 10: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine((number>=1 && number <=10) ? "Valid" : "Invalid");
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a number whatsoever...");
            }
            catch (Exception)
            {
                Console.WriteLine("What did you even do?");
            }
        }

        /// <summary>
        /// 2- Write a program which takes two numbers from the console and displays the maximum of the two.
        /// </summary
        public static void Exercise02()
        {
            try
            {
                Console.WriteLine("Enter a number: ");
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter another number: ");
                int number2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Math.Max(number1, number2));
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a number whatsoever...");
            }
            catch (Exception)
            {
                Console.WriteLine("What did you even do?");
            }
        }

        /// <summary>
        /// 3- Write a program and ask the user to enter the width and height of an image. 
        /// Then tell if the image is landscape or portrait. 
        /// </summary>
        public static void Exercise03()
        {
            try
            {
                Console.WriteLine("Enter the width: ");
                int width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the height: ");
                int height = Convert.ToInt32(Console.ReadLine());

                if (width == height) { Console.WriteLine("That's square"); }
                else if (width > height) { Console.WriteLine("This is a landscape"); }
                else { Console.WriteLine("This is a portrait"); }
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a number whatsoever...");
            }
            catch (Exception)
            {
                Console.WriteLine("What did you even do?");
            }
        }

        /// <summary>
        /// 4- Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, 
        /// sensors, etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. 
        /// Once set, the program asks for the speed of a car. If the user enters a value less than the speed limit, 
        /// program should display Ok on the console. If the value is above the speed limit, the program should calculate 
        /// the number of demerit points. For every 5km/hr above the speed limit, 1 demerit points should be incurred 
        /// and displayed on the console. If the number of demerit points is above 12, the program should display License Suspended.
        /// </summary>
        public static void Exercise04()
        {
            try
            {
                Console.WriteLine("Enter a speed limit: ");
                int limit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your speed: ");
                int speed = Convert.ToInt32(Console.ReadLine());

                int speedDifference = speed - limit;
                if (speedDifference < 0)
                {
                    Console.WriteLine("Ok");
                } 
                else
                {
                    speedDifference = speedDifference / 5;
                    Console.WriteLine(string.Format("You got {0} demerit points", speedDifference));
                    if (speedDifference > 12) { Console.WriteLine("License Suspended"); }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a number whatsoever...");
            }
            catch (Exception)
            {
                Console.WriteLine("What did you even do?");
            }
        }

        /// <summary>
        /// Prints all exercises.
        /// </summary>
        public static void PrintAll()
        {
            Console.WriteLine("\tPrinting exercises \"043_exercises\":\n");
            Console.WriteLine("Exercise 1 (Range):\n");
            Exercise01();
            Console.WriteLine("\nExercise 2 (Max):\n");
            Exercise02();
            Console.WriteLine("\nExercise 3 (Portrait):\n");
            Exercise03();
            Console.WriteLine("\nExercise 4 (Speed):\n");
            Exercise04();
        }
    }
}
