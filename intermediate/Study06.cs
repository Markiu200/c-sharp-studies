using NspKprint;
using System.Net;

namespace intermediate.Study06
{
    internal class Study06
    {
        public static void Run()
        {
            /*
             * **** Async / Await ****
             */

            Kprint.FTitle("Async / Await:");
            // When runtime executes some method or function that takes a long time, eg. download video from Internet,
            // with synchronous execution program will freeze until that method is done. In meanwhile another block of code
            // could've been executed. This is where asynchronous execution comes in. 

            // In previous .NET versions this is accomplished with traditional approaches:
            // * Multi-threading,
            // * Callbacks.
            // These are considered to be hard to learn and cumbersome to use. .NET 4.5 introduced async / await.

            // Examples will be basically copied from Mosh, downloading HTML file. Also sleep, because download is too fast. 

            var htmlStuff = new HTMLStuff();
            DateTime begin = DateTime.Now;

            Console.WriteLine("\tSynchronous:");
            Console.WriteLine("Processing started...");
            htmlStuff.DownloadHTML("https://learn.microsoft.com/en-ca/", begin);
            Console.WriteLine("Processing is done. ".PadRight(30, ' ') + (DateTime.Now - begin));
        }
    }

    internal class HTMLStuff
    {
        // Synchronous processing - returns void:
        public void DownloadHTML(string url, DateTime start)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);
            Console.WriteLine("HTML downladed... ".PadRight(30, ' ') + (DateTime.Now - start));

            using (var streamWriter = new StreamWriter(@"example_result.html"))
            {
                streamWriter.Write(html);
            }
            Console.WriteLine("Write done... ".PadRight(30, ' ') + (DateTime.Now - start));

            Thread.Sleep(3000);
            Console.WriteLine("Sync sleep done... ".PadRight(30, ' ') + (DateTime.Now - start));
        }

        // Asynchronous processing - retuns void:
        // Good practice states to give suffix of "Async" to method name.
        // It must return Task and be "async".
        // Async tells compiler that this method contains stuff that may take time, and allows to use "await" inside of it.
        public async Task DownloadHTMLAsync(string url, DateTime start)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);
            Console.WriteLine("HTML downladed... ".PadRight(30, ' ') + (DateTime.Now - start));

            using (var streamWriter = new StreamWriter(@"example_result.html"))
            {
                streamWriter.Write(html);
            }
            Console.WriteLine("Write done... ".PadRight(30, ' ') + (DateTime.Now - start));

            Thread.Sleep(3000);
            Console.WriteLine("Async sleep done... ".PadRight(30, ' ') + (DateTime.Now - start));
        }

    }
}
