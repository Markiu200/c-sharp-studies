namespace intermediate
{
    /// <summary>
    /// Interface that assumes that "habitant" is anything that can eat and sleep (for example sake).
    /// Will be used for a field in habitat class.
    /// </summary>
    public interface IHabitant
    {
        void Eat();
        void Sleep();
    }
}
