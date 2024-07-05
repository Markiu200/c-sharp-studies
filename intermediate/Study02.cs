namespace intermediate.Study02
{
    internal class Study02
    {
        public static void Title(string title)
        {
            Console.WriteLine($"\n\n  ---- {title} ----");
        }

        public static void Run()
        {
            List<BetterKasmok> betterKasmokList = new List<BetterKasmok>();
            betterKasmokList.Add(new BetterKasmok("Kasmok", new DateTime(1992, 12, 21)));
            betterKasmokList.Add(new ForestKasmok("Piskocz", new DateTime(2000, 4, 28)));

            foreach (var kasmok in betterKasmokList)
            {
                Console.Write(kasmok);
                if (kasmok is ForestKasmok)
                {
                    Console.WriteLine(". That's a Forest Kasmok!");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            // Unhandled exception. System.ArgumentException: bithdate (Parameter 'Birthdate cannot be from the future.')
            // betterKasmokList.Find(x => x.Name == "Piskocz").FixBirthdate(new DateTime(2050, 2, 2));
        }
    }
}
