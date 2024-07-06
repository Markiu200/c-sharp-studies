namespace intermediate
{
    internal class Habitat
    {
        // Ok, so it's fresh concept to me. So here we assume that Habitat can have habitant. 
        // It can be (in this example) either BetterDragon, ForestDragon or ToyMan. Kasmoks inherit from animal, 
        // but ToyMan does not (to see what happens in certain scenarios).
        //
        // If everyone was derived from Animal, I could have just declared "Animal _habitant" field, and then worry 
        // about checking if everyone have Eat() and Sleep() method somehow. 
        // Nut here, with interfaces, we worry only about object capatibilities, not whole implementatnion in the background,
        // we want it "loosely coupled". 
        //
        // Declaring these three classes as "implementing IHabitant interface" forces and ensures, that all of them, somehow,
        // at some point, had these two methods declared

        private Animal? _habitant;
        public Habitat()
        {

        }

        public Habitat(Animal habitant)
        {
            this.SetHabitant(habitant);
        }

        /*
         *  Methods
         */
        public void SetHabitant(Animal habitant)
        {
            _habitant = habitant;
        }

        public void MakeHabitantEat()
        {
            // Note on how IDE didn't complain about whether whatever object we pass into _habitant will have these methods or not.
            // It is quarenteed and ensured by usage of interface. 
            if (_habitant is not null)
                _habitant.Eat();
            else
                Console.WriteLine("No habitant to do the eating");
        }

        public void MakeHabitantSleep()
        {
            if (_habitant is not null)
                _habitant.Sleep();
            else
                Console.WriteLine("No habitant to do the sleeping");
        }

        public void MakeHabitantEatAndSleep()
        {
            if (_habitant is not null)
            {
                _habitant.Eat();
                _habitant.Sleep();
            } 
            else
                Console.WriteLine("No habitant to do the sleeping");
        }
    }
}
