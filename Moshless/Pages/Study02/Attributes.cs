using System.Runtime.InteropServices;

namespace Moshless.Pages.Study02
{
    public static class Attributes
    {
        // Using built-in attributes
        [Obsolete("Obsolete test")]
        public static void ObsoleteThing() { }
    }



    /*
     * Declaring own attributes
     * 
     * https://learn.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes
     * Using AttributeUsage. Behavior of attribute is declared like it's a class.
     */
    // The AttributeUsageAttribute.AllowMultiple property indicates whether multiple instances of your attribute can exist on an element.
    // If set to true, multiple instances are allowed. If set to false (the default), only one instance is allowed.
    //
    // So later things like
    // [MyAttribute]
    // [MyAttribute]
    // public void (...)
    // are legal (or not).
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class MyAttribute : Attribute 
    {
        public bool myValue = false;
        public MyAttribute(bool _myValue)
        {
            this.myValue = _myValue;
        }
    }
}
