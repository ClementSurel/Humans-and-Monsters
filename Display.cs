using System;
using System.Collections.Generic;


public class Display
{
	public Display()
	{
	}

	static public void fight(Personage a, Personage b)
	{
		Personage m;
		if (b is Player)
		{
			m = a;
			a = b;
			b = m;
		}

		Console.Clear();
		List<string> statsa = a.getStats();
		List<string> statsb = b.getStats();

		int wa = 0, ha = 0, wb = 0, hb = 0;

		a.displayName(); Console.WriteLine();
		wa = a.name.Length;
		ha++;
		foreach (string line in statsa)
		{
			if (wa < line.Length)
				wa = line.Length;
			ha++;
			Console.WriteLine(line);
		}

		b.displayName(); Console.WriteLine();
		wb = b.name.Length;
		hb++;
		foreach (string line in statsb)
		{
			if (wb < line.Length)
				wb = line.Length;
			hb++;
			Console.WriteLine(line);
		}

		if (Console.BufferWidth < wa + wb + 1)
			Console.BufferWidth = wa + wb + 1;
		Console.MoveBufferArea(0, ha, wb, hb, Console.WindowWidth - wb, 0);

	}
}
