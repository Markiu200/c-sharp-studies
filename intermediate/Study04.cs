using NspKprint;

namespace intermediate.Study04
{
    internal class Study04
    {
        public static void Run()
        {
            /*
             * **** Events ****
             */

            // Events exercises:
            Kprint.FTitle("Events");
            // Events are basically using Delegates as properties.
            // You have a object that will be "publisher" - one who emits event,
            // and objects that will subscribe to that - "subscriber".
            //
            // What happens here is publisher have public property that is a delegate,
            // and subscribers add their own methods to that publicly accessible delegate.
            // 
            // When publisher "emits" event, it simply runs all methods saved in delegate.
            //
            // Here publisher will be BetterKasmok, and subscribers will be ForestKasmok. Check
            // their .cs for more comments actually.
            //
            // Steps are (for publisher)
            // 1 - Define a delegate
            // 2 - Define an event based on that delegate
            // 3 - Raise the event
            var whiteSmo = new BetterKasmok("Kasmok", new DateTime(1992, 12, 21));  // Publisher
            var forestSmoList = new List<ForestKasmok>()  // List of Subcribers
            {
                new ForestKasmok("Melon", new DateTime(1999, 4, 1)),
                new ForestKasmok("Spoon", new DateTime(2001, 1, 28)),
                new ForestKasmok("Fork", new DateTime(1996, 11, 12))
            };
            var individualForestSmo = new ForestKasmok("Nicpon", new DateTime(2004, 10, 11));

            foreach (var forestSmo in forestSmoList)
            {
                // Gor each subscriber add their method (literally) to publisher's delegate.
                whiteSmo.LightsOut += forestSmo.OnLightsOutEventHandler;
            }

            // Emit the event.
            whiteSmo.TurnTheLightsOff();
        }
    }
}
