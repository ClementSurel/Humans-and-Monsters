using System;

using System.Collections.Generic;

public class Game
{
	Dice dice;
	private Player player;
	private Monster monster;

	public Game()
	{
		dice = new Dice();
		player = new Player();
		monster = new littleMonster("The monster");

		// Start
		Display.SetStoryMode();
		Display.write("You are in a room."); Display.write(Environment.NewLine);
		Display.write("A monster enters in the room."); Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
		Display.wait();

		List<GameAction> listOfGA = new List<GameAction>();
		listOfGA.Add(new GameActionFight(player, monster, dice));
		listOfGA.Add(new GameAction("Run away!!!", runAway));
		GameAction choosenAction = player.nextMove(listOfGA);
		choosenAction.execute();

		if (player.isAlive)
		{
			Display.write("You defeat the monster." + Environment.NewLine);
			Display.write("You win !!!" + Environment.NewLine, ConsoleColor.DarkRed);
			Display.write(Environment.NewLine);
			endOfGame();
		}
		else
		{
			Display.write("You are dead!" + Environment.NewLine, ConsoleColor.DarkRed);
			Display.write(Environment.NewLine);
			endOfGame();
		}
	}

	private bool runAway()
	{
		Display.write("You run away from "); Display.write(monster.name, monster.color); Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
		for (int i = 0; i < 3; i++)
		{
			Display.write("..." + Environment.NewLine);
			Display.write(Environment.NewLine);
			Display.wait();
		}
		Display.write("Unfortunately, "); Display.wait();
		Display.write(monster.name, monster.color); Display.write(" catches you!"); Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
		Display.wait();

		player.getHurt(100);
		Display.write("..." + Environment.NewLine);
		Display.write(Environment.NewLine);

		return false;
	}

	private void endOfGame()
	{
		Display.SetStoryMode();
		Display.write("Your final stats : " + Environment.NewLine);

		foreach (string s in player.getStats())
			Display.write(s + Environment.NewLine);
		Display.write(Environment.NewLine);
	}

} // class Game

