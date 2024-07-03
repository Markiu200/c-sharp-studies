namespace intermediate
{
    internal class TestKasmok
    {
        // Commented out for auto-implemented properties.
        /*private string name;
        private string color;
        private string size;*/

        // Just a field.
        public int piskAmount = 1;
        // readonly field for further testing.
        public readonly List<String> pebbles = new List<String>();


        // Auto-implemented properties. 
        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        // You can see what hidden private field has been created by running "ildasm <.dllFile>" on Visual Studio Terminal, 
        // this will show what has been compiled as IL code. 
        // PS C:\Users\ksmforest\source\repos\CS_with_Mosh\intermediate\bin\Debug\net8.0> ildasm .\intermediate.dll
        // https://learn.microsoft.com/en-us/visualstudio/ide/reference/command-prompt-powershell?view=vs-2022
        // https://www.udemy.com/course/csharp-intermediate-classes-interfaces-and-oop/learn/lecture/2205242#overview
        // https://learn.microsoft.com/en-us/answers/questions/370576/ildasm-exe-wont-work
        // E.g. for "Name" it creates private "<Name>k__BackingField" and methods "get_Name" and "set_Name".
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";

        // Making a field into a property.
        // It is believed to be a good practice to make fields private with "_",
        // and then to make property with capital case. 
        private int _age;  
        public int Age
        {
            // Even though "get" here returns corresponding to the property private field, it doesn't have to. See below.
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
        // Creating property w/o backing private field.
        // Proprety doesn't necessarily need a private field, and can return and set thing from different sources. 
        // https://www.udemy.com/course/csharp-intermediate-classes-interfaces-and-oop/learn/lecture/2205242#overview
        public int OlderAge
        {
            // Here "Age" property will be used, but it could return constant as well.
            get { return Age + 20; }
            // Setter is not required for properties. This will make it read only. 
        }


        /// <summary>
        /// Static constructor is called only once, when the first object of that class is initialized.
        /// </summary>
        static TestKasmok()
        {
            Console.WriteLine("Static consturctor Kasmok has been initialized.");
        }

        /// <summary>
        /// Typical constructor is called every time an object is initialized. 
        /// </summary>
        public TestKasmok()
        {
            // Auto-implementet properties start with capital letter, since you supposedly
            // don't need to do any validation on it. Also now those are "get" "set" methods, 
            // not just fields.
            // https://blog.codinghorror.com/properties-vs-public-variables/
            // https://stackoverflow.com/questions/1180860/public-fields-versus-automatic-properties
            Name = "";
            Color = "";
            Size = "";
            // Properties with hand-written get/set logic use "private backing field".
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
            _age = 0;
        }

        /// <summary>
        /// Constructor with one parameter. Here it will be used for following constructor 
        /// and ": this()" notation - "Constructor Chain":
        /// https://stackoverflow.com/questions/1814953/how-to-do-constructor-chaining-in-c-sharp
        /// </summary>
        /// <param name="name">Name of kasmok</param>
        public TestKasmok(string name)
        {
            this.Name = name ?? "";
        }

        /// <summary>
        /// Constructor with parameters. Uses "Construction Chaining" with constructor above.
        /// </summary>
        /// <param name="name">Name of kasmok</param>
        /// <param name="color">Color of kasmok</param>
        /// <param name="size">Size of kasmok</param>
        public TestKasmok(string name, string color, string size) : this(name)
        {
            // this.Name = name ?? "";  // not needed due to chain
            this.Color = color ?? "";
            this.Size = size ?? "";
        }

        /// <summary>
        /// Finalizer, aka "destructor". This will run when garbage collector removes 
        /// that specific instance of a class (object).
        /// </summary>
        ~TestKasmok()
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
        public void HowManyPisksTimesTwo(out int pisks, out int multiPisks)
        {
            // Console.WriteLine(pisks);  // compiler error 
            // Every assignment is required, otherwise error is thrown.
            pisks = this.piskAmount * 2;
            multiPisks = this.piskAmount * 8;
        }

        /// <summary>
        /// Method for "readonly" field example. "const" can be used only with
        /// C# built-in types. For all user-defined types, use "readonly".
        /// Using 'readonly" modifier may lead to peculiar compiler behavior. (like "defensive copy")
        /// https://devblogs.microsoft.com/premier-developer/avoiding-struct-and-readonly-reference-performance-pitfalls-with-errorprone-net/
        /// https://www.developmentsimplyput.com/post/defensive-copy-in-net-c
        /// https://www.c-sharpcorner.com/article/c-sharp-11-immutable-object-and-defensive-copy/
        /// "readonly" makes can be set only at initialization or in constructor. 
        /// It makes sure that the thing will remain the same. Note that it doesn't protect
        /// elements of reference-type objects, only that it won't be lost or overriden. 
        /// </summary>
        public void AddPebble()
        {
            // A readonly field cannot be assigned to (except in a constructor
            // or init-only setter of the type in which the field is defined or a variable initializer
            // this.pebbles = new List<int>();  
            
            this.pebbles.Add("Maleńki kamyczek");  // Modifying things inside referred thing is allowed
            // This example would be more exciting with struct types.
        }
        public void ListPebbles()
        {
            foreach (string p in this.pebbles)
            {
                Console.Write(p+" ");
            }
        }
    }
}
