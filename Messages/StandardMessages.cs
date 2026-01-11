using System;
using Inventory;
namespace Inventory.Messages
{
    public class StandardMessages
    {
        public static void InitializerMessage()
        {
            Console.Clear();
            Console.WriteLine("Hey Welcome to Stocky, you new Smart Inventory System");
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("What would like to do today?\nEnter 'add','products','del','price','stores','report' to use the Inventory system ");
        }

        public static string PromptMessage()
        {
            Console.Write("Prompt Stocky > ");
            string input = Console.ReadLine();
            return input;

        }
        public static void LineMessageConsole()
        {
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("_____________________________________________________");
        }
    }
}