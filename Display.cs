using System;
using System.Collections.Generic;


public static class Display
{
	static private List<string> storyLines = new List<string>();
	static private List<string> fightLines = new List<string>();
	static private List<string> actLines = storyLines;
	static private int currentIndex = 0;
	static private int nWrittenLines = 0;

	static private ConsoleColor actColor = ConsoleColor.White;

	static private Player player = null;
	static private Personage opponent = null;

	public enum Mode { STORY, FIGHT }
	static private Mode actualMode = Mode.STORY;
	static private Mode lastMode = Mode.STORY;
	public enum Position { LEFT, CENTER}
	static private Position actPos = Position.LEFT;

	static private Mode mode
	{
		get 
		{
			return actualMode;
		}
		set
		{
			lastMode = actualMode;
			if (lastMode == Mode.STORY)
			{
				storyLines.Add(Environment.NewLine + Environment.NewLine);
				storyLines.Add("..." + Environment.NewLine);
				storyLines.Add(Environment.NewLine);
			}

			actualMode = value;
			if (value == Mode.STORY)
				actLines = storyLines;
			else
				actLines = fightLines;

			currentIndex = 0;
		}
	}

	static public void title()
	{
		for (int i = 0; i < 3; i++)
			write(Environment.NewLine);

		write("Humans and Monsters", ConsoleColor.DarkRed, Position.CENTER);
		
		for (int i = 0; i < 3; i++)
			write(Environment.NewLine);
	}

	static public void write(string line, ConsoleColor color = ConsoleColor.White, Position pos = Position.LEFT)
	{
		if (color != actColor)
		{
			switch (color)
			{
				case ConsoleColor.DarkRed:
					actLines.Add("<DR>");
					break;
				case ConsoleColor.DarkBlue:
					actLines.Add("<DB>");
					break;
				case ConsoleColor.White:
					actLines.Add("<W>");
					break;
				default:
					break;
			}
			actColor = color;
		}

		if (pos != actPos)
		{
			if (pos == Position.LEFT)
				actLines.Add("<LEFT>");
			else if (pos == Position.CENTER)
				actLines.Add("<CENTER>");

			actPos = pos;
		}

		actLines.Add(line);
	}

	static private void sendToConsole_raw()
	{
		if (currentIndex == 0)
		{
			if (mode == Mode.STORY)
			{
				Console.Clear();
				nWrittenLines = 0;
			}
			else if (mode == Mode.FIGHT)
			{
				nWrittenLines = updateStats();
			}
		}

		foreach (string line in actLines.GetRange(currentIndex, actLines.Count - currentIndex))
		{
				Console.Write(line);
		}

		Console.ReadKey();
	}

	static private void sendToConsole ()
	{
		// FOR DEBUG
		// sendToConsole_raw();

		actPos = Position.LEFT;
		int centerFrom = 0;
		int width = 0;

		if (currentIndex == 0)
		{ 
			if (mode == Mode.STORY)
			{
				Console.Clear();
				nWrittenLines = 0;
			}
			else if (mode == Mode.FIGHT)
			{ 
				nWrittenLines = updateStats();
			}
		}

		foreach (string line in actLines.GetRange(currentIndex, actLines.Count - currentIndex))
		{
			if (line == "<DR>")
				Console.ForegroundColor = ConsoleColor.DarkRed;
			else if (line == "<W>")
				Console.ForegroundColor = ConsoleColor.White;
			else if (line == "<DB>")
				Console.ForegroundColor = ConsoleColor.DarkBlue;
			else if (line == "<CENTER>")
			{
				if (actPos != Position.CENTER)
				{
					actPos = Position.CENTER;
					centerFrom = nWrittenLines;
					width = 0;
				}
			}
			else if (line == "<LEFT>")
			{
				switch (actPos)
				{
					case Position.CENTER:
						Console.MoveBufferArea(0, centerFrom, width, nWrittenLines - centerFrom,
							Console.WindowWidth/2 - width/2, centerFrom);
						break;
					default:
						break;
				}
				actPos = Position.LEFT;
			}
			else
			{
				Console.Write(line);
				width = line.Length;
				nWrittenLines++;
			}
			currentIndex++;
		}
	}

	static private int updateStats()
	{
		Console.Clear();

		List<string> playerStats = player.getStats();
		List<string> oppStats = opponent.getStats();

		int wp = 0, hp = 0, wo = 0, ho = 0;

		Console.ForegroundColor = player.color; Console.Write(player.name);
		Console.ForegroundColor = ConsoleColor.White; Console.WriteLine();
		wp = player.name.Length;
		hp++;
		foreach (string line in playerStats)
		{
			if (wp < line.Length)
				wp = line.Length;
			hp++;
			Console.WriteLine(line);
		}

		Console.ForegroundColor = opponent.color; Console.Write(opponent.name);
		Console.ForegroundColor = ConsoleColor.White; Console.WriteLine();
		wo = opponent.name.Length;
		ho++;
		foreach (string line in oppStats)
		{
			if (wo < line.Length)
				wo = line.Length;
			ho++;
			Console.WriteLine(line);
		}

		if (Console.BufferWidth < wp + wo + 1)
			Console.BufferWidth = wp + wo + 1;
		Console.MoveBufferArea(0, hp, wo, ho, Console.WindowWidth - wo, 0);

		return Math.Max(hp, ho);
	}

	static public void wait()
	{
		sendToConsole();
		Console.ReadKey(true);
	}

	static public string string_input(ConsoleColor color = ConsoleColor.White)
	{
		string input;

		sendToConsole();
		Console.ForegroundColor = color;
		Console.SetCursorPosition(2, Console.CursorTop);
		input = Console.ReadLine();
		if (color != actColor)
			currentIndex += 2;
		else
			currentIndex++;
		write("  " + input + Environment.NewLine, color);
		Console.ForegroundColor = actColor;

		return input;
	}

	static public void resetMode()
	{
		wait();
		mode = lastMode;
		currentIndex = 0;
	}

	static public void setFightMode(Player p, Personage opp)
	{
		mode = Mode.FIGHT;
		player = p;
		opponent = opp;

		fightLines.Clear();
	}

	static public void newFightScreen()
	{
		fightLines.Clear();
		currentIndex = 0;
	}

	static public void SetStoryMode()
	{
		if (actualMode != Mode.STORY)
			mode = Mode.STORY;
	}
}
