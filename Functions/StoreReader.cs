using System;
using Inventory;
using Inventory.Messages;
namespace Inventory.Functions
{
    public class StoreReader
    {
        public static void GetStores()
        {
            if (Stocky.stores.Count > 0)
                for (int i = 0; i < Stocky.stores.Count; i++)
                {
                    int rank = i + 1;
                    Console.WriteLine(rank + " " + Stocky.stores[i].Name);
                    StandardMessages.LineMessageConsole();
                }
            else
            {
                Console.WriteLine("No stores yet");
                StandardMessages.LineMessageConsole();
            }
        }
    }
}