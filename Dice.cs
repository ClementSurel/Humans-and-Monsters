using System;

public class Dice
{
	private int lastScore;
	Random rand;
	public int score { get { return lastScore; } }

	public Dice()
	{
		rand = new Random();
	}

	public int throwDice()
	{
		lastScore = rand.Next(1, 6);
		Console.WriteLine("Dice has been thrown : " + lastScore);

		return lastScore;
	}
}
