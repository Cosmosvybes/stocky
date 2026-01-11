using System;
using Inventory.Messages;
using System.Threading.Tasks;
namespace Inventory.Functions
{
    public class Logger
    {
        public static async Task LogStoreProducteSales()
        {
            Console.WriteLine("Specify the store you want want to log sales report for: ");
            string StoreName = Console.ReadLine();
            Store store = Stocky.stores.Find(s => s.Name == StoreName);
            if (store != null)
            {
                Console.WriteLine("Enter the product name >");
                string ProductName = Console.ReadLine();
                Product product = store.ProductList.Find(p => p.Name == ProductName);
                if (product != null)
                {
                    Console.WriteLine("What's the quantity of " + product.Name + " sold >");
                    int quatity_sold = Convert.ToInt32(Console.ReadLine());
                    await store.LogSales(product, quatity_sold);
                    StandardMessages.LineMessageConsole();
                }
                else
                {
                    Console.WriteLine("product not found");
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