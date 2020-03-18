using System;

public class Player : Personage
{
	private int pointsOfExp;

	public Player()
	{
		Console.WriteLine("Enter your name : ");
		Console.SetCursorPosition(1, Console.CursorTop);
		myName = Console.ReadLine();
		Console.WriteLine(Environment.NewLine + Environment.NewLine);

		actions.Add(new Action("Attack"));

		pointsOfExp = 0;
	}

	public int exp { get { return pointsOfExp; } }


	public void printStats()
	{
		Console.WriteLine("Name : " + myName);
		Console.WriteLine("Life : " + pointsOfLife);
		Console.WriteLine("Exp : " + pointsOfExp);
	}

	override public void nextMove()
	{
		int playerChoose = -1;

		Console.WriteLine("Which action do you choose?");
		
		for (int i = 0; i < actions.Count; i++)
		{
			Console.WriteLine(i+1 + ". " + actions[i].name);
		}

		Console.SetCursorPosition(1, Console.CursorTop);
		while (!Int32.TryParse(Console.ReadLine(), out playerChoose)
			|| playerChoose <= 0 || playerChoose > actions.Count)
		{
			Console.WriteLine("Wrong answer. Please, retype!");
			Console.SetCursorPosition(1, Console.CursorTop);
		}
		Console.WriteLine(Environment.NewLine);

		if (playerChoose == 1)
			attack();
	}

	public void attack ()
	{
		Console.WriteLine(myName + " attacks " + target.name);
		target.getHurt(10);
	}

}
