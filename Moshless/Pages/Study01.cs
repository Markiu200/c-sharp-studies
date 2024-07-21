using intermediate;
using NspKprint;

namespace Moshless.Pages
{
    internal static class Study01
    {
        public static void Run()
        {
            BetterKasmok kasmok = new BetterKasmok("Kasmok", new DateTime(1992, 12, 12));
            Console.WriteLine($"Kasmok's name: {kasmok.Name}");
        }
    }
}
