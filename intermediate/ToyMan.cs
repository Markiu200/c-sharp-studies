namespace intermediate
{
    internal class ToyMan : Animal
    {
        // Before I wrote below methods, IDE complained that:
        // Error	CS0535	'ToyMan' does not implement interface member 'IHabitant.Eat()'
        // Error	CS0535	'ToyMan' does not implement interface member 'IHabitant.Sleep()'

        public void Eat()
        {
            Console.WriteLine("Eat");
        }

        public void Sleep()
        {
            Console.WriteLine("Sleep");
        }
    }
}
