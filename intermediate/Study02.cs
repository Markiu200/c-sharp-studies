using NspKprint;

namespace intermediate.Study02
{
    internal class Study02
    {
        public static void Run()
        {
            // Create example list for kasmoks downcasting and upcasting. 
            List<BetterKasmok> betterKasmokList = new List<BetterKasmok>();
            betterKasmokList.Add(new BetterKasmok("Kasmok", new DateTime(1992, 12, 21)));
            betterKasmokList.Add(new ForestKasmok("Piskocz", new DateTime(2000, 4, 28)));

            // Downcasting example.
            Kprint.FTitle("Downcasting example:");
            foreach (var kasmok in betterKasmokList)
            {
                Console.Write(kasmok);
                if (kasmok is ForestKasmok)
                {
                    Console.Write(". That's a Forest Kasmok!");
                    // Downcasting BetterKasmok to Forestkasmok (because child class is "under" parent, I guess?)
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
        }
    }
}
