namespace exercises_076
{
    internal class Exercises_076
    {
        public static void Exercise01()
        {
            Console.WriteLine("File manipulation");
            string currentPath = Directory.GetCurrentDirectory();
            var currentPathInfo = new DirectoryInfo(@"D:\Dane_VisualStudio\Projects\CS_with_Mosh\start01\files\");

            var filesInPath = currentPathInfo.GetFiles();
            Console.WriteLine($"# of files in {currentPathInfo.Name}: {filesInPath.Length}");
            foreach (var file in filesInPath)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine();
            var testFile = new FileInfo(filesInPath[0].FullName);
            Console.WriteLine($"File name: {testFile.Name}");
            Console.WriteLine($"Full file name: {testFile.FullName}");


            string contents = File.ReadAllText(testFile.FullName);
            Console.WriteLine();
            Console.WriteLine($"Contents of {testFile.Name}: {contents}");

            Console.WriteLine();
            Console.WriteLine($"Contents word length: {contents.Split(' ').Length}");

            int lengthiest = 0; int position = 0;
            int current = 0;
            for (int i = 0; i < contents.Length; i++)
            {
                if (char.IsWhiteSpace(contents[i]))
                {
                    if (current > lengthiest) 
                    { 
                        lengthiest = current; 
                        position = i;
                    }
                    current = 0;
                }
                else
                {
                    current++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Longest word in file ({lengthiest} chars): " +
                $"{contents.Substring(position-lengthiest, lengthiest)}");
        }
    }
}
