using System;
using Inventory.Messages;
using Inventory;
namespace Inventory.Functions
{
    public class Getter
    {
        public static void GetProducts()
        {
            Console.WriteLine("Which store do you want to read ?");
            string StoreName = Console.ReadLine();
            Store store = Stocky.stores.Find(s => s.Name == StoreName);
            if (store != null)
            {
                Console.WriteLine(store.Name + " Found, would you like to see the products available in this store : yes/no ?");
                string response = Console.ReadLine();
                bool yes = response.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
                if (yes)
                {
                    if (store.ProductList.Count > 0)
                    {
                        for (int i = 0; i < store.ProductList.Count; i++)
                        {
                            int rank = i + 1;
                            Console.WriteLine(rank + ". " + store.ProductList[i].Name + " price " + store.ProductList[i].Price + " naira" + " Available quantity is " + store.ProductList[i].Quantity);
                        }
                        Console.WriteLine(200 + " OK ✅");
                        StandardMessages.LineMessageConsole();
                    }
                    else
                    {
                        Console.WriteLine(404 + " No product found");
                        StandardMessages.LineMessageConsole();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("Sorry store specified not found");
                StandardMessages.LineMessageConsole();
            }

        }
    }
}