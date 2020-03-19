using System;

using System.Collections.Generic;

public class Game
{
	Player player;

	public Game()
	{
		bool continueGame = true; // continueGame
		player = new Player(); // Player
		Dice dice = new Dice(); //Dice
		Monster monster = new littleMonster("The monster"); // Monster

		// Define the Personages' target
		monster.defineTarget(player);
		player.defineTarget(monster);

		// Start
		Console.WriteLine("Start a new game");
		Console.WriteLine(Environment.NewLine);
		Console.WriteLine("There is a monster in the room");
		Console.WriteLine(Environment.NewLine);

		// Play game
		while (continueGame)
		{
			if (!player.nextMove(dice))
			{
				Console.WriteLine("You are dead!");
				Console.WriteLine(Environment.NewLine);
				endOfGame();
				break;
			}

			if (!monster.nextMove(dice))
			{ 
				Console.WriteLine("The monster is dead.");
				Console.WriteLine(Environment.NewLine);
				
				// Create a new monster
				monster = new bigMonster("The monster");
				monster.defineTarget(player);
				player.defineTarget(monster);
				Console.WriteLine("A new monster enters in the room.");
				Console.WriteLine(Environment.NewLine);
			}

		} // while continue game

	} // constructor Game()

	private void endOfGame()
	{
		Console.WriteLine("Your final stats : ");
		Console.WriteLine(Environment.NewLine);
		player.printStats();
	}


} // class Game
