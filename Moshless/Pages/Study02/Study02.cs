using NspKprint;

namespace Moshless.Pages.Study02
{
    internal class Study02
    {
        public static void Run()
        {
            Kprint.FTitle("Class / struct difference test:");
            /*
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/common-type-system
             * Testing struct behavior, knowing that struct is implicitly derived from class.
             * For a value type, you should always override Equals, because tests for equality that rely on reflection offer poor performance.
             */
            TestClass testClass = new TestClass { text = "testClass", number = 1 };
            TestStruct testStruct = new TestStruct { text = "testStruct", number = 1 };
            TestClasses.ClassChangeName(testClass);
            TestClasses.StructChangeName(testStruct);
            Console.WriteLine($"Change in class type: {testClass.text}");
            Console.WriteLine($"Change in struct type: {testStruct.text}");



            Kprint.Title("Anonymous type / Tuple / ValueTuple example:");



            /*
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/choosing-between-anonymous-and-tuple
             * The ValueTuple types are mutable, whereas Tuple are read-only. Anonymous types can be used in expression trees, while tuples cannot.
             * Tuple = class, ValueTuple = struct
             */
            var dates = new[]
            {
                DateTime.UtcNow.AddHours(-1),
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
            };
            foreach (var anonymous in
                         dates.Select(
                             date => new { Formatted = $"{date:MMM dd, yyyy hh:mm zzz}", date.Ticks }))
            {
                Console.WriteLine($"Ticks: {anonymous.Ticks}, formatted: {anonymous.Formatted}");
            }
            foreach (var tuple in
            dates.Select(
                date => new Tuple<string, long>($"{date:MMM dd, yyyy hh:mm zzz}", date.Ticks)))
            {
                Console.WriteLine($"Ticks: {tuple.Item2}, formatted: {tuple.Item1}");
            }
            foreach (var (formatted, ticks) in
            dates.Select(
                date => (Formatted: $"{date:MMM dd, yyyy at hh:mm zzz}", date.Ticks)))
            {
                Console.WriteLine($"Ticks: {ticks}, formatted: {formatted}");
            }



            Kprint.Title("ToSting() override:");



            /*
             * https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-object-tostring
             * Also formatting:
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/formatting-types
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
             */
            Console.WriteLine(testClass.ToString());
            Console.WriteLine(testStruct.ToString());
        } 
    }
}
