using NspKprint;

namespace intermediate.Study05
{
    internal class Study05
    {
        public static void Run()
        {
            /*
             * **** Exception handling ****
             */

            // https://learn.microsoft.com/en-us/dotnet/core/introduction
            // "A crashed app is more reliable and diagnosable than an app with undefined behavior."

            // Good practice is to have entire base class / file inside try catch block. That would be Program.Main() in this case.

            StreamReader stream = null;
            try
            {
                // Things that may throw exception
                // Exepction consist of properties:
                // * Data           - additional data of exception
                // * InnerException - nested exception
                // * Message        - message of exception
                // * Source         - where did it come from (in example namespace)
                // * StackTrace     - stack trace
                // * TargetSite     - which method caused exception
                using (StreamReader stream2 = null)
                {
                    // Finally will be called at the end of this block and close the stream.
                }

                // Throw exception of InvalidOperationException type
                throw new InvalidOperationException("Throwing an exception of InvalidOperationException type");
            }
            catch (DivideByZeroException ex)
            {
                // More detailed exceptions catched

                Console.WriteLine("More detailed exceptions catched");
            }
            catch (Exception ex) 
            {
                // Most generic exception catched
                Console.WriteLine("Most generic exception catched");

                // Throw custom exception and set innerException to whatever led runtime in here.
                // Commonly used technique, where developers will inspect exception and look into innerException 
                // and so on, until they get to core of it and see what caused an exception.
                throw new CustomException("Throwing Custom exception", ex);
            }
            finally
            {
                // This will always run, and is commonly used to close streams and things not managed by CLR. 
                // It's better to use "using statement" instead of doing it in "finally". it will do so under the hood.
                // If unmanaged resource is not closed, it may cause files or connections to be not closed,
                // and files may appear as being used, while they are not.
                Console.WriteLine("Finally block reached");
                if (stream != null)
                {
                    stream.Dispose();  // or .Close()
                }
            }
        }

        public class CustomException : Exception
        {
            public CustomException(string message, Exception innerException) : base(message, innerException)
            {
                // This is enough to create custom exception
            }
        }
    }
}
