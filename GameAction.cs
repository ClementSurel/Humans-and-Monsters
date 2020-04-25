using System;

public class GameAction
{
	private string name;
	public delegate bool actionFunction ();
	private actionFunction actionf ;
	
	public GameAction(string name, actionFunction f)
	{
		this.name = name;
		actionf = f;
	}

	public bool execute ()
	{
		return actionf();
	}
}
