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
            string gotHtml = "";

            // Synchronous model:
            /*
            Console.WriteLine("\tSynchronous:");
            Console.WriteLine("Processing started...");
            htmlStuff.DownloadHTML("https://learn.microsoft.com/en-ca/", begin);
            Console.WriteLine("Processing is done. ".PadRight(30, ' ') + (DateTime.Now - begin));
            */

            // Asynchronous model:
            /*
            Console.WriteLine("\n\tAsynchronous:");
            begin = DateTime.Now;
            Console.WriteLine("Processing started...");
            // Compiler suggests to use await here as well. To use it, Run() would have to be async.
            // All of that would cause to runtime reach the end of program, and thus cancelling all awaited processes.
            // Without await / async at this level here, Program will have to wait until intermediate.Study06.Study06.Run() actually ends. 
            // Console.Read() here at the end stops this method from finishing prematurely, otherwise it would end too quick as well, since 
            // control would reach end of function, go back to Main(), and from there to the end.
            htmlStuff.DownloadHTMLAsync("https://learn.microsoft.com/en-ca/", begin);
            Console.WriteLine("Processing is done. ".PadRight(30, ' ') + (DateTime.Now - begin));
            Console.Read();
            */

            // Synchronous model - return string:
            Console.WriteLine("\tSynchronous with return:");
            begin = DateTime.Now;
            Console.WriteLine("Processing started...");
            gotHtml = htmlStuff.GetHTML("https://learn.microsoft.com/en-ca/", begin).Substring(0,30);
            Console.WriteLine("Processing is done. ".PadRight(30, ' ') + (DateTime.Now - begin));
            Console.WriteLine("Saved string: " + gotHtml);
        }
    }

    internal class HTMLStuff
    {
        // Synchronous processing - returns void:
        public void DownloadHTML(string url, DateTime start)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadStringTaskAsync(url);
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
            // .DownloadStringAsync is old legacy method, that has nothing to do with async await.
            // Usage of methods that are designed to work with async / await is required, with them usage of these keywords is allowed.
            //
            // await gives compiler info that this task will take time to do. When it gets here, control will immediately return to the place where 
            // method was invoked and will run the rest of the code. It will remeber this place however, and when it receives info that the task
            // is completed, it will return here to continue with the method execution.
            //
            // It partitiones this block of code to as many as there are await keywords, and makes it work with callback functions. It's under the hood.
            //
            var html = await webClient.DownloadStringTaskAsync(url);
            Console.WriteLine("HTML downladed... ".PadRight(30, ' ') + (DateTime.Now - start));

            using (var streamWriter = new StreamWriter(@"example_result.html"))
            {
                // streamWriter.Write is also blocking operation, so it comes with Async version and can be awaited.
                await streamWriter.WriteAsync(html);
            }
            Console.WriteLine("Write done... ".PadRight(30, ' ') + (DateTime.Now - start));

            await Task.Delay(3000);
            Console.WriteLine("Async sleep done... ".PadRight(30, ' ') + (DateTime.Now - start));
        }

        // Synchronous processing - returns string:
        public string GetHTML(string url, DateTime start)
        {
            var webClient = new WebClient();
            Console.WriteLine("HTML downladed... ".PadRight(30, ' ') + (DateTime.Now - start));

            Thread.Sleep(3000);
            Console.WriteLine("Sync sleep done... ".PadRight(30, ' ') + (DateTime.Now - start));

            return webClient.DownloadString(url);
        }
    }
}
