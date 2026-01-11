using System;
using Inventory.Messages;
namespace Inventory.Prompts
{
    public class AddProductPrompter
    {
        public static Product PromptProductsDetails()
        {
            // prompt user for  all the product information
            Console.WriteLine("What product would you like to add to the store >");
            string ProductName = Console.ReadLine();
            Console.Write("Specify the product price > ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Specify the product quantity > ");
            int _quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Is " + ProductName + " available at the moment ? yes/no > ");
            string response = Console.ReadLine();
            bool availabilityStatus = response.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
            // add new product into the store products list
            Product product = new() { Name = ProductName, IsAvailable = availabilityStatus, Price = price, Quantity = _quantity };
            Console.WriteLine("please wait...");
            return product;

        }

    }
}