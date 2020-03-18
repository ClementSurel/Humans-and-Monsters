using System;

using System.Collections.Generic;

abstract public class Personage
{
	protected string myName; 
	protected int pointsOfLife;
	protected List<Action> actions;
	protected Personage target;

	public Personage(string name = "Unknown")
	{
		myName = name;
		pointsOfLife = 100;

		actions = new List<Action>();
		target = null;
	}

	public int life { get { return pointsOfLife; } }

	public string name {  get { return myName; } }

	public bool isAlive {  get { return (pointsOfLife > 0); } }

	public void getHurt(int points)
	{
		if (points <= 0)
			return;

		if (pointsOfLife - points < 0)
			points = pointsOfLife;
		pointsOfLife -= points;
		Console.WriteLine(myName + " got hurt and lost " + points + " points of life");
		Console.WriteLine("New points of life : " + pointsOfLife);
		Console.WriteLine(Environment.NewLine);
	}

	abstract public void nextMove();

	public void defineTarget(Personage p)
	{
		target = p;
	}

}
