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
        //
        // Add this delegate as a parameter. Our calls don't return anything but take argument, so Action<typeOfThatArgument>:
        public void DealWithIt(BetterKasmok kasmok, Action<BetterKasmok> kasmokHandler)
        {
            var actions = new ActionsOnKasmoks();

            // Predefined actions to take on kasmoks - each kasmok will be pet and feed, and as an
            // user of this framework, we don't have much choice. And we'd like to have some.
            //
            // It can be achieved with interfaces or delegates.

            // Get rid of hardcoded calls..
            // actions.Pet(kasmok);
            // actions.Feed(kasmok);
            //
            // ..and get Delegate to work.
            kasmokHandler(kasmok);
        }
    }
}
