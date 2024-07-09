namespace intermediate
{
    internal class BetterKasmok : Animal, IHabitant, IComparable
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

        // Events - here Habitat is publisher - naming convention is to put what's happening + EventHandler.
        // 1 - Define a delegate
        public delegate void LightsOutEventHandler1(object? sender, EventArgs e);
        //
        // 2 - Define an event based on that delegate
        // "event" keyword makes it a specific property instead of just publicly available field. Does the encapsulation.
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/event
        // https://stackoverflow.com/questions/3028724/why-do-we-need-the-event-keyword-while-defining-events
        // https://csharpindepth.com/Articles/Events
        //
        public event LightsOutEventHandler1? LightsOut;

        // Shorter way:
        public event Action<object?, EventArgs>? LightsOut2;
        // Shortest way - delegate for events introduced by .NET
        public event EventHandler<EventArgs>? LightsOut3;
        // "sender" is implicintly sent. If you don't need to send any EventArgs, you can go with EventHandler (without <>)
        public event EventHandler? LightsOut4NoArgs;

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
         *  Events
         */
        // Convention is to always set it to protected virtual void, and name it "On<whatshappening>"
        // This calls all the subscribers and runs their methods.
        protected virtual void OnLightsOut()
        {
            if (LightsOut != null)
                // EventArgs.Empty if you don't actually want to pass any additional data, just this object.
                // https://learn.microsoft.com/en-us/dotnet/api/system.eventargs?view=net-8.0
                // https://stackoverflow.com/questions/14977927/how-do-i-pass-objects-in-eventargs
                // If you don't use EventHandler<>, you can define that object whatever you want, but probably doesn't work well with being universal
                // In fact, EventArgs is not designed to carry any data. To do som you have to use own class, or class that derives from EventArgs - 
                // either own, or other available in .NET.
                // https://learn.microsoft.com/en-us/dotnet/standard/events/
                // https://stackoverflow.com/questions/790344/why-is-it-useful-to-inherit-from-eventargs
                LightsOut(this, EventArgs.Empty);
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

        public int CompareTo(object? otherKasmok)
        {
            BetterKasmok? kasmok = otherKasmok as BetterKasmok;
            if (kasmok is null)
                return 1;

            return DateTime.Compare(this.Birthdate, kasmok.Birthdate);
        }

        // Method that will emit event
        public void TurnTheLightsOff()
        {
            Console.WriteLine($"Kasmok {Name} turned the lights out!");
            OnLightsOut();
        }
    }
}
