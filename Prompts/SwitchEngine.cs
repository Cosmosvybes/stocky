using System;
using Inventory.Functions;
using System.Threading.Tasks;
namespace Inventory.Prompts
{
    public class PromptSwitchEngine
    {
        public static async Task SwitchPrompt(string prompt)
        {
            switch (prompt)
            {
                case "add":
                    await Adder.AddProduct();
                    Brain.SaveData();
                    break;
                case "products":
                    Getter.GetProducts();
                    break;
                case "del":
                    await Remover.RemoveProduct();
                    Brain.SaveData();
                    break;
                case "price":
                    await PriceModifier.UpdatePrice();
                    Brain.SaveData();
                    break;
                case "stores":
                    StoreReader.GetStores();

                    break;
                case "report":
                    await Logger.LogStoreProducteSales();
                    Brain.SaveData();
                    break;
                default:
                    Console.WriteLine("You do not specify any correct promts \nN.B Ensure you do not add why space to your command");
                    break;
            }
        }
    }
}