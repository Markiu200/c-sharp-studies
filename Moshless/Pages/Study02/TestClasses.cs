namespace Moshless.Pages.Study02
{
    public class TestClass
    {
        public string text = "";
        public int number = 0;
    }
    public struct TestStruct
    {
        // A 'struct' with field initializers must include an explicitly declared constructor.
        //public string text = "";
        //public int number = 0;
        public string text;
        public int number;
    }
    public struct ValueStruct
    {
        public int value;
    }

    public static class TestClasses
    {
        public static void ClassChangeName(TestClass test)
        {
            test.text = "changed";
        }
        public static void StructChangeName(TestStruct test)
        {
            test.text = "changed";
        }
    }
}
