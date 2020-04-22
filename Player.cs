using System;
using System.Collections.Generic;

public class Player : Personage, IFighter
{
	private int pointsOfExp;
	protected List<string> actions;
	protected List<string> fightActions;

	public int exp { get { return pointsOfExp; } }
	
	public Player () : base ("The player", ConsoleColor.DarkBlue)
	{
		Display.write("Enter your name : " + Environment.NewLine);
		name = Display.string_input(ConsoleColor.DarkBlue);
		Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);

		actions = new List<string>();
		actions.Add("Attack");
		fightActions = new List<string>();
		fightActions.Add("Stroke");

		pointsOfExp = 0;
	}

	override public List<string> getStats()
	{
		List<string> stats = base.getStats();

		stats.Add("Exp :" + pointsOfExp);

		return stats;
	}

	public gameAction nextMove(List<gameAction> gas)
	{
		int playerChoice = -1;

		Display.write("Which action do you choose?" + Environment.NewLine);

		for (int i = 0; i < gas.Count; i++)
		{
			Display.write((i + 1) + ". " + gas[i].name + Environment.NewLine);
		}

		while (!Int32.TryParse(Display.string_input(), out playerChoice)
			|| playerChoice <= 0 || playerChoice > gas.Count)
		{
			Display.write("Wrong answer. Please, retype!" + Environment.NewLine);
		}
		Display.write(Environment.NewLine);

		return gas[playerChoice - 1];
	}

	private bool nextAction(Dice dice)
	{
		return true;
	}

	public bool nextFightAction (Dice dice)
	{
		int playerChoose = -1;

		Display.write("Which action do you choose?" + Environment.NewLine);
		for (int i = 0; i < actions.Count; i++)
		{
			Display.write(i + 1 + ". " + fightActions[i] + Environment.NewLine);
		}

		while (!Int32.TryParse(Display.string_input(), out playerChoose)
			|| playerChoose <= 0 || playerChoose > actions.Count)
		{
			Display.write("Wrong answer. Please, retype!" + Environment.NewLine);
		}

		if (playerChoose == 1)
			stroke(dice);

		return isAlive;
	}

	public void defineTarget(IFighter p)
	{
		target = p as Personage;
	}

	private void stroke (Dice dice)
	{
		Display.newFightScreen();
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
