using Bogus;
using intermediate;
using NspKprint;
using System.Security.Cryptography;

namespace Moshless.Pages.Study01
{
    public class Product
    {
        public string name = "";
        public double price = 0;
        public string color = "";
        public Product() { }
        public Product(string name, double price, string color)
        {
            this.name = name; this.price = price; this.color = color;
        }
        
    }

    // A record or a record class declares a reference type. The class keyword is optional,
    // but can add clarity for readers. A record struct declares a value type.
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
    // https://blog.ndepend.com/c-record-explained/
    // A C# record is a data-centric type that usually doesn’t contain behaviors.
    // C# 9 introduced the keyword record to quickly declare a class primarily designed for data representation.
    //
    // Value-based equality: semantic means that two C# record instances are considered equal when their data matches.
    record Item(string Name, double Price);
    /* Internally translates to:
    class Item(string Name, double Price) {
        public string Name { get; init; } = Name;
        public double Price { get; init; } = Price;
    }
    */
    // It also generates != and == operators, ToString overload, Equals method, GetHashCode orerride, and others (see YT video).

    internal static class Study01_UnitTesting_NuGet
    {
        public static void Run()
        {
            /*
             *  Tests
             */
    Kprint.FTitle("Tests:");
            // Everything is in CamelCaser and CamelCaserTest files, see there.
            Console.WriteLine("  [ -=  R=".CamelCase());



            /*
             *  Anonymous types (and Bogus)
             */
            Kprint.Title("Anonymous types:");
            // https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/anonymous-types
            // Allows to create a type without defining it first. It inherits of object and can be casted only as an object.
            // To create anonymous type, "var" must be used. 
            var anon = new { Name = "Whoisthis", Prize = 300.0 };
            //
            Console.WriteLine(anon);
            Console.WriteLine($"Anon properties: {anon.Name} and {anon.Prize}");

            // They can be used in LINQ queries, when objects are queried, in order to get an object with only selected properties. 
            // (also Bogus example)
            Console.WriteLine();
            var productBogus = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(o => o.name, f => f.Commerce.ProductName())
                .RuleFor(o => o.price, f => f.Random.Number(1, 20))
                .RuleFor(o => o.color, f => f.Commerce.Color());

            var products = new List<Product>();
            for (int i = 0; i < 10; i++)
                products.Add(productBogus.Generate());

            //var query = from prod in products select new { prod.name, prod.color };
            var query = products.Select(p => new { p.name, p.color });
            foreach (var p in query)
                Console.WriteLine(p.name + " :: " + p.color);

            // Anonymous types can be nested if they were previously declared.
            Console.WriteLine();
            var anon1 = new { anon1field = "anon1" };
            var anon2 = new { anon2filed = anon1 };
            Console.WriteLine(anon2);

            

            /*
             *  "with" expression
             */
            Kprint.Title("'with' expression:");
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression
            // Nondestructive mutation creates a new object with modified properties.
            // Can be used when left side is "record", "struct" or "anonymous" type.
            var c1 = new Item("Banana", 67);
            var c2 = c1 with { Name = "with statement" };
            Console.WriteLine($"{c1.Name} : {c1.Price} :: {c2.Name} : {c2.Price}");
            //
            // Allows to create "that object, but with this change" copy.



            /*
             *  Records (record type)
             */
            Kprint.Title("'record' type:");
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
            // https://blog.ndepend.com/c-record-explained/
            // https://www.youtube.com/watch?v=KFx9XHpoYV4
            var r1 = new Item("Item", 12);
            var r2 = new Item("Item", 12);
            Console.WriteLine($"Is r1 == r2 (even though they are different references)? : {r1 == r2}");
            var rk1 = new BetterKasmok("jeff", new DateTime(1900, 1, 1));
            var rk2 = new BetterKasmok("jeff", new DateTime(1900, 1, 1));
            Console.WriteLine($"Is rk1 == rk2 (even though they are different references)? : {rk1 == rk2}");
            //
            // Strings are kind of like records.
            // Also, "record" is one of types that can be used with "with" keyword (see above)
            // Caution: Developers expect records to be immutable. As a consequence, mutable records can lead to confusion and error-prone code.
            
            

            /*
             *  Tuples
             */
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
        }
    }
}
