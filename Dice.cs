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
		lastScore = rand.Next(1, 6);

		return lastScore;
	}

	public int throwDice10()
	{
		lastScoreDice10 = rand.Next(1, 10);

		return lastScoreDice10;
	}
}
