using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Inventory
{
    class Stocky
    {
        private static readonly List<Store> stores = [];
        static async Task Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hey Welcome to Stocky, you new Smart Inventory System");
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("What would like to do today?\nEnter 'add','products','del','price','stores','report' to use the Inventory system ");
            await HandleCLIPrompt();
        }


        public static async Task HandleCLIPrompt()
        {
            while (true)
            {
                Console.Write("Prompt Stocky > ");
                string input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase)) break;
                switch (input)
                {
                    case "add":
                        await ProductAdder();
                        break;
                    case "products":
                        GetProducts();
                        break;
                    case "del":
                        RemoveProduct();
                        break;
                    case "price":

                        UpdatePrice();
                        break;
                    case "stores":
                        GetStores();
                        break;
                    case "report":
                        LogStoreProducteSales();
                        break;
                    default:
                        Console.WriteLine("You do not specify any correct \nN.B Ensure you do not add why space to your command");
                        break;
                }

            }
        }


        public static async Task ProductAdder()
        {
            Console.WriteLine("Which store would you like this product to be stored ?");
            string store_name = Console.ReadLine();
            //check if store already exist 
            Store existing_store = stores.Find(s => s.Name == store_name);
            // create new store 
            Store store = new() { Name = store_name };


            // prompt user for  all the product information
            Console.WriteLine("What product would you like to add to the store >");
            string product_name = Console.ReadLine();
            Console.Write("Specify the product price > ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Specify the product quantity > ");
            int _quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Is " + product_name + " available at the moment ? yes/no > ");
            string response = Console.ReadLine();
            bool availabilityStatus = response.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
            // add new product into the store products list
            Product product = new() { Name = product_name, IsAvailable = availabilityStatus, Price = price, Quantity = _quantity };
            Console.WriteLine("please wait...");
            Console.WriteLine("_____________________________________________________");
            await Task.Delay(2000);
            if (existing_store != null)
            {

                await existing_store.AddSingleProduct(product);
                Console.WriteLine(store_name + " Updated with new product");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("_____________________________________________________");

            }
            else
            {
                await store.AddSingleProduct(product);
                stores.Add(store);
                Console.WriteLine("New store has been added");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("_____________________________________________________");
            }
        }



        public static async Task GetProducts()
        {
            Console.WriteLine("Which store do you want to read ?");
            string store_name = Console.ReadLine();
            Store store = stores.Find(s => s.Name == store_name);

            if (store != null)
            {
                Console.WriteLine(store.Name + " Found, would you like to see the products available in this store : yes/no ?");
                string response = Console.ReadLine();
                bool yes = response.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
                if (yes)
                {
                    if (store.product_list.Count > 0)
                    {
                        for (int i = 0; i <= store.product_list.Count; i++)
                        {
                            int rank = i + 1;
                            Console.WriteLine(rank + ". " + store.product_list[i].Name + " price " + store.product_list[i].Price + " naira" + " Available quantity is " + store.product_list[i].Quantity);
                        }
                        Console.WriteLine(200 + " OK ✅");
                        Console.WriteLine("_____________________________________________________");
                        Console.WriteLine("_____________________________________________________");
                    }
                    else
                    {
                        Console.WriteLine(404 + " No product found");
                        Console.WriteLine("_____________________________________________________");
                        Console.WriteLine("_____________________________________________________");
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
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("_____________________________________________________");
            }

        }
        public static async Task RemoveProduct()
        {
            Console.WriteLine("Specify the store you want to remove Product from >");
            string store_name = Console.ReadLine();
            Store store = stores.Find(s => s.Name == store_name);
            if (store != null)
            {
                Console.WriteLine("Store found, now specify the product name to be removed >");
                string product_name = Console.ReadLine();
                Product product = store.product_list.Find(p => p.Name == product_name);
                if (product != null)
                    store.DeleteProduct(product);
                else
                {
                    Console.WriteLine("Product does not exit");
                    Console.WriteLine("_____________________________________________________");
                    Console.WriteLine("_____________________________________________________");
                }
            }
            else
            {
                Console.WriteLine("Store not found");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("_____________________________________________________");
            }
        }


        public static async Task UpdatePrice()
        {

            Console.WriteLine("Specify the store you want update its product price");
            // get the store name
            string store_name = Console.ReadLine();

            //look for the store name 
            Store store = stores.Find(s => s.Name == store_name);
            if (store != null)
            {
                // get product name
                Console.WriteLine("Specify the the product name: ");
                string product_name = Console.ReadLine();
                Product product = store.product_list.Find(p => p.Name == product_name);
                if (product != null)
                {
                    // get the product new price
                    Console.WriteLine("Specify new price for the product");
                    double new_price = Convert.ToDouble(Console.ReadLine());
                    await store.UpdateProductPrice(product, new_price);
                }
                else
                {
                    Console.WriteLine("Product not found");
                    Console.WriteLine("_____________________________________________________");
                    Console.WriteLine("_____________________________________________________");
                }
            }
            else
            {
                Console.WriteLine(404 + " Store not found");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("_____________________________________________________");
            }
        }

        public static void GetStores()
        {
            if (stores.Count > 0)
                for (int i = 0; i < stores.Count; i++)
                {
                    int rank = i + 1;
                    Console.WriteLine(rank + " " + stores[i].Name);
                    Console.WriteLine("_____________________________________________________");
                    Console.WriteLine("_____________________________________________________");
                }
            else
            {
                Console.WriteLine("No stores yet");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("_____________________________________________________");
            }
        }


        public static void LogStoreProducteSales()
        {
            Console.WriteLine("Specify the store you want want to log sales report for: ");
            string store_name = Console.ReadLine();
            Store store = stores.Find(s => s.Name == store_name);
            if (store != null)
            {
                Console.WriteLine("Enter the product name >");
                string product_name = Console.ReadLine();
                Product product = store.product_list.Find(p => p.Name == product_name);
                if (product != null)
                {
                    Console.WriteLine("What's the quantity of " + product.Name + " sold >");
                    int quatity_sold = Convert.ToInt32(Console.ReadLine());
                    store.LogSales(product, quatity_sold);
                    Console.WriteLine("_____________________________________________________");
                    Console.WriteLine("_____________________________________________________");
                }
                else
                {
                    Console.WriteLine("product not found");
                    Console.WriteLine("_____________________________________________________");
                    Console.WriteLine("_____________________________________________________");

                }
            }
            else
            {
                Console.WriteLine("Store not found");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("_____________________________________________________");
            }
        }

    }
}