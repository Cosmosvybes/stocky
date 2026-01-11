using System;
using Inventory;
using System.Threading.Tasks;
using Inventory.Messages;
namespace Inventory.Functions
{
    public class Remover
    {
        public static async Task RemoveProduct()
        {
            Console.WriteLine("Specify the store you want to remove Product from >");
            string StoreName = Console.ReadLine();
            Store store = Stocky.stores.Find(s => s.Name == StoreName);
            if (store != null)
            {
                Console.WriteLine("Store found, now specify the product name to be removed >");
                string ProductName = Console.ReadLine();
                Product product = store.ProductList.Find(p => p.Name == ProductName);
                if (product != null)
                    await store.DeleteProduct(product);
                else
                {
                    Console.WriteLine("Product does not exit");
                    StandardMessages.LineMessageConsole();
                }
            }
            else
            {
                Console.WriteLine("Store not found");
                StandardMessages.LineMessageConsole();
            }
        }
    }
}