using System;
using System.Collections.Generic;

abstract public class Personage
{
	public string name { get; protected set; }
	public ConsoleColor color { get; }
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

	public void getHurt(int points)
	{
		if (points <= 0)
			return;

		if (life - points < 0)
			points = life;

		life -= points;
		Display.write(name, color); Display.write(" got hurt and lost " + points + " points of life" + Environment.NewLine);
		Display.write("..."); Display.wait();
		Display.write(Environment.NewLine);
		Display.write(Environment.NewLine);
	}

	abstract public bool nextMove(Dice dice);

	public void defineTarget(Personage p)
	{
		target = p;
	}

	virtual public List<string> getStats()
	{
		List<string> stats = new List<string>();
		stats.Add("Life : " + life);

		return stats;
	}
}
