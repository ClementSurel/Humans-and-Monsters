using System;

public class GameAction
{
	public string name { get; }
	public delegate bool actionFunction ();
	protected actionFunction actionf ;
	
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

public class GameActionFight : GameAction
{
	private Player player;
	private IFighter opponent;
	private Dice dice;

	public GameActionFight(Player p, IFighter opp, Dice d) : base ("Attack", null)
	{
		actionf = executeFight;
		player = p;
		opponent = opp;
		dice = d;
	}

	private bool executeFight ()
	{
		player.defineTarget(opponent);
		opponent.defineTarget(player);

		Display.setFightMode(player, opponent);

		while (true)
		{
			if (player.isAlive)
				player.nextFightAction(dice);
			else
				break;

			if (opponent.isAlive)
			{
				Display.newFightScreen();
				opponent.nextFightAction(dice);
			}
			else
				break;
		}

		Display.SetStoryMode();
		return player.isAlive;
	}

}
