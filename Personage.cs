using System;
using System.Collections.Generic;

abstract public class Personage
{
	public string name { get; protected set; }
	private ConsoleColor color; 
	public int life { get; protected set; }
	public bool isAlive { get { return (life > 0); } }
	protected List<string> actions;
	protected Personage target;

	public Personage(string name = "Unknown", ConsoleColor c = ConsoleColor.White)
	{
		this.name = name;
		color = c;

		life = 100;

		actions = new List<string>();
		target = null;
	}

	public void displayName()
	{
		Console.ForegroundColor = color;
		Console.Write(name);
		Console.ForegroundColor = ConsoleColor.White;
	}

	public void getHurt(int points)
	{
		if (points <= 0)
			return;

		if (life - points < 0)
			points = life;

		life -= points;
		displayName(); Console.WriteLine(" got hurt and lost " + points + " points of life");
		Console.Write("..."); Console.ReadKey();
		Display.fight(this, target);
	}

	abstract public bool nextMove(Dice dice);

	public void defineTarget(Personage p)
	{
		target = p;
	}

	void displayStats()
	{
		displayName(); Console.WriteLine(" :");
		Console.Write("Life : "); Console.WriteLine(life);
	}

	virtual public List<string> getStats()
	{
		List<string> stats = new List<string>();
		stats.Add("Life : " + life);

		return stats;
	}
}
