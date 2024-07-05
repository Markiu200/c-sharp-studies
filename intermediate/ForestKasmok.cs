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
         *  Overrides
         */
        public void MakeSound_noNew()
        {
            Console.WriteLine("*generic forest kasmok sound*");
        }
        public new void MakeSound_new()
        {
            Console.WriteLine("*generic forest kasmok sound*");
        }
        public override void MakeSound_override()  // compiler will complain if "override" is used, but parent method is not "virtual"
        {
            Console.WriteLine("*generic forest kasmok sound*");
        }

        /*
         *  Methods
         */
        public void HideUnderTheShroom()
        {
            Console.WriteLine($"{this.Name} quickly hid under the shroom");
        }
    }
}
