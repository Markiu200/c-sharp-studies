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

            // Experiment with .NET framework built-in delegate - Func<>.
            var kasmokDoer = new DealWithKasmok();
            var kasmokActions = new ActionsOnKasmoks();

            Func<BetterKasmok, int> kasmokHandler = kasmokActions.TakeItsRaspberries;
            kasmokHandler += kasmokActions.TakeMoreRaspberries;

            // it looks somewhat strange, but it seems that Delegate will run both methods one after another
            // replacing first return of 12 with second return of 22, and finally only 22 is being returned and summed up.
            // https://dev.to/moe23/c-9-delegate-action-and-func-13d7
            // "if we call multiple methods inside the func it will only return the last value, it will execute all of the methods but
            // the return will be from only the last method called."

            int sum = kasmokDoer.DealWithRaspberries(testKasmok1, kasmokHandler);
            Console.WriteLine($"Collected: {sum}");

            // Final word - when to use delegate, and when to use interface (by Mosh, by MSDN:
            // Use delegate when:
            // * personal preference,
            // * An eventing design pattern is used,
            // * The caller doesn't need to access other properties or methods on the object implementing the method.
        }
    }
}
