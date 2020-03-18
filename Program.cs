using System;

namespace TP_Humans_and_Monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Humans and Monsters" + Environment.NewLine);

            Game game = new Game();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("The game is now over.");
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey(true);
        }
    }
}


