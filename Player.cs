using System;
using System.Collections.Generic;

public class Player : Personage
{
	private int pointsOfExp;

	public int exp { get { return pointsOfExp; } }

	

	public Player() : base ("The player", ConsoleColor.DarkBlue)
	{
		Console.WriteLine("Enter your name : ");
		Console.SetCursorPosition(1, Console.CursorTop);
		Console.ForegroundColor = ConsoleColor.DarkBlue;
		name = Console.ReadLine();
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine(Environment.NewLine + Environment.NewLine);

		actions.Add("Attack");

		pointsOfExp = 0;
	}

	public void printStats()
	{
		displayName(); Console.WriteLine();
		Console.WriteLine("Life : " + life);
		Console.WriteLine("Exp : " + pointsOfExp);
		Console.WriteLine(Environment.NewLine);
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

		Console.WriteLine("Which action do you choose?");
		
		for (int i = 0; i < actions.Count; i++)
		{
			Console.WriteLine(i+1 + ". " + actions[i]);
		}

		Console.SetCursorPosition(1, Console.CursorTop);
		while (!Int32.TryParse(Console.ReadLine(), out playerChoose)
			|| playerChoose <= 0 || playerChoose > actions.Count)
		{
			Console.WriteLine("Wrong answer. Please, retype!");
			Console.SetCursorPosition(1, Console.CursorTop);
		}
		Console.WriteLine(Environment.NewLine);

		if (playerChoose == 1)
			attack(dice);

		return isAlive;
	}

	public void attack (Dice dice)
	{
		Display.fight(this, target);
		displayName(); Console.Write(" attacks "); target.displayName(); Console.Write(Environment.NewLine);
		displayName(); Console.Write(" throws a dice of 10... ");
		Console.WriteLine(dice.throwDice10());

		target.getHurt(dice.scoreDice10);

		if (!target.isAlive)
		{
			displayName(); Console.Write(" kills "); target.displayName(); Console.WriteLine();
			displayName(); Console.WriteLine(" earns 1 point of experience.");
			pointsOfExp += (target as Monster).aggressivity;
			target = null;
			Console.WriteLine(Environment.NewLine);
		}

	}

}
