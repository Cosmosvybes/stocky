using System;
using System.Threading.Tasks;
using Inventory.Messages;
namespace Inventory.Prompts
{
    public class Engine
    {
        public static async Task HandleAsyncCLiPrompt()
        {
            while (true)
            {
                string input = StandardMessages.PromptMessage();
                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase)) break;
                await PromptSwitchEngine.SwitchPrompt(input);
            }
        }
    }
}