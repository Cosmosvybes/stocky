using System;
namespace Inventory.Prompts
{
    public class StoreNamePrompter
    {
        public static string GetStoreName()
        {
            Console.WriteLine("Which store would you like this product to be stored ?");
            string StoreName = Console.ReadLine();
            return StoreName;
        }
    }
}