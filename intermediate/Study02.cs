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
            // Even thougn "upcastedKasmok" and "betterKasmokList[1] are referencing the same object,
            // the _view_ of upcastedKasmok is limited to what BetterKasmok can comprehend. 

        }
    }
}
