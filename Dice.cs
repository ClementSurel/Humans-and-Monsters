using System;

public class Dice
{
	private int lastScoreDice10;
	private int lastScore;
	Random rand;
	
	public int score { get { return lastScore; } }

	public int scoreDice10 {  get { return lastScoreDice10; } }

	public Dice()
	{
		rand = new Random();
	}

	public int throwDice6()
	{
		lastScore = rand.Next(6) + 1;

		return lastScore;
	}

	public int throwDice10()
	{
		lastScoreDice10 = rand.Next(10) + 1;

		return lastScoreDice10;
	}
}
