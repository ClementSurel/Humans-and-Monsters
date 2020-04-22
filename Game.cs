using System;

using System.Collections.Generic;

public class Game
{
	Player player;

	public Game()
	{
		player = new Player(); // Player
		Dice dice = new Dice(); //Dice

		// Start
		Display.SetStoryMode();
		Display.write("You are in a room."); Display.write(Environment.NewLine);

		// A little monster enters in the room
		Monster monster = new littleMonster("The monster");

		Display.write("A monster enters in the room."); Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
		Display.wait();

		List<gameAction> listOfgA = new List<gameAction>();
		listOfgA.Add(new gA_fight(player, monster));
		listOfgA.Add(new gA_runAway(player, monster));

		gameAction choosenAction = player.nextMove(listOfgA);

		choosenAction.execute(dice);

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

	private void endOfGame()
	{
		Display.SetStoryMode();
		Display.write("Your final stats : " + Environment.NewLine);

		foreach (string s in player.getStats())
			Display.write(s + Environment.NewLine);
		Display.write(Environment.NewLine);
	}

} // class Game



public abstract class gameAction
{
	public string name { get; protected set; }

	abstract public bool execute(Dice dice);
}

public class gA_fight : gameAction
{
	private Player player;
	private IFighter opp;

	public gA_fight(Player p, IFighter opponent)
	{
		name = "Attack";
		player = p;
		opp = opponent;
	}

	override public bool execute (Dice dice)
	{
		player.defineTarget(opp);
		opp.defineTarget(player);

		Display.setFightMode(player, opp as Personage);

		while (true)
		{
			if (player.isAlive)
				player.nextFightAction(dice);
			else
				break;

			if (opp.isAlive)
			{
				Display.newFightScreen();
				opp.nextFightAction(dice);
			}
			else
				break;
		}

		Display.SetStoryMode();
		return player.isAlive;
	}
}

public class gA_runAway : gameAction
{
	Player player;
	Personage opp;
	public gA_runAway (Player p, Personage opp)
	{
		name = "Run away!!!";
		player = p;
		this.opp = opp;
	}

	override public bool execute (Dice dice)
	{
		Display.write("You run away from "); Display.write(opp.name, opp.color); Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
		for (int i = 0; i < 3; i++)
		{
			Display.write("..." + Environment.NewLine);
			Display.write(Environment.NewLine);
			Display.wait();
		}
		Display.write("Unfortunately, "); Display.wait();
		Display.write(opp.name, opp.color); Display.write(" catches you!"); Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
		Display.wait();

		player.getHurt(100);
		Display.write("..." + Environment.NewLine);
		Display.write(Environment.NewLine);

		return false;
	}
}
