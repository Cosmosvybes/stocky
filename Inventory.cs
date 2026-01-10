using System;
using System.Threading.Tasks;

namespace Inventory
{
    class Stocky
    {
        static async Task Main(string[] args)
        {
            await HandleCLIPrompt();
        }


        public static async Task HandleCLIPrompt()
        {
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase())) break;
                if (input == "add")
                {

                    Console.WriteLine("Which store would you like this product to be stored ?");
                    string store_name = Console.ReadLine();
                    // create new store 
                    Store store = new() { Name = store_name, IsOpen = false, product_list = [] };
                    // prompt user for  all the product information
                    Console.WriteLine("What product would you like to add to the store ?");
                    string product = Console.ReadLine();
                    Console.Write("Specify the product price: ");
                    double price = Console.ReadLine();
                    Console.Write("Specify the product quantity: ");
                    int _quantity = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Is" + product + " available at the momemt ? yes/ no");
                    string response = Console.ReadLine();
                    bool availabilityStatus = response.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
                    // add new product into the store products list
                    store.AddSingleProduct(product, price, availabilityStatus, _quantity);

                }

            }
        }




    }
}