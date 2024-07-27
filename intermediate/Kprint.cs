namespace NspKprint
{
    public class Kprint
    {
        /// <summary>
        /// Prints nicely formated title with two new lines on top. 
        /// </summary>
        /// <param name="title">Title to print</param>
        public static void Title(string title)
        {
            Console.WriteLine($"\n\n  ---- {title} ----");
        }
        public static void Title()
        {
            Console.WriteLine("\n\n  --------------");
        }

        /// <summary>
        /// Prints nicely formated title. 
        /// </summary>
        /// <param name="title">Title to print</param>
        public static void FTitle(string title)
        {
            Console.WriteLine($"  ---- {title} ----");
        }
        public static void FTitle()
        {
            Console.WriteLine("  --------------");
        }
    }
}
