using System;
using System.Collections.Generic;

public class Player : Personage
{
	private int pointsOfExp;

	public int exp { get { return pointsOfExp; } }

	public Player() : base ("The player", ConsoleColor.DarkBlue)
	{
		Display.write("Enter your name : " + Environment.NewLine);
		name = Display.string_input(ConsoleColor.DarkBlue);
		Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);

		actions.Add("Attack");

		pointsOfExp = 0;
	}

	override public List<string> getStats()
	{
		List<string> stats = base.getStats();

		stats.Add("Exp :" + pointsOfExp);

		return stats;
	}

	override public bool nextMove(Dice dice)
	{
		if (!isAlive)
			return false;

		int playerChoose = -1;

		Display.write("Which action do you choose?" + Environment.NewLine);
		
		for (int i = 0; i < actions.Count; i++)
		{
			Display.write(i+1 + ". " + actions[i] + Environment.NewLine);
		}

		while (!Int32.TryParse(Display.string_input(), out playerChoose)
			|| playerChoose <= 0 || playerChoose > actions.Count)
		{
			Display.write("Wrong answer. Please, retype!" + Environment.NewLine);
		}

		if (playerChoose == 1)
			attack(dice);

		return isAlive;
	}

	public void attack (Dice dice)
	{
		Display.setFightMode(this, target);

		Display.write(name, color); Display.write(" attacks "); Display.write(target.name, target.color); Display.write(Environment.NewLine);
		Display.write(name, color); Display.write(" throws a dice of 10... ");
		Display.write(dice.throwDice10() + Environment.NewLine);

		target.getHurt(dice.scoreDice10);

		if (!target.isAlive)
		{
			Display.write(name, color); Display.write(" kills "); Display.write(target.name, target.color); Display.write(Environment.NewLine);
			Display.write(name, color); Display.write(" earns 1 point of experience." + Environment.NewLine);
			pointsOfExp += (target as Monster).aggressivity;
			target = null;
			Display.write(Environment.NewLine);
		}

	}

}
