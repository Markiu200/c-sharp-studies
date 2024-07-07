using intermediate;
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
            // Checkout previous commits for more detailed comments, as well as for handmade delegate
            Kprint.Title("Playing with delegates:");
            var kasmokDoer = new DealWithKasmok();
            var kasmokActions = new ActionsOnKasmoks();

            // This looks different and weird and does not behave like anything else.
            // Instance of delegate is created here.
            //
            // It is kind of like a list now - list of methods we want to use (note how we didn't call (no "()") the method).
            // Methods must have same signature as defined delegate - in this case, return void and accept one BetterKasmok argument.
            //
            // Basically allows to pass method as an argument + can make a list of such methods.
            //
            Console.WriteLine("\tOne call delegated:");
            Action<BetterKasmok> kasmokHandler = kasmokActions.Pet;
            kasmokDoer.DealWithIt(testKasmok1, kasmokHandler);
            // 
            // We can add more calls to that list by simply adding them:
            //
            Console.WriteLine("\tAdded one call to be delegated:");
            kasmokHandler += kasmokActions.Feed;
            kasmokDoer.DealWithIt(testKasmok1, kasmokHandler);
            //
            // We can also create our own methods and pass them to delegate, as long as their signature meet the requirement:
            //
            Console.WriteLine("\tAdded own defined call to be delegated:");
            kasmokHandler += Groom;
            kasmokDoer.DealWithIt(testKasmok1, kasmokHandler);


            /*
             *  FUNC<>
             */
            Kprint.Title("Experiment with Func<>:");

            Func<BetterKasmok, int> kasmokFuncHandler = kasmokActions.TakeItsRaspberries;
            kasmokFuncHandler += kasmokActions.TakeMoreRaspberries;

            // it looks somewhat strange, but it seems that Delegate will run both methods one after another
            // replacing first return of 12 with second return of 22, and finally only 22 is being returned and summed up.
            // https://dev.to/moe23/c-9-delegate-action-and-func-13d7
            // "if we call multiple methods inside the func it will only return the last value, it will execute all of the methods but
            // the return will be from only the last method called."

            int sum = kasmokDoer.DealWithRaspberries(testKasmok1, kasmokFuncHandler);
            Console.WriteLine($"Collected: {sum}");

            // Final word - when to use delegate, and when to use interface (by Mosh, by MSDN:
            // Use delegate when:
            // * personal preference,
            // * An eventing design pattern is used,
            // * The caller doesn't need to access other properties or methods on the object implementing the method.
        }

        // Declare our own action on kasmoks
        static void Groom(BetterKasmok kasmok)
        {
            Console.WriteLine($"{kasmok.Name} kasmok groomed");
        }
    }
}
