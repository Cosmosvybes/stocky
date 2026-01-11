using System;
using System.Threading.Tasks;
using Inventory.Prompts;
using Inventory.Messages;
namespace Inventory.Functions
{
    public class Adder
    {

        public static async Task AddProduct()
        {
            //check if store already exist 
            string StoreName = StoreNamePrompter.GetStoreName();
            Store store = new() { Name = StoreName };
            Product product = AddProductPrompter.PromptProductsDetails();
            Store existing_store = Stocky.stores.Find(s => s.Name == StoreName);
            await Task.Delay(2000);
            if (existing_store != null)
            {
                await existing_store.AddSingleProduct(product);
                Console.WriteLine(StoreName + " Updated with new product");
                StandardMessages.LineMessageConsole();
            }
            else
            {
                await store.AddSingleProduct(product);
                Stocky.stores.Add(store);
                Console.WriteLine("New store has been added");
                StandardMessages.LineMessageConsole();
            }
        }
    }
}