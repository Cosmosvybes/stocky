using System.Threading.Tasks;
using System.Collections.Generic;
using Inventory.Prompts;
using Inventory.Messages;
using Inventory.Functions;
namespace Inventory
{
    class Stocky
    {
        public static List<Store> stores = [];
        public const string FileName = "inventory_data.json";
        static async Task Main(string[] args)
        {
            Brain.ReadData();
            StandardMessages.InitializerMessage();
            await Engine.HandleAsyncCLiPrompt();
        }

    }
}