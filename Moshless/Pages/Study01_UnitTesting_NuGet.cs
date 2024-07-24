using Bogus;
using NspKprint;
using System.Security.Cryptography;

namespace Moshless.Pages
{
    public class Product
    {
        public string name="";
        public double price=0;
        public string color="";
    }

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
             *  Tuples
             */
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
        }
    }
}
