namespace intermediate
{
    internal class BetterKasmok
    {
        /*
         *  Properties
         */
        // auto-implemented
        public string Name { get; set; }

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
        }

        public BetterKasmok(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
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
        public void FixBirthdate(DateTime birthdate)
        {
            this.Birthdate = birthdate;
        }
    }
}
