namespace intermediate
{
    internal abstract class KasmokHabitat  // if any member of a class is abstract, class must be abstract
    {
        /// <summary>
        /// Abstract method cannot be implemented here, but must be implemented by derived class.
        /// </summary>
        public abstract string DescribeHabitat();
    }

    internal class ForestKasmokHabitat : KasmokHabitat
    {
        public override string DescribeHabitat()  // must be "override", otherwise compiler won't let it be
        {
            return "Big brown mushroom";
        }
    }

    internal class WhiteKasmokHabitat : KasmokHabitat
    {
        public override string DescribeHabitat()  // must be "override", otherwise compiler won't let it be
        {
            return "Cave in snowy mountains";
        }
    }

    internal class NotAKasmokHabitat : WhiteKasmokHabitat
    {
        // Instead of overriding methods or classes, you can prevent this from happening, that is:
        // preventing from creating derivatives of a class
        // preventing from overriding a method
        // Simply use "sealed" keyword in method or class declaration.
        // MSDN says that it makes better performance, but it's a slight upgrade and probably isn't worth it, and may be in your way in the future. 
        // No need to use it unless making derivatives is indeed undesired.
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sealed
        public override string DescribeHabitat()
        {
            return "Turns out you can override overriden thing";
        }
    }
}
