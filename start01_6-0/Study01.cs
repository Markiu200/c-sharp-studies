using study01_1;
using study01.Nested;

namespace study01
{
    internal class Study01
    {
        public enum KolorKasmok
        {
            Bialy = 1, Niebieski = 2
        }

        public static void Study01_go()
        {
            // Some randomness 1
            Console.WriteLine("Hello, World!");
            bool isTrue = false;
            string someText = "Hej";
            Console.WriteLine(someText[0]);
            if (isTrue)
            {
                Console.WriteLine("It is true");
            }
            else
            {
                Console.WriteLine("It is not true");
            }
            byte b = 0b00000001;
            byte a = 0b00000010;
            Console.WriteLine(~a | b);
            Console.WriteLine(~0b11111111);
            Console.WriteLine(~0b00000000);
            Console.WriteLine(a ^ b);

            // Some randomness 2
            int[] numerki = new int[2] { 1, 2 };
            int a1 = 1;
            foreach (int i in numerki)
            {
                Console.WriteLine("numerek {0}: {1}", a1++, i);
            }
            {
                int abl = 1;
                {
                    int bbl = 2;
                    {
                        int cbl = 3;
                        Console.WriteLine(bbl);
                        Console.WriteLine(abl);
                    }
                    //Console.WriteLine(cbl);
                }
            }
            TheClass newObject = new TheClass(10);
            TheSecondClass newObject2 = new TheSecondClass() { theSecondInt = 20 }; // So called "object initialization syntax"
            newObject2.SecondGetText();
            Console.WriteLine(newObject2.theSecondInt);
            NestedClass newObject3 = new NestedClass();
            newObject3.Talk();

            // Verbatim Strings
            // Allows to escape all special characters by placing "@" before String.
            Console.WriteLine(@"D:\Dane_VisualStudio\Projects\CS_with_Mosh\start01 ;; \n
A tu po enterze");
            string string1 = "Smok";
            Console.WriteLine(string1.GetHashCode());
            Console.WriteLine("Smok".GetHashCode());
            Console.WriteLine("Kasmok".GetHashCode());
            Console.WriteLine("Kasmok".GetHashCode());
            string string2 = "Kasmok";
            string string3 = string1 + " " + string2;
            string string4 = string.Format("Ja jestem {0} {1}", string1, string2);
            string[] stringList = { "Ja", "jestem", "Smok", "Kasmok", "2" };
            string string5 = string.Join(" ", stringList);

            Console.WriteLine(string1);
            Console.WriteLine(string2);
            Console.WriteLine(string3);
            Console.WriteLine(string4);
            Console.WriteLine(string5);

            Console.WriteLine(KolorKasmok.Bialy); // Is same as KolorKasmok.Bialy.ToString(), as Console.WriteLine autmatically adds "ToString()"
            int enum1 = (int)KolorKasmok.Bialy;
            Console.WriteLine(enum1);
            Console.WriteLine((int)KolorKasmok.Niebieski);
            // Cast w druga strone
            Console.WriteLine((KolorKasmok)2);
            // By string - parsing - https://www.udemy.com/course/csharp-tutorial-for-beginners/learn/lecture/3450268#overview
            Console.WriteLine(typeof(KolorKasmok));
            var whatis = Enum.Parse(typeof(KolorKasmok), "Bialy");
            Console.WriteLine(whatis);
            Console.WriteLine((int)whatis);
            //Console.WriteLine(typeof(whatis));

            KolorKasmok jakiKasmok = KolorKasmok.Niebieski;
            switch (jakiKasmok)
            {
                case KolorKasmok.Bialy:
                    Console.WriteLine("Biały Kasmok");
                    break;
                case KolorKasmok.Niebieski:
                    Console.WriteLine("Jaki niebieski smo");
                    break;
                default:
                    break;
            }
        }
    }
}
