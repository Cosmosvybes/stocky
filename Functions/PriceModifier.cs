using System;
using Inventory.Messages;
using Inventory;
using System.Threading.Tasks;
using Inventory.Functions;
namespace Inventory.Functions
{
    public class PriceModifier
    {
        public static async Task UpdatePrice()
        {

            Console.WriteLine("Specify the store you want update its product price");
            // get the store name
            string StoreName = Console.ReadLine();

            //look for the store name 
            Store store = Stocky.stores.Find(s => s.Name == StoreName);
            if (store != null)
            {
                // get product name
                Console.WriteLine("Specify the the product name: ");
                string ProductName = Console.ReadLine();
                Product product = store.ProductList.Find(p => p.Name == ProductName);
                if (product != null)
                {
                    // get the product new price
                    Console.WriteLine("Specify new price for the product");
                    double NewPrice = Convert.ToDouble(Console.ReadLine());
                    await store.UpdateProductPrice(product, NewPrice);
                    Brain.SaveData();
                }
                else
                {
                    Console.WriteLine("Product not found");
                    StandardMessages.LineMessageConsole();
               
                }
            }
            else
            {
                Console.WriteLine(404 + " Store not found");
                StandardMessages.LineMessageConsole();
            }
        }

    }
}