using intermediate.Study01;
using intermediate.Study02;
using intermediate.Study03;
using intermediate.Study04;
using intermediate.Study05;
using intermediate.Study06;


namespace intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // intermediate.Study01.Study01.Run();
                // intermediate.Study02.Study02.Run();
                // intermediate.Study03.Study03.Run();
                // intermediate.Study04.Study04.Run();
                // intermediate.Study05.Study05.Run();
                intermediate.Study06.Study06.Run();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
