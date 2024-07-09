// This extension is defined in our namespace, however Mosh mentiones that it might be good idea to define extension in namespace 
// that the extended class is defined. For String, perhaps it would be better to define it in System namespace.
namespace intermediate
{
    // Convention is to use "public static" class - name is "<classYoUWantToExtend>Extensions".
    internal static class StringExtensions
    {
        // Extended method must be static as well, and have argument of "this <extendedClass> <name>".
        // This first argument passes in whatever calls the method, in this case, instance of the String class (in Program.cs)
        // (which would be natural in non-static classes, but needs to be wxplicitly pointed in static classes).
        //
        // Combination of having static method in static class, where first argument is instance of an object of that class,
        // C# compiler allows to use that class on an object (even though it's static method on static class),
        // so "post.Shorten(5)" is allowed. 
        public static string Shorten(this string post, int numberOfWords)
        {
            // Implementation that is needed.
            if (numberOfWords == 0)
                return "";

            var words = post.Split(" ");

            if (words.Length <= numberOfWords)
                return post;

            // Fun note - Take() is an extension method to String[], made by Microsoft later into language development
            return string.Join(" ", words.Take(numberOfWords)) + "...";
        }
    }
}
