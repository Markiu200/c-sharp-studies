namespace intermediate
{
    internal class BetterKasmok : Animal, IHabitant
    {
        /* 
         *  Fields
         */
        

        /*
         *  Properties
         */
        // auto-implemented
        public string Name { get; set; }
        public KasmokHabitat? habitat { get; protected set; }

        // manual
        DateTime _birthdate;
        public DateTime Birthdate { 
            get { return _birthdate; } 
            private set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException("bithdate", "Birthdate cannot be from the future.");
                this._birthdate = value;
            }
        }
        public int Age
        {
            get { return (DateTime.Today - Birthdate).Days / 365; }
        }

        /* 
         *  Constructors
         */
        public BetterKasmok()
        {
            this.Birthdate = DateTime.Today;
            this.Name = "";
            this.SetHabitat();
        }

        public BetterKasmok(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
            this.SetHabitat();
        }

        /*
         *  Overrides
         */
        public override string ToString()
        {
            return $"kasmok {this.Name}, age {this.Age}";
        }

        /*
         *  Methods
         */
        protected virtual void SetHabitat()
        {
            this.habitat = new WhiteKasmokHabitat();
        }

        public void FixBirthdate(DateTime birthdate)
        {
            this.Birthdate = birthdate;
        }

        /// <summary>
        /// Example method that will be overriden by KamsmokForest by just writing a method there from a scratch.
        /// </summary>
        public void MakeSound_noNew()
        {
            Console.WriteLine("*generic kasmok sound*");
        }

        /// <summary>
        /// Example method that will be overriden by KasmokForest using "new" keyword.
        /// "new" keyword basically suppresses the warning, but does not change how program will behave.
        /// It is there just to inform you that the issue exists, and by using "new" it is acknowledged and confirmed that this is what is wanted.
        /// </summary>
        public void MakeSound_new()
        {
            Console.WriteLine("*generic kasmok sound*");
        }

        /// <summary>
        /// Example method that will be overriden by KasmokForest using "override" keyword. This class must be virtual, else compiler won't let it be.
        /// </summary>
        public virtual void MakeSound_override()
        {
            Console.WriteLine("*generic kasmok sound*");
        }

        // For interfaces experiment
        public void Eat() { Console.WriteLine("Eat"); }
        public void Sleep() { Console.WriteLine("Sleep"); }
    }
}
