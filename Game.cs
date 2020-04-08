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
		Display.SetStoryMode();
		Display.write("You are in a room."); Display.write(Environment.NewLine);
		Display.write("A monster enters in the room."); Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
		Display.wait();

		// Play game
		while (continueGame)
		{
			if (!player.nextMove(dice))
			{
				Display.SetStoryMode();
				Display.write("You are dead!" + Environment.NewLine, ConsoleColor.DarkRed);
				Display.write(Environment.NewLine);
				endOfGame();
				break;
			}

			if (!monster.nextMove(dice))
			{
				Display.SetStoryMode();
				Display.write("The monster is dead." + Environment.NewLine);
				
				// Create a new monster
				monster = new bigMonster("The monster");
				monster.defineTarget(player);
				player.defineTarget(monster);
				Display.write("A new monster enters in the room." + Environment.NewLine);
				Display.write(Environment.NewLine);
				Display.wait();
			}

		} // while continue game

	} // constructor Game()

	private void endOfGame()
	{
		Display.SetStoryMode();
		Display.write("Your final stats : " + Environment.NewLine);

		foreach (string s in player.getStats())
			Display.write(s + Environment.NewLine);
		Display.write(Environment.NewLine);
	}


} // class Game
