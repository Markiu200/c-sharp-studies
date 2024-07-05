namespace intermediate
{
    internal class ForestKasmok : BetterKasmok
    {
        public ForestKasmok() : base()
        {

        }

        public ForestKasmok(string name, DateTime birthdate) : base(name, birthdate)
        {

        }

        public void HideUnderTheShroom()
        {
            Console.WriteLine($"{this.Name} quickly hid under the shroom");
        }
    }
}
