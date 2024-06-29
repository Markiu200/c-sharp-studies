namespace intermediate
{
    internal class Kasmok
    {
        // Commented out for auto-implemented properties.
        /*private string name;
        private string color;
        private string size;*/

        // Auto-implemented properties. 
        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
        private int _age;
        public int piskAmount = 1;

        public int Age
        {
            get { return _age; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Age cannot be less than 0");
                }
                _age = value;
            }
        }

        static Kasmok()
        {
            Console.WriteLine("Static consturctor Kasmok has been initialized.");
        }

        public Kasmok()
        {
            // Auto-implementet properties start with capital letter, since you supposedly
            // don't need to do any validation on it.
            // https://blog.codinghorror.com/properties-vs-public-variables/
            // https://stackoverflow.com/questions/1180860/public-fields-versus-automatic-properties
            Name = "";
            Color = "";
            Size = "";
            // Properties with hand-written get/set logic use "private backing field".
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
            _age = 0;
        }

        public Kasmok(string name, string color, string size)
        {
            this.Name = name ?? "";
            this.Color = color ?? "";
            this.Size = size ?? "";
        }

        ~Kasmok()
        {
            Console.WriteLine("Finalizer of object Kasmok was reached...");
        }

        /// <summary>
        /// This overrides Object's ToString() method.
        /// </summary>
        /// <returns>
        /// Greeting of a Kasmok
        /// </returns>
        public override string ToString()
        {
            return $"Czesc {Size} {Color} {Name}! (age of {_age.ToString()})";
        }

        /// <summary>
        /// This is example for "params", which is like *args in python.
        /// You can pass both an array of element, or just separated with comas, 
        /// which is like it was in Python I believe. 
        /// </summary>
        public void PiskThat(params string[] pisks)
        {
            foreach (string p in pisks)
            {
                Console.Write(p + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Example for "ref" keyword usage. It makes value types behave as reference types
        /// when passed as an argument. This one doesn't have "ref" and is here for comparison.
        /// </summary>
        public void AddThePiskNoRef(int baseAmount)
        {
            Console.WriteLine($"Amount of pisks increased by 1");
            baseAmount += 1;
        }

        /// Example for "ref" keyword usage. It makes value types behave as reference types
        /// when passed as an argument. This one has "ref".
        /// </summary>
        public void AddThePiskWithRef(ref int baseAmount)
        {
            Console.WriteLine($"Amount of pisks increased by 1");
            baseAmount += 1;
        }

        /// <summary>
        /// Example for "out". Known use case would be "TryParse" method. 
        /// It workd basically as "ref", passes arguments by reference (in a way), 
        /// however it has different requirements, restrictions and use cases.
        /// Here, most notably, you have assign something to out parameters, and 
        /// you cannot use them for input (compiler error will pop up).
        /// https://www.c-sharpcorner.com/UploadFile/ff2f08/ref-vs-out-keywords-in-C-Sharp/
        /// </summary>
        /// <param name="pisks"></param>
        public void howManyPisksTimesTwo(out int pisks, out int multiPisks)
        {
            // Console.WriteLine(pisks);  // compiler error 
            // Every assignment is required, otherwise error is thrown.
            pisks = this.piskAmount * 2;
            multiPisks = this.piskAmount * 8;
        }
    }
}
