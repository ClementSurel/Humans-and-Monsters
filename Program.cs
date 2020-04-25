using System;

namespace Humans_and_Monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "Y";
            bool continueProg = true;

            while (continueProg)
            {
                Display.title();

                // Start a new game
                Game game = new Game();

                do
                {
                    Display.write("Do you want to play a new game? (Y=yes, N=no) "); userInput = Display.getInput().ToUpper();
                    if (userInput == "Y")
                        continueProg = true;
                    else if (userInput == "N")
                        continueProg = false;
                } while (userInput != "Y" && userInput != "N");
            }

        }
    }
}


