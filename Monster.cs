using System;

public class Monster : Personage
{
	public Monster(string name = "unknown") : base(name)
	{
	}

	override public void nextMove()
	{
		if (isAlive)
			attack();
	}

	public void attack()
	{
		Console.WriteLine(myName + " attacks " + target.name);
		target.getHurt(8);
	}

}
