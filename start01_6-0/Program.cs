using study01;
using exercises_043;

namespace start01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tPrinting first part of studying C# - \"C# Basics for Beginners: Learn C# Fundamentals by Coding\":\n");
            Study01.Study01_go();

            Console.WriteLine("\n\tPrinting exercises \"043_exercises\":\n");
            Console.WriteLine("Exercise 1 (Range):\n");
            Exercises_043.Exercise01();
            Console.WriteLine("\nExercise 2 (Max):\n");
            Exercises_043.Exercise02();
            Console.WriteLine("\nExercise 3 (Portrait):\n");
            Exercises_043.Exercise03();
            Console.WriteLine("\nExercise 4 (Speed):\n");
            Exercises_043.Exercise04();

        }
    }
}
