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

            // Experiment with own declared delegate.
            var kasmokDoer = new DealWithKasmok();
            var kasmokActions = new ActionsOnKasmoks();

            // This looks different and weird and does not behave like anything else.
            // Instance of delegate is created here.
            //
            // It is kind of like a list now - list of methods we want to use (note how we didn't call (no "()") the method).
            // Methods must have same signature as defined delegate - in this case, return void and accept one BetterKasmok argument.
            //
            // Having that done, now we can use whatever action we want, and we're not limited to what framework got hardcoded
            //
            Console.WriteLine("\tOne call delegated:");
            DealWithKasmok.KasmokDoerHandler kasmokHandler = kasmokActions.Pet;
            kasmokDoer.DealWithIt(testKasmok1, kasmokHandler);
            //
            // kasmokHandler now derives from System.MulticastDelegate, which allows it to have multiple calls assigned. it's a class.
            // MulticastDelegate is derived from System.Delegate,
            // which consists of properties "Method" (points to method) and "Target" (points to class that has this method).
            // 
            // We can add more calls to that list by simply adding them:
            //
            kasmokDoer.DealWithIt(testKasmok1, kasmokHandler);
            Console.WriteLine("\tAdded one call to be delegated:");
            kasmokHandler += kasmokActions.Feed;
            kasmokDoer.DealWithIt(testKasmok1, kasmokHandler);
            //
            // We can also create our own methods and pass them to delegate, as long as their signature meet the requirement:
            //
            Console.WriteLine("\tAdded own defined call to be delegated:");
            kasmokHandler += Groom;
            kasmokDoer.DealWithIt(testKasmok1, kasmokHandler);
        }

        // Declare our own action on kasmoks
        static void Groom (BetterKasmok kasmok)
        {
            Console.WriteLine($"{kasmok.Name} kasmok groomed");
        }
    }
}
