﻿using System;
using System.Collections.Generic;


public interface IFighter
{
	public string name { get;}
	public ConsoleColor color { get; }
	public bool isAlive { get; }
	bool nextFightAction(Dice dice);

	public List<string> getStats();
	void defineTarget(IFighter opp);
}


abstract public class Personage
{
	public string name { get; protected set; }
	public ConsoleColor color { get; }
	public int life { get; protected set; }
	public bool isAlive { get { return (life > 0); } }
	protected Personage target;

	public Personage(string name = "Unknown", ConsoleColor c = ConsoleColor.White)
	{
		this.name = name;
		color = c;

		life = 100;

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


	virtual public List<string> getStats()
	{
		List<string> stats = new List<string>();
		stats.Add("Life : " + life);

		return stats;
	}
}
