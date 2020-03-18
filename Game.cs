using System;

using System.Collections.Generic;

public class Game
{

	public Game()
	{
		bool continueGame = true; // continueGame
		Player player = new Player(); // Player
		Dice dice = new Dice(); //Dice
		Monster monster = new Monster("The monster"); // Monster
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
			player.nextMove();

			monster.nextMove();

			if (!player.isAlive)
			{
				Console.WriteLine("You are dead!");
				Console.WriteLine(Environment.NewLine);
				break;
			}

			if (!monster.isAlive)
			{
				Console.WriteLine("The monster is dead.");
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("A new monster enters in the room.");
				Console.WriteLine(Environment.NewLine);
				monster = new Monster("The monster");
				monster.defineTarget(player);
				player.defineTarget(monster);
			}

		} // while continue game

	} // constructor Game()

} // class Game
