using Back.Game;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Back.Dice
{
	public class AllDice : IAllDice
	{
		GreenDice greenDice = new GreenDice();
		YellowDice yellowDice = new YellowDice();
		RedDice redDice = new RedDice();

		public GreenDice GreenDice { get => greenDice; set => greenDice = value; }

		public YellowDice YellowDice { get => yellowDice; set => yellowDice = value; }

		public RedDice RedDice { get => redDice; set => redDice = value; }

		//public List<DiceSide> RollDice()
		//{
		//	List<DiceSide> rolledSides = new List<DiceSide>();
		//	Random random = new Random();
		//	IDice dice = null;
		//	int rollCount = 3;

		//	if (GameSingleton.instance.Game.Score.FootstepsCount > 0)
		//	{
		//		RollFootstepsDice(rolledSides);
		//		rollCount -= GameSingleton.instance.Game.Score.FootstepsCount;
		//		GameSingleton.instance.Game.Score.FootstepsCount = 0;   // reset because footsteps have just been rolled
		//	}

		//	// if less than 3 dice remain roll count needs to be limited to the amount of dice
		//	if (rollCount > GreenDice.Remaining + YellowDice.Remaining + RedDice.Remaining)
		//		rollCount = GreenDice.Remaining + YellowDice.Remaining + RedDice.Remaining;

		//	for (int i = 0; i < rollCount; i++)
		//	{
		//		// To reduce the possibility of getting the same number twice in a row if randomness is based on time
		//		Thread.Sleep(0);

		//		int number = random.Next(0, GreenDice.Remaining + YellowDice.Remaining + RedDice.Remaining);
		//		if (number < GreenDice.Remaining)
		//			dice = GreenDice;
		//		else if (number < (GreenDice.Remaining + YellowDice.Remaining))
		//			dice = YellowDice;
		//		else
		//			dice = RedDice;

		//		dice.Roll();

		//		rolledSides.Add(dice.Side);
		//	}

		//	return rolledSides;
		//}

		//private void RollFootstepsDice(List<DiceSide> rolledSides)
		//{
		//	/* Rolling reduces the remaining count and in the case of previous turns footsteps rolling 
		//	 it shouldn't be reduced, hence the increase in remaining dice. */
		//	GreenDice.Remaining += GreenDice.FootstepCount;
		//	YellowDice.Remaining += YellowDice.FootstepCount;
		//	RedDice.Remaining += RedDice.FootstepCount;

		//	// Put footsteps in separeate variables because if these rolls give footsteps and we check the count of footsteps 
		//	// INCLUDING the freshly rolled ones we would be rolling the footsteps from previous turn as well as the ones that
		//	// should be rolled in the next turn. So save the footsteps that should be rolled now, so that we don't include the 
		//	// potentially freshly rolled ones ones, that should wait for the next turn.
		//	int greenFootstepsCount = GreenDice.FootstepCount;
		//	int yellowFootstepsCount = YellowDice.FootstepCount;
		//	int redFootstepsCount = RedDice.FootstepCount;

		//	GreenDice.FootstepCount = 0;
		//	YellowDice.FootstepCount = 0;
		//	RedDice.FootstepCount = 0;

		//	while (greenFootstepsCount > 0)
		//	{
		//		greenFootstepsCount--;
		//		GreenDice.Roll();
		//		rolledSides.Add(GreenDice.Side);
		//	}

		//	while (yellowFootstepsCount > 0)
		//	{
		//		yellowFootstepsCount--;
		//		YellowDice.Roll();
		//		rolledSides.Add(YellowDice.Side);
		//	}

		//	while (redFootstepsCount > 0)
		//	{
		//		redFootstepsCount--;
		//		RedDice.Roll();
		//		rolledSides.Add(RedDice.Side);
		//	}
		//}

		//public void ResetDice()
		//{
		//	GreenDice.Reset();
		//	YellowDice.Reset();
		//	RedDice.Reset();
		//}
	}
}

