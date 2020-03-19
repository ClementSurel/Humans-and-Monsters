using System;

abstract public class Monster : Personage
{
	protected int pointsOfAggressivity;

	public int aggressivity { get { return pointsOfAggressivity;} }

	

	public Monster(string name = "unknown") : base(name, ConsoleColor.DarkRed)
	{
	}

	override public bool nextMove(Dice dice)
	{
		if (isAlive)
			attack(dice);

		return isAlive;
	}

	public void attack(Dice dice)
	{
		displayName(); Console.Write(" attacks "); target.displayName(); Console.WriteLine();
		displayName(); Console.Write(" throws a dice of 10... ");
		Console.WriteLine(dice.throwDice10());

		target.getHurt(dice.scoreDice10);
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

