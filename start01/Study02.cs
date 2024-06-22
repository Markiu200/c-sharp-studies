using System.Collections;
using System.Globalization;

namespace study02
{
    internal class Study02
    {
        public static void PrintAll()
        {
            // Array 1D
            int[] arr1d_1 = { 1, 2 };
            int[] arr1d_2 = new int[] { 1, 2 };
            Console.WriteLine(arr1d_1.ToString());
            foreach (int i in arr1d_1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // Array 2D jagged
            int[][] arr2d_1 = new int[2][];
            arr2d_1[0] = new int[2] { 1, 2 };
            arr2d_1[1] = new int[4] { 3, 4, 5, 6 };

            IEnumerator enumerator = arr2d_1.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var enin = (int[])enumerator.Current;
                IEnumerator enumerator_in = enin.GetEnumerator();
                while (enumerator_in.MoveNext())
                {
                    Console.WriteLine(enumerator_in.Current);
                } 
            }
            Console.WriteLine();

            // Array 2D rectangular
            int[,] arr2d_2 = new int[2, 3]
            {
                { 10, 11, 12 },
                { 20, 21, 22 }
            };
            arr2d_2[0,2] = 7;
            Console.WriteLine($"{arr2d_2[0, 2]} {arr2d_2[0, 1]}");
            foreach (int i in arr2d_2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // Lists
            List<int> theIntList = new List<int>() { 30, 31, 32 };
            Console.WriteLine(theIntList);
            theIntList.Add(33);
            theIntList.AddRange(new int[] { 34, 35, 36 });
            foreach (int i in theIntList)
            {
                Console.Write(i + " ");
            }
            theIntList.Add(theIntList.Count);
            theIntList.Remove(33);
            Console.WriteLine();
            Console.WriteLine(theIntList[0]);
            foreach (int i in theIntList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // List remove element
            Console.WriteLine("List remove element");
            static void PrintList(List<int> list)
            {
                foreach (int i in list) { Console.Write(i+" "); }
                Console.WriteLine();
            }
            List<int> lista = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8,9,10,11,12 };
            for (int i=0; i<lista.Count; i+=2)
            {
                lista.Remove(lista[i]);
                PrintList(lista);
            }

            // DateTime
            Console.WriteLine("\nDateTime:");
            DateTime now = DateTime.Now;
            Console.WriteLine(now);

            TimeSpan span1 = TimeSpan.FromSeconds(30);
            Console.WriteLine(span1);
            TimeSpan span2 = now - now.AddMinutes(30);
            DateTime date1 = DateTime.Now.Add(span2);
            Console.WriteLine(date1);

            // Further study
            // https://stackoverflow.com/questions/33403122/converter-into-euro-c-sharp
            var polskieZlote = 12.99f;
            var cultureInfo = CultureInfo.GetCultureInfo("pl-PL");
            Console.WriteLine(String.Format(cultureInfo, "{0:C}", polskieZlote));

            string originalSentence = "This thisisaverylongwordaswell and this is a very long very long very long text of high lengthness";
            const int MAXLENGTH = 20;
            const int SPLITTABLE_LENGTH = 12;
            // Searching for point where you can shorthen the sentence
            int freeIndex = 0;
            int dotableIndex = 0;
            int wordLength = 0;
            for (int i=0; i<MAXLENGTH; i++)
            {
                if (originalSentence[i] == ' ' ||
                    originalSentence[i] == '\n' ||
                    originalSentence[i] == '\t')
                {
                    freeIndex = i; wordLength = 0;  continue;
                }
                wordLength++;
                if (wordLength >= SPLITTABLE_LENGTH)
                {
                    dotableIndex = i;
                }
            }
            // Shortening sentence
            if (freeIndex >= dotableIndex)
            {
                Console.WriteLine(originalSentence.Substring(0, freeIndex) + "...");
            } else
            {
                Console.WriteLine(originalSentence.Substring(0, dotableIndex) + "(...)...");
            }
        }
    }
}
