using NspKprint;

namespace intermediate.Study04
{
    internal class Study04
    {
        public static void Run()
        {
            /*
             * **** Events ****
             */

            // Events exercises:
            Kprint.FTitle("Events");
            // Events are basically using Delegates as properties.
            // You have a object that will be "publisher" - one who emits event,
            // and objects that will subscribe to that - "subscriber".
            //
            // What happens here is publisher have public property that is a delegate,
            // and subscribers add their own methods to that publicly accessible delegate.
            // 
            // When publisher "emits" event, it simply runs all methods saved in delegate.
            //
            // Here publisher will be BetterKasmok, and subscribers will be ForestKasmok. Check
            // their .cs for more comments actually.
            //
            // Steps are (for publisher)
            // 1 - Define a delegate
            // 2 - Define an event based on that delegate
            // 3 - Raise the event
            var whiteSmo = new BetterKasmok("Czompek", new DateTime(1992, 12, 21));  // Publisher
            var forestSmoList = new List<ForestKasmok>()  // List of Subcribers
            {
                new ForestKasmok("Melon", new DateTime(1999, 4, 1)),
                new ForestKasmok("Spoon", new DateTime(2001, 1, 28)),
                new ForestKasmok("Fork", new DateTime(1996, 11, 12))
            };
            var individualForestSmo = new ForestKasmok("Nicpon", new DateTime(2004, 10, 11));

            foreach (var forestSmo in forestSmoList)
            {
                // Gor each subscriber add their method (literally) to publisher's delegate.
                whiteSmo.LightsOut += forestSmo.OnLightsOutEventHandler;
            }

            // Emit the event.
            whiteSmo.TurnTheLightsOff();



            /*
             * **** Extension Methods ****
             */

            // Allows to add methods to existing class without
            // * changing it's source code, or
            // * creating a new class that inherits from it.
            //
            // For example, we'd like to String class to do something new. 
            // It's sealed class so we cannot inherit from it, and it's build-in default C# type, 
            // so we probably shouldn't mess around with it directly.
            string post = "This is supposed to be a very long blog post!";

            // We want to generate summary of that post - string that contains up to set amount of words of post.
            // Brand new method could be created that exists for itself, but here we want String itself to do it.
            // post.Shorten(5);
            // So after actuallu implementing that extension method in Extensions.cs:
            Kprint.Title("Extension methods:");
            Console.WriteLine(post);
            Console.WriteLine(post.Shorten(5));

            // It is recommended by MSDN to avoid creating extension methods if possible, and do it only when necessary.
            // Reason of that is, if the method we "extended" is actually introduced in C# later, it will override our extension.
            // Instance methods have priority over static methods.
            //
            // You'll find that you'll be using already existing extensions methods, rather than defining own ones.



            /*
             * **** LINQ ****
             */

            // Stands for Language Integrated Query, and allows to query objects (in code). Following can be queried:
            // * objects in memory, eg. collections (LINQ to Objects)
            // * databases (LINQ to Entities)
            // * XML (LINQ to XML)
            // * ADO.NET Data Sets (LINQ to Data Sets)
            forestSmoList.Add(new ForestKasmok("Grzib", new DateTime(1999, 7, 7)));
            forestSmoList.Add(new ForestKasmok("Pomponik", new DateTime(2001, 5, 18)));
            forestSmoList.Add(new ForestKasmok("Sznureczek", new DateTime(1996, 12, 8)));

            // Since LINQ is mostly (if not only) extension methods, it is used by invoking methods.
            Kprint.Title("LINQ:");
            // Where() takes predicate, so Lambda Expression will suffice. Where is more connected to LINQ,
            // whereas for Lambda Expressions "FindAll" would be used (for Lists).
            Console.WriteLine("\tWhere():");
            var kasmoksOf1999 = forestSmoList.Where(kasmok => kasmok.Birthdate.Year == 1999);
            foreach (var kasmok in kasmoksOf1999)
                Console.WriteLine(kasmok);

            // LINQ is about methods, predicates are made with eg. Lambda Expressions (or just methods).
            //
            // Power of LINQ shows in ability to link these methods together.
            // Convention is to have each method in it's own line (to improve readibility).
            var kasmoksOlderThan23ByName = forestSmoList
                .Where(kasmok => kasmok.Age > 23)
                .OrderBy(kasmok => kasmok.Name)
                .Select(kasmok => kasmok.Name);  // Select allows to pick particular field of an object

            Console.WriteLine("\tOlder than 23 and sorted by name (LINQ Query Expressions):");
            foreach (var kasmok in kasmoksOlderThan23ByName)
                Console.WriteLine(kasmok);

            // That kind of linking is called "LINQ Query Extensions".
            // Alternative to that is "LINQ Query Operators", and looks somewhat like SQL query (but with different order of operations):
            var kasmoksAfter23ByName =
                from kasmok in forestSmoList
                where kasmok.Age > 23
                orderby kasmok.Name
                select kasmok.Name;
            //
            Console.WriteLine("\tOlder than 23 and sorted by name (LINQ Query Operators):");
            foreach (var kasmok in kasmoksAfter23ByName)
                Console.WriteLine(kasmok);
            // It must start with "from" and end with "select" though. Moreover, not all methods are covered with LINQ keywords,
            // so it's more flexible and robust to use "LINQ Query Expressions". Keywords internally traslate to methods anyway. 

            // There's a lot of LINQ methods to be found on Google. Mentioned on Mosh course were:
            // .Single()            - returns a single object from collection. Will throw error if nothing was found, or more than one is found,
            // .SingleOrDefault()   - like above, but instead error will return default value (null for objects),
            // .First(), .FirstOrDefault(), Last(), LastOrDefault()     - self explanatory,
            // .Skip(<int>)         - for paging data, skips <int> first elements,
            // .Take(<int>)         - for paging data, returns <int> elements from here (eg. after .Skip()),
            // .Count()             - exactly as expected,
            // .Max(), .Min()       - as expected. Predicate allows to select by which field "max" or "min" should be calculated,
            // .Sum()               - sums elements (by field pointed in predicate),
            // .Mean(), .Average()  - as expected (by field pointed in predicate).



            /*
             * **** Nullable types ****
             */
            // Allows value types to have "null". Might be useful when working with databases, and in many more scenarios.
            // Error	CS0037	Cannot convert null to 'bool' because it is a non-nullable value type
            // bool isBool = null;

            // Nullable is built-in class Nullable:
            Nullable<bool> isBool = null;

            // This makes such variable to have three additional method and properties:
            // GetValueOrDefault() ; HasValue ; Value
            Kprint.Title("Nullable types:");
            Console.WriteLine("isBool.GetValueOrDefault(): " + isBool.GetValueOrDefault());
            Console.WriteLine("isBool.HasValue: " + isBool.HasValue);
            try
            {
                Console.WriteLine("isBool.Value: " + isBool.Value);
            }
            catch (InvalidOperationException) { Console.WriteLine("isBool.Value caused error because there's no value (null)"); }

            // Shorthand to Nullable<type> is just using "?"
            bool? isBool2 = null;
            //
            // For types that can be null anyway (like "object"), "?" will just suppress compiler warning - 
            // it declares that you as programmer are aware of possibility of that being null and you will take care of it somehow.

            // "Null Coalescing Operator" - "??" is shorthand for ternary operator (cond ? true : false) for checking for null:
            // isNull ?? newValue
            // So if given value is not null then take that value, otherwise take "newValue".
            DateTime? time1 = null;
            DateTime time2 = time1 ?? DateTime.Today;
            //
            Console.WriteLine("\tNull Coalescing Operator:");
            Console.WriteLine(time2);
        }
    }
}
