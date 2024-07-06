using NspKprint;
using System.Collections;

namespace intermediate.Study02
{
    internal class Study02
    {
        public static void Run()
        {
            // Create example list for kasmoks downcasting and upcasting. 
            List<BetterKasmok> betterKasmokList = new List<BetterKasmok>();
            betterKasmokList.Add(new BetterKasmok("Kasmok", new DateTime(1992, 12, 21)));
            // This is possible, because ForestKasmok can be (and will be) upcasted to BetterKasmok.
            betterKasmokList.Add(new ForestKasmok("Piskocz", new DateTime(2000, 4, 28)));

            // Downcasting example.
            Kprint.FTitle("Downcasting example:");
            foreach (var kasmok in betterKasmokList)
            {
                Console.Write(kasmok);
                // "is" keyword can be used to compare if given class is another class.
                // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast
                if (kasmok is ForestKasmok)
                {
                    Console.Write(". That's a forest kasmok!");
                    // Downcasting BetterKasmok to Forestkasmok (because child class is "under" parent, I guess?)
                    // "as" keyword will make sure if this casting is valid (instead of)
                    // ForestKasmok fkasmok = (ForestKasmok)kasmok
                    // If casting is not possible (eg. objects are not related), null is given, for which is the next check. 
                    ForestKasmok? fkasmok = kasmok as ForestKasmok;
                    if (fkasmok is not null)
                    {
                        Console.Write(" ");
                        fkasmok.HideUnderTheShroom();
                    }
                }
                else
                {
                    Console.WriteLine();
                }
            }

            // Validation by property logics example
            // 
            // Unhandled exception. System.ArgumentException: bithdate (Parameter 'Birthdate cannot be from the future.')
            // betterKasmokList.Find(x => x.Name == "Piskocz").FixBirthdate(new DateTime(2050, 2, 2));

            // Downcasting example refactored. 
            Kprint.Title("Downcasting example (refactored):");
            foreach (var kasmok in betterKasmokList)
            {
                Console.Write(kasmok);
                ForestKasmok? fkasmok = kasmok as ForestKasmok;
                if (fkasmok is not null)
                {
                    Console.Write(". That's a forest kasmok! ");
                    // This method is unique for ForestKasmok class, this is why it must be casted to this class
                    // and not directly called as "kasmok.HideUnderTheShroom()". To do this, BetterKasmok would need 
                    // to have this method as well either set or not as "virtual".
                    fkasmok.HideUnderTheShroom();
                }
                else
                {
                    Console.WriteLine();
                }
            }

            // Upcasting example. 
            Kprint.Title("Upcasting example:");
            // We know for sure that 
            BetterKasmok upcastedKasmok = betterKasmokList[1];
            Console.WriteLine("betterKasmokList[1] is {0}, however it cannot hide under the shroom due to being BetterKasmok at the moment.", upcastedKasmok.Name);
            // Error	CS1061	'BetterKasmok' does not contain a definition for 'HideUnderTheShroom' and no accessible extension method 'HideUnderTheShroom'
            // accepting a first argument of type 'BetterKasmok' could be found (are you missing a using directive or an assembly reference?)
            // upcastedKasmok.HideUnderTheShroom();
            //
            // Even though "upcastedKasmok" and "betterKasmokList[1] are referencing the same object,
            // the _view_ of upcastedKasmok is limited to what BetterKasmok can comprehend. 

            // Boxing and unboxing example.
            Kprint.Title("Boxing and unboxing example:");
            Console.WriteLine("Nothing to see here...");
            // Boxing is when you make primitive or struct into an object. It must be "boxed" and
            // put in heap so it can be later referenced like any other object. Unboxing is reverse of that. 
            int toBeBoxed = 10;
            object boxedInt = toBeBoxed;
            // or "object boxedInt = 10;"
            // Unboxing:
            int unboxed = (int)boxedInt;
            // Boxing and unboxing take extra computional effort, try to avoid it when possible.
            //
            // ArrayList() is a list which is not "type safe", you can put there different kind of objects or even primitives.
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);  // because ArrayList takes "objects", boxing will happen here!
            arrayList.Add(boxedInt);
            arrayList.Add(betterKasmokList[0]);
            //
            // List<t> is type safe. Whatever type you declare, will be what will be stored. Therefore no boxing or unboxing will be done
            // (if you set it to <int>, onlt <int> will be allowed into the list, it won't take "object" as argument, but "int".

            // Override examples - new, noNew, override,
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
            Kprint.Title("Override examples - new, noNew, override. Note that all of these are BetterKasmok type with value of BetterKasmok and ForestKasmok:");
            Console.WriteLine("'noNew' example");
            betterKasmokList[0].MakeSound_noNew();
            betterKasmokList[1].MakeSound_noNew();
            Console.WriteLine("'new' example");
            betterKasmokList[0].MakeSound_new();
            betterKasmokList[1].MakeSound_new();
            Console.WriteLine("'override' example");
            betterKasmokList[0].MakeSound_override();
            betterKasmokList[1].MakeSound_override();
            Kprint.FTitle("Same examples, however BetterKasmok is BetterKasmok, and ForestKasmok is ForestKasmok:");
            BetterKasmok tempBetterKasmok = betterKasmokList[0];
            ForestKasmok tempForestKasmok = (ForestKasmok)betterKasmokList[1];
            Console.WriteLine("'noNew' example");
            tempBetterKasmok.MakeSound_noNew();
            tempForestKasmok.MakeSound_noNew();
            Console.WriteLine("'new' example");
            tempBetterKasmok.MakeSound_new();
            tempForestKasmok.MakeSound_new();
            Console.WriteLine("'override' example");
            tempBetterKasmok.MakeSound_override();
            tempForestKasmok.MakeSound_override();

            // Abstract class example
            Kprint.Title("Abstract class example:");
            Console.WriteLine($"Habitat of BetterKasmok is {tempBetterKasmok.habitat!.DescribeHabitat()}");
            Console.WriteLine($"Habitat of ForestKasmok is {tempForestKasmok.habitat!.DescribeHabitat()}");

            // Playing with interfaces
            Kprint.Title("Playing with interfaces:");
            Habitat habitat = new Habitat();
            ToyMan toyMan = new ToyMan();
            //
            // This is where I toy around, results are bit lower
            // habitat field is now of type "Animal"
            //habitat.SetHabitant(toyMan);
            habitat.MakeHabitantEatAndSleep();
            habitat.SetHabitant(tempBetterKasmok);
            habitat.MakeHabitantEatAndSleep();
            habitat.SetHabitant(tempForestKasmok);
            habitat.MakeHabitantEatAndSleep();

            /*
             * Results are (to some degree saved as commits):
             * 
             * Having IHabitant as field type, passing all three habitants worked.
             * Having Animal as field type, ToyMan throws error, but kasmoks worked
               Make note how neither BetterKasmok nor ForestKasmok implement these methods. They are inherited
             */
        }
    }
}
