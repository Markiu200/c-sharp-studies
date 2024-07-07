using NspKprint;

namespace intermediate.Study03
{
    internal class Study03
    {
        public static void Run()
        {
            // Simple testing of generics
            Kprint.FTitle("Testing simple generics:");
            var genTest1 = new GenericOneType<int>();
            genTest1.someField = 12;
            var genTest2 = new GenericOneType<BetterKasmok>();
            genTest2.someField = new BetterKasmok("Kasmok", new DateTime(1922, 2, 2));

            // With generic methods type is not specified in <> lika above - required type is just passed as an argument, 
            // and with that type is determined.
            Kprint.Title("Testing method-level generics:");
            var genTest3 = new GenericAtMethod();
            var testKasmok1 = new BetterKasmok("Kamok", new DateTime(2000, 9, 23));
            Console.WriteLine(genTest3.SomeMethod(testKasmok1, 3));

            // Testing multiple type generics
            Kprint.Title("Testing multiple type generics:");
            var genTest4 = new GenericsWithRestarints<BetterKasmok, BetterKasmok>();
            Console.WriteLine(genTest4.Compare(genTest2.someField, testKasmok1));

            // Playing with delegates
            // Experiments will be traced in commits.
            Kprint.Title("Playing with delegates:");

            var kasmokDoer = new DealWithKasmok();
            kasmokDoer.DealWithIt(testKasmok1);

        }
    }
}
