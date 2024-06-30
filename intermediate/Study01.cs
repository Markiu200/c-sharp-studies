using System.Drawing;
using System.Threading.Channels;

namespace intermediate.Study01
{
    internal class Study01
    {
        public static void Title(string title)
        {
            Console.WriteLine($"\n\n  ---- {title} ----");
        }

        public static void Run()
        {
            Study01.Title(@"Static and non-static constructors test:");
            Console.WriteLine("Hello, World! Creating an instance of Kasmok class...");
            var kasmok = new Kasmok("smok", "bialy", "duzy");
            Console.WriteLine(kasmok.ToString());

            Console.WriteLine();
            Console.WriteLine("Creating an instance of Kasmok class...");
            var kasmok2 = new Kasmok("smok", "niebieski", "duzy");
            Console.WriteLine("Make note how static initializer was not triggered second time.");

            Study01.Title(@"Finalizer test, might show nothing...:");
            kasmok2 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Study01.Title("\".ToString\" object override test:");
            var kasmok3 = new Kasmok("smok", "czerwony", "duzy");
            Console.WriteLine(kasmok3.ToString());

            Study01.Title("Object initializers:");
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
            // Exists so you don't need to create as many constructors to initialize different 
            // variation of fields in class.
            // This does not "replace" constructors. It's just a shortcut to set properties
            // (or public fields).
            Kasmok[] kasmoks = new Kasmok[]
            {
                // Object initializers will call parameterless constructor in this form.
                new Kasmok {Name = "Pisko", Color = "blue", Size = "smol"},
                new Kasmok {Name = "Pisko", Color = "blue"}, 
                new Kasmok {Color = "blue", Size = "smol"},
                new Kasmok {Age = 3},
                // You can specify both constructor and object initializer.
                new Kasmok ("Pisko", "czarny", "duzy") {Age = 2}
            };
            foreach (Kasmok smo in  kasmoks) Console.WriteLine(smo.ToString());
            kasmok3.Color = "ciemny";

            // Test for "param" keyword
            Study01.Title("\"param\" argument test:");
            Console.WriteLine("Kasmok, pisk that:");
            kasmok.PiskThat("pisk", "pisk", "piiiisk", "piisk", "piiiiiiisk", "pisk");

            // Test for "ref" keyword
            Study01.Title("\"ref\" argument test:");
            Console.WriteLine("\tWithout \"ref\":");
            Console.WriteLine($"Current amount of pisks: {kasmok.piskAmount}");
            kasmok.AddThePiskNoRef(kasmok.piskAmount);
            Console.WriteLine($"New amount of pisks: {kasmok.piskAmount}");
            Console.WriteLine("\tWith \"ref\":");
            Console.WriteLine($"Current amount of pisks: {kasmok.piskAmount}");
            kasmok.AddThePiskWithRef(ref kasmok.piskAmount);
            Console.WriteLine($"New amount of pisks: {kasmok.piskAmount}");

            // Test for "out" keyword
            Study01.Title("\"out\" argument test:");
            Console.WriteLine("\t\"out\" keyword test:");
            int piskAmountTimes2 = 2; 
            int piskAmountTimes8 = 8;
            kasmok.HowManyPisksTimesTwo(out piskAmountTimes2, out piskAmountTimes8);
            Console.WriteLine($"Amount of pisks times 2 and 8: {piskAmountTimes2}, {piskAmountTimes8}");

            // Test for "in" keyword
            // https://devblogs.microsoft.com/premier-developer/the-in-modifier-and-the-readonly-structs-in-c/

            // Test for "readonly" things
            Study01.Title("\"readonly\" test:");
            Console.WriteLine("Pebbles before doing things with ref-type readonly shennanigans:");
            kasmok.ListPebbles();
            Console.WriteLine();
            kasmok.AddPebble();
            Console.WriteLine("Pebbles after that:");
            kasmok.ListPebbles();
        }
    }
}
