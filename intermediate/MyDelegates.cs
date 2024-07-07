﻿using System.Security.Cryptography.X509Certificates;

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

        // Define the signature of the method, that this delegate will be responsible of calling.
        public delegate void KasmokDoerHandler(BetterKasmok kasmok);

        // Add this delegate as a parameter:
        public void DealWithIt(BetterKasmok kasmok, KasmokDoerHandler kasmokHandler)
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
