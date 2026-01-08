using System;
namespace MultiplicationTable
{
    class Engine
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Which table would you like to count: ");
            int table = Convert.ToInt32(Console.ReadLine());

            Console.Write("How many table would you like to see multiplication for: ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                double result = table * i;
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
    }
}