using System;

using System.Collections.Generic;

abstract public class Personage
{
	protected string myName;
	private ConsoleColor color; 
	protected int pointsOfLife;
	protected List<string> actions;
	protected Personage target;

	public Personage(string name = "Unknown", ConsoleColor c = ConsoleColor.White)
	{
		myName = name;
		color = c;

		pointsOfLife = 100;

		actions = new List<string>();
		target = null;
	}

	public int life { get { return pointsOfLife; } }

	public string name {  get { return myName; } }

	public void displayName()
	{
		Console.ForegroundColor = color;
		Console.Write(myName);
		Console.ForegroundColor = ConsoleColor.White;
	}

	public bool isAlive {  get { return (pointsOfLife > 0); } }

	public void getHurt(int points)
	{
		if (points <= 0)
			return;

		if (pointsOfLife - points < 0)
			points = pointsOfLife;

		pointsOfLife -= points;
		displayName(); Console.WriteLine(" got hurt and lost " + points + " points of life");
		Console.WriteLine("New points of life : " + pointsOfLife);
		Console.WriteLine();
	}

	abstract public bool nextMove(Dice dice);

	public void defineTarget(Personage p)
	{
		target = p;
	}

}
