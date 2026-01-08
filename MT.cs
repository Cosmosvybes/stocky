using System;
namespace Dicey
{

    class DiceyEngine
    {


        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hey welcome to dicey, your awesome dice game, Pressany key to start");
            Console.WriteLine("Press 1 to play SumTWelve , Press 2 to Play AboveSix");
            int gameType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your stake amount: ");
            stake = Convert.ToInt32(Console.ReadLine());
            int result;

            switch (gameType)
            {
                case 1:
                    result = SumTwelve();
                    break;
                case 2:
                    if (stake < 10)
                    {
                        Console.WriteLine("Insufficient staking balance, fund your account");
                        return;
                    }
                    result = AboveTen();
                    break;
                default:
                    Console.WriteLine("You did not choose any game");
                    break;
            }
        }
     

        static int SumTwelve()
        {

            Console.WriteLine("Press any key to roll your dice");
            Random randomEngine = new();
            int diceOne = 0;
            int diceTwo = 0;
            int attempts = 0;
            while ((diceOne + diceTwo) != 12)
            {

                Console.ReadKey();
                diceOne = Convert.ToInt32(randomEngine.Next(1, 7));
                diceTwo = Convert.ToInt32(randomEngine.Next(1, 7));
                Console.WriteLine("You rolled: " + (diceOne + diceTwo));
                attempts++;
            }
            Console.WriteLine("Yippeee!! You rolled the dice " + attempts + " times before you got score equals to 12");
            return diceOne + diceTwo;
        }
        static int AboveTen()
        {

            Console.WriteLine("Press any key to start rolling your dice");
            Random randomeEngine = new();
            int diceOne = 0;
            int diceTwo = 0;

            int attempts = 0;
            while ((diceOne + diceTwo) < 10)
            {
                Console.ReadKey();
                diceOne = randomeEngine.Next(1, 7);
                diceTwo = randomeEngine.Next(1, 7);
                Console.WriteLine("You rolled: " + (diceOne + diceTwo));
                attempts++;
            }
            Console.WriteLine("Yippee, you won the AboveTen game after " + attempts + " attempts");
            return diceOne + diceTwo;
        }
    }

}