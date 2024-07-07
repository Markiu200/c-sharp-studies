using System.Security.Cryptography.X509Certificates;

namespace intermediate
{
    internal class ActionsOnKasmoks
    {
        public void Pet(BetterKasmok kasmok)
        {
            Console.WriteLine($"{kasmok.Name} kasmok pat");
        }
        public void Feed(BetterKasmok kasmok)
        {
            Console.WriteLine($"{kasmok.Name} kasmok feed");
        }
        public int TakeItsRaspberries(BetterKasmok kasmok)
        {
            Console.WriteLine($"{kasmok.Name} kasmok's raspberries taken");
            return 12;  // taken 12 raspberries, just to test Func<>.
        }
        public int TakeMoreRaspberries(BetterKasmok kasmok)
        {
            Console.WriteLine($"{kasmok.Name} kasmok's more raspberries taken");
            return 22;  // taken 22 raspberries, just to test Func<>.
        }
    }

    internal class DealWithKasmok
    {
        // Analogy to example given by Mosh.
        // We have this framework (now it is framework, don't worry about it) that deals with kasmoks.
        // Method takes a kasmok and does things with it. Assume that we're using that framework and cannot 
        // freely modify it.

        // Instead of declaring own delegates, we can use .NET ones. They come in variants:
        // Action       - probably used for methods that do not have arguments
        // Action<>     - methods with arguments
        // Func         - no arguments, returns things
        // Func<>       - argumets, returns things
        // Action is used for calls to methods that do not return anything.
        // Func are used for methods that do return things, so you can fetch that with "out" declared parameter.

        // Or create it by hand, here Action<> type (because takes arg and returns void):
        public delegate void KasmokActionHandler(BetterKasmok kasmok);
        //
        // Later instead of "Action<BetterKasmok>" use "KasmokActionHandler<BetterKasmok>".

        public void DealWithIt(BetterKasmok kasmok, Action<BetterKasmok> kasmokHandler)
        {
            var actions = new ActionsOnKasmoks();

            kasmokHandler(kasmok);
        }

        public int DealWithRaspberries(BetterKasmok kasmok, Func<BetterKasmok, int> kasmokHandler)
        {
            int sum = 0;
            sum += kasmokHandler(kasmok);
            return sum;
        }
        
    }
}
