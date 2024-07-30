using NspKprint;
using System.Collections.Specialized;
using System.Reflection;

// [assembly:AssemblyTitle("Attribute given for entire assembly")]
// Though it throws Error	CS0579	Duplicate 'System.Reflection.AssemblyTitleAttribute' attribute

namespace Moshless.Pages.Study02
{
    internal class Study02
    {
        public static void Run()
        {
            Kprint.FTitle("Class / struct difference test:");
            /*
                * https://learn.microsoft.com/en-us/dotnet/standard/base-types/common-type-system
                * Testing struct behavior, knowing that struct is implicitly derived from class.
                * For a value type, you should always override Equals, because tests for equality that rely on reflection offer poor performance.
                */
            TestClass testClass = new TestClass { text = "testClass", number = 1 };
            TestStruct testStruct = new TestStruct { text = "testStruct", number = 1 };
            TestClasses.ClassChangeName(testClass);
            TestClasses.StructChangeName(testStruct);
            Console.WriteLine($"Change in class type: {testClass.text}");
            Console.WriteLine($"Change in struct type: {testStruct.text}");



            Kprint.Title("Anonymous type / Tuple / ValueTuple example:");



            /*
                * https://learn.microsoft.com/en-us/dotnet/standard/base-types/choosing-between-anonymous-and-tuple
                * The ValueTuple types are mutable, whereas Tuple are read-only. Anonymous types can be used in expression trees, while tuples cannot.
                * Tuple = class, ValueTuple = struct
                */
            var dates = new[]
            {
                DateTime.UtcNow.AddHours(-1),
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
            };
            foreach (var anonymous in
                            dates.Select(
                                date => new { Formatted = $"{date:MMM dd, yyyy hh:mm zzz}", date.Ticks }))
            {
                Console.WriteLine($"Ticks: {anonymous.Ticks}, formatted: {anonymous.Formatted}");
            }
            foreach (var tuple in
            dates.Select(
                date => new Tuple<string, long>($"{date:MMM dd, yyyy hh:mm zzz}", date.Ticks)))
            {
                Console.WriteLine($"Ticks: {tuple.Item2}, formatted: {tuple.Item1}");
            }
            foreach (var (formatted, ticks) in
            dates.Select(
                date => (Formatted: $"{date:MMM dd, yyyy at hh:mm zzz}", date.Ticks)))
            {
                Console.WriteLine($"Ticks: {ticks}, formatted: {formatted}");
            }



            Kprint.Title("ToSting() override:");



            /*
                * https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-object-tostring
                * Also formatting:
                * https://learn.microsoft.com/en-us/dotnet/standard/base-types/formatting-types
                * https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
                * https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
                * https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
                * https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
                */
            Console.WriteLine(testClass.ToString());
            Console.WriteLine(testStruct.ToString());



            Kprint.Title("NameValueCollection():");



            /*
                * NameValueCollection
                * 
                * https://learn.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class
                * https://www.c-sharpcorner.com/UploadFile/d3e4b1/practical-usage-of-namevaluecollection-in-C-Sharp-part1/
                */
            NameValueCollection collection = new NameValueCollection();
            collection.Add("Lajapathy", ":INQ");
            collection.Add("partiban", "WCF");
            collection.Add("partiban", "Silverlight");
            collection.Add("Sathiya", "C#");
            collection.Add("Sathiya", "dot net");
            collection.Add("Sangita", "C#");
            foreach (string? _key in collection.AllKeys)
            {
                Console.Write(_key + ",");
            }
            Console.WriteLine();
            Console.Write($"Value : {collection["Sathiya"]}");
            Console.WriteLine();
            string key = collection.GetKey(1)!;
            Console.Write($"Value : {key}");



            Kprint.Title("Attributes:");



            /*
                * Attributes
                * 
                * https://learn.microsoft.com/en-us/dotnet/standard/attributes/
                */
            Console.WriteLine("Throws warning because of [Obsolete] attribute");
            Attributes.ObsoleteThing();

            Console.WriteLine("Custom attributes");
            // Try to get the attribute

            // Get all methods in this class, and put them
            // in an array of System.Reflection.MemberInfo objects.
            MemberInfo[] MyMemberInfo = typeof(Study02).GetMethods();

            // Loop through all methods in this class that are in the
            // MyMemberInfo array.
            // (line below is for checking for class-level attribute, but I left it here for reference and inital value of myAtt.
            // https://learn.microsoft.com/en-us/dotnet/standard/attributes/retrieving-information-stored-in-attributes
            MyAttribute myAtt = (MyAttribute)Attribute.GetCustomAttribute(typeof(Study02), typeof(MyAttribute))!;

            for (int i = 0; i < MyMemberInfo.Length; i++)
            {
                myAtt = (MyAttribute)Attribute.GetCustomAttribute(MyMemberInfo[i], typeof(MyAttribute))!;
                if (myAtt == null)
                {
                    Console.WriteLine("The attribute was not found.");
                }
                else
                {
                    // Get the myValue value.
                    Console.WriteLine("The myValue Attribute is: {0}.", myAtt.myValue);
                }
            }



            Kprint.Title("Reflections:");



            /*
                * Reflections
                * 
                * https://learn.microsoft.com/en-us/dotnet/fundamentals/reflection/reflection
                * https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/
                */
            Type t0 = typeof(System.String);
            Console.WriteLine("Listing all the public constructors of the {0} type", t0);
            // Constructors.
            ConstructorInfo[] cic = t0.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("//Constructors");
            foreach (MemberInfo m in cic)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }
            Console.WriteLine();

            Console.WriteLine("Members:");
            Type myType = Type.GetType("System.IO.File")!;
            MemberInfo[] myMemberInfoArray = myType.GetMembers();
            Console.WriteLine("There are {0} members in {1}.",
            myMemberInfoArray.Length, myType.FullName);
            Console.WriteLine("{0}.", myType.FullName);
            if (myType.IsPublic)
            {
                Console.WriteLine("{0} is public.", myType.FullName);
            }

            Console.WriteLine("\nReflection.MethodInfo");
            // Gets and displays the Type.
            Type myType2 = Type.GetType("System.Reflection.FieldInfo")!;
            // Specifies the member for which you want type information.
            MethodInfo myMethodInfo = myType2.GetMethod("GetValue")!;
            Console.WriteLine(myType.FullName + "." + myMethodInfo.Name);
            // Gets and displays the MemberType property.
            MemberTypes myMemberTypes = myMethodInfo.MemberType;
            if (MemberTypes.Constructor == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type All");
            }
            else if (MemberTypes.Custom == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Custom");
            }
            else if (MemberTypes.Event == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Event");
            }
            else if (MemberTypes.Field == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Field");
            }
            else if (MemberTypes.Method == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Method");
            }
            else if (MemberTypes.Property == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Property");
            }
            else if (MemberTypes.TypeInfo == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type TypeInfo");
            }

            Console.WriteLine("\n");
            // Specifies the class.
            Type t = typeof(System.IO.BufferedStream);
            Console.WriteLine("Listing all the members (public and non public) of the {0} type", t);

            // Lists static fields first.
            FieldInfo[] fi = t.GetFields(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Fields");
            PrintMembers(fi);

            // Static properties.
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Properties");
            PrintMembers(pi);

            // Static events.
            EventInfo[] ei = t.GetEvents(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Events");
            PrintMembers(ei);

            // Static methods.
            MethodInfo[] mi = t.GetMethods(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Methods");
            PrintMembers(mi);

            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Constructors");
            PrintMembers(ci);

            // Instance fields.
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Fields");
            PrintMembers(fi);

            // Instance properties.
            pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Properties");
            PrintMembers(pi);

            // Instance events.
            ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Events");
            PrintMembers(ei);

            // Instance methods.
            mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);
            Console.WriteLine("// Instance Methods");
            PrintMembers(mi);



            Console.WriteLine("\nGeneric type reflection");
            Type d1 = typeof(Dictionary<,>);

            Console.WriteLine("   Is this a generic type? {0}", d1.IsGenericType);
            Console.WriteLine("   Is this a generic type definition? {0}", d1.IsGenericTypeDefinition);

            Type[] typeParameters = d1.GetGenericArguments();

            Console.WriteLine("   List {0} type arguments:", typeParameters.Length);
            foreach (Type tParam in typeParameters)
            {
                if (tParam.IsGenericParameter)
                {
                    DisplayGenericParameter(tParam);
                }
                else
                {
                    Console.WriteLine("      Type argument: {0}", tParam);
                }
            }
        }






        /*
         * Other methods
         */
        [MyAttribute(true)] // compiler greys out "Attribute", as you can use them without "Attribute" part, even if it's in name.s
        public static void CustomAttrFunc() { }

        public static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }
            Console.WriteLine();
        }

        private static void DisplayGenericParameter(Type tp)
        {
            Console.WriteLine("      Type parameter: {0} position {1}", tp.Name, tp.GenericParameterPosition);
        }
    }
}
