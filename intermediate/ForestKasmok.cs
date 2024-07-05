namespace intermediate
{
    internal class ForestKasmok : BetterKasmok
    {
        /*
         *  Constructors
         */
        public ForestKasmok() : base() { }

        public ForestKasmok(string name, DateTime birthdate) : base(name, birthdate) { }

        /*
         *  Methods
         */
        public void HideUnderTheShroom()
        {
            Console.WriteLine($"{this.Name} quickly hid under the shroom");
        }
    }
}
