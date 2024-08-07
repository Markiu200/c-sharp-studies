﻿namespace intermediate
{
    public class ForestKasmok : BetterKasmok, IHabitant
    {
        /*
         *  Fields
         */
        

        /*
         *  Constructors
         */
        public ForestKasmok() : base() 
        {
            this.habitat = new ForestKasmokHabitat();
        }

        public ForestKasmok(string name, DateTime birthdate) : base(name, birthdate) 
        {
            this.habitat = new ForestKasmokHabitat();
        }
        /*
         *  Events
         */
        // This is where we code what we need to happen on event.
        public void OnLightsOutEventHandler(object? sender, EventArgs e)
        {
            BetterKasmok? whiteSmo = sender as BetterKasmok;
            if (whiteSmo is not null)
                Console.Write($"{this.Name} sees {whiteSmo.Name} turned the lights out! "); 
                MakeSound_override();
        }

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
        protected override void SetHabitat()
        {
            this.habitat = new ForestKasmokHabitat();
        }

        public void HideUnderTheShroom()
        {
            Console.WriteLine($"{this.Name} quickly hid under the shroom");
        }
    }
}
