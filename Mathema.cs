using System;
namespace Gamathics
{
    class Game
    {
        static void Main(string[] args)
        {

            Initializer();
            int totalQuestions = 2;
            int scores = MathEngine();
            switch (scores)
            {
                case 2:
                    Console.WriteLine("You scored " + scores + " / " + totalQuestions + " total questions");
                    break;
                case 1:
                    Console.WriteLine("You scored " + scores + " / " + totalQuestions + " total questions");
                    break;
                default:
                    Console.WriteLine("You didnt play the game!");
                    break;
            }

        }

        static void Initializer()
        {
            Console.Title = "Gamathics";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("Hello this is gamathics , your mathematics game, press any key to start!");
            Console.ReadKey();
        }

        static int MathEngine()
        {
            int scores = 0;
            Console.Write("2 + 2 * 5 = ? ");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer != 20)
            {
                Console.WriteLine("wrong , you miss this");
            }

            else if (answer == 20)
            {
                scores++;
                Console.WriteLine("Correct");

            }
            Console.Write("9 / 3 * 1 = ?");
            answer = Convert.ToInt32(Console.ReadLine());
            if (answer != 1)
            {
                Console.WriteLine("Wrong, you miss this");
            }
            else if (answer == 1)
            {
                scores++;
                Console.WriteLine("Correct");

            }
            return scores;
        }
    }

}