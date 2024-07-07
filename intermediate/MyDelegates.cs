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

        public void DealWithIt(BetterKasmok kasmok)
        {
            var actions = new ActionsOnKasmoks();

            // Predefined actions to take on kasmoks - each kasmok will be pet and feed, and as an
            // user of this framework, we don't have much choice. And we'd like to have some.
            //
            // It can be achieved with interfaces or delegates.
            actions.Pet(kasmok);
            actions.Feed(kasmok);
        }
    }
}
