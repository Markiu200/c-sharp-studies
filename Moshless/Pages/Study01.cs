using Bogus;
using intermediate;
using NspKprint;
using System.Collections;

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

    internal static class Study01
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



            // Going through versions of .NET and what are the possibilites - reading about them and leaving here links and notes.
            // No examples here, but it is good to know that these things exists and where to look for info about them..
            /** Tuples **/
            // Basically a way to have more data in one variable. These are mutable, unlike tuples in Python.
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
            //
            /** Span<T> **/
            // How to manipulate thing in memory without making copies of it (something like that).
            // https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-2-1
            // Nick Chapsas - What is Span in C# and why you should be using it 
            // https://www.youtube.com/watch?v=FM5dpxJMULY
            // https://stackoverflow.com/questions/47321691/what-is-the-difference-between-spant-and-memoryt-in-c-sharp-7-2
            //
            /** Why immutability? **/
            // Zoran Horvat - Immutable Design: Why You Should Care
            // https://www.youtube.com/watch?v=jjf5nEmDjaE
            //
            /** ref struct **/
            // struct that can be allocated only on stack.
            // Greg Kalapos - ref structs in C# 7.2 - .NET Concept of the Week - Episode 16
            // https://www.youtube.com/watch?v=IPxOxPfAg4s
            //
            /** Ranges and Indices (Index) **/
            // https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#ranges-and-indices
            //
            /** Unsafe code, pointer types, and function pointers **/
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/unsafe-code#function-pointers
            // https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-9
            // dispose / yield / iterators
            //
            /** Named and Optional Arguments **/
            // Like in Python, keyword arguments are a thing - (variable: value)
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
            //
            /** Pattern matching **/
            // "is" 
            // https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
            //
            /** Generic math **/
            // https://learn.microsoft.com/en-us/dotnet/standard/generics/math
            //
            /** "new" switch staritng C# 8 - switch expression **/
            // returns whatever it was evaluated for, looks more like lambda.
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
            // https://justjoin.it/blog/nowy-switch-w-c-8-0-jak-dziala-property-pattern
            //
            /** [list] Patterns **/
            // For comparing arrays to patterns
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#list-patterns
            //
            /** Primary constructor **/
            // Adding a primary constructor to a class prevents the compiler from declaring an implicit parameterless constructor.
            // https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#primary-constructors
            //
            /** COM **/
            // https://learn.microsoft.com/en-us/windows/win32/com/component-object-model--com--portal
            //
            /** Factory pattern **/
            // https://www.youtube.com/watch?v=SLEu6rNdJj0






            /*
             *  Iterators - old examples from C# 2.0, and new from 8.0
             */
            // You cannot use access modifiers on Enumerator related methods, they default to public.
            // New version of enumerators do not use "yield".

            Kprint.Title("Iterators (old):");
            foreach (int number in SomeNumbers())
            {
                Console.Write(number.ToString() + " ");
            }
            // Output: 3 5 8

            Console.WriteLine(Environment.NewLine);

            foreach (int number in EvenSequence(5, 18))
            {
                Console.Write(number.ToString() + " ");
            }
            // Output: 6 8 10 12 14 16 18

            Console.WriteLine(Environment.NewLine);

            DaysOfTheWeek days = new DaysOfTheWeek();
            foreach (string day in days)
            {
                Console.Write(day + " ");
            }
            // Output: Sun Mon Tue Wed Thu Fri Sat

            // NEW ENUMERATION
            // https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=net-8.0
            Console.WriteLine(Environment.NewLine);
            Kprint.Title("Iterators (new):");
            Person[] peopleArray = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.firstName + " " + p.lastName);
        }

        // OLD ENUMERATION
        public static System.Collections.IEnumerable SomeNumbers()
        {
            yield return 3;
            yield return 5;
            yield return 8;
        }

        // OLD ENUMERATION
        public static System.Collections.Generic.IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.
            for (int number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        // OLD ENUMERATION
        public class DaysOfTheWeek : IEnumerable
        {
            private string[] days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

            IEnumerator IEnumerable.GetEnumerator()
            {
                for (int index = 0; index < days.Length; index++)
                {
                    // Yield each day of the week.
                    yield return days[index];
                }
            }
        }

        // NEW ENUMERATION
        // Simple business object.
        public class Person
        {
            public Person(string fName, string lName)
            {
                this.firstName = fName;
                this.lastName = lName;
            }

            public string firstName;
            public string lastName;
        }

        // NEW ENUMERATION
        // Collection of Person objects. This class
        // implements IEnumerable so that it can be used
        // with ForEach syntax
        public class People : IEnumerable
        {
            private Person[] _people;
            public People(Person[] pArray)
            {
                _people = new Person[pArray.Length];

                for (int i = 0; i < pArray.Length; i++)
                {
                    _people[i] = pArray[i];
                }
            }

            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public PeopleEnum GetEnumerator()
            {
                return new PeopleEnum(_people);
            }
        }

        // NEW ENUMERATION
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=net-8.0
        // When you implement IEnumerable, you must also implement IEnumerator.
        public class PeopleEnum : IEnumerator
        {
            public Person[] _people;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public PeopleEnum(Person[] list)
            {
                _people = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _people.Length);
            }

            // The Reset method is provided for COM interoperability and does not need to be fully implemented;
            // instead, the implementer can throw a NotSupportedException.
            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Person Current
            {
                get
                {
                    try
                    {
                        return _people[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
