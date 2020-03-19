using System;

namespace Humans_and_Monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display title
            for (int i = 0; i < 3; i++)
                Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Humans and Monsters");
            for (int i = 0; i < 3; i++)
                Console.WriteLine(Environment.NewLine);

            // Start a new game
            Game game = new Game();

            // Display end of the program
            Console.WriteLine("The game is now over.");
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey(true);
        }
    }
}


