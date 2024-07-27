using NspKprint;

namespace Moshless.Pages.Study02
{
    internal class Study02
    {
        public static void Run()
        {
            /*
             * https://learn.microsoft.com/en-us/dotnet/standard/base-types/common-type-system
             * Testing struct behavior, knowing that struct is implicitly derived from class.
             */
            TestClass testClass = new TestClass { text = "testClass", number = 1 };
            TestStruct testStruct = new TestStruct { text = "testStruct", number = 1 };
            TestClasses.ClassChangeName(testClass);
            TestClasses.StructChangeName(testStruct);
            Console.WriteLine($"Change in class type: {testClass.text}");
            Console.WriteLine($"Change in struct type: {testStruct.text}");



            Kprint.Title();
            


            int codePoint = 1067;
            IConvertible iConv = codePoint;
            char ch = iConv.ToChar(null);
            Console.WriteLine("Converted {0} to {1}.", codePoint, ch);
        } 
    }
}
