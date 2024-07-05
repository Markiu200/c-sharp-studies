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
}
