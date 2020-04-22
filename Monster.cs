using System;

abstract public class Monster : Personage, IFighter
{
	protected int pointsOfAggressivity;

	public int aggressivity { get { return pointsOfAggressivity;} }


	public Monster(string name = "unknown") : base(name, ConsoleColor.DarkRed)
	{
	}

	public bool nextMove(Dice dice)
	{
		if (isAlive)
			nextFightAction(dice);

		return isAlive;
	}
	public void defineTarget(IFighter p)
	{
		target = p as Personage;
	}

	public bool nextFightAction(Dice dice)
	{
		Display.write(name, color); Display.write(" attacks "); Display.write(target.name, target.color); Display.write(Environment.NewLine);
		Display.write(name, color); Display.write(" throws a dice of 10... ");
		Display.write(dice.throwDice10() + Environment.NewLine);

		target.getHurt(dice.scoreDice10);

		return isAlive;
	}
}

public class littleMonster : Monster
{
	public littleMonster(string name = "Unknown") : base(name)
	{
		pointsOfAggressivity = 2;
	}

}

public class bigMonster : Monster
{
	public bigMonster(string name = "Unknown") : base(name)
	{
		pointsOfAggressivity = 5;
	}
}

