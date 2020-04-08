using System;

namespace Humans_and_Monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.title();
            
            // Start a new game
            Game game = new Game();

            // Display end of the program
            Display.write("The game is now over." + Environment.NewLine);
            Display.write("Press any key to quit." + Environment.NewLine);
            Display.write(Environment.NewLine);
            Display.wait();
        }
    }
}


