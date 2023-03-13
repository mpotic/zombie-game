using Back.Dice;
using System.Collections.Generic;
using System.Linq;

namespace Back.Game
{
	public class SantaScoreDecorator : ScoreDecorator
	{
		protected SantaDice santaDice = null;

		public override void UpdateScore()
		{
			base.UpdateScore();

			if (santaDice == null)
			{
				IDice dice = (SantaDice)GameSingleton.instance.Game.Hand.GrabbedDice.FirstOrDefault(x => x.DiceType == typeof(SantaDice).Name);
				if (dice == null)
				{
					return;
				}

				santaDice = (SantaDice)dice;

				if (santaDice.Side == DiceSide.DOUBLE_BRAIN_GIFT)
				{
					BrainsCount += 2;
				}
			}

			if (santaDice.Side == DiceSide.ENERGY_DRINK)
			{
				List<IDice> greenFootsteps = new List<IDice>();
				foreach (IDice dice in AllRolledDice)
				{
					if (dice.DiceType == typeof(GreenDice).Name && dice.Side == DiceSide.FOOTSTEPS)
					{
						dice.Side = DiceSide.BRAIN;
						greenFootsteps.Add(dice);
					}
				}

				foreach(IDice dice in greenFootsteps)
				{
					AllRolledDice.Remove(dice);
					AllRolledDice.Add(dice);
				}
			}
		}

		public override void ResetScore()
		{
			base.ResetScore();

			santaDice = null;
		}

		public override void CheckAndKill()
		{
			if(santaDice != null && santaDice.Side == DiceSide.HELMET && ShotgunCount < 4)
			{
				return;
			}

			base.CheckAndKill();
			if(GameSingleton.instance.Game.ScoreDecorator.Killed)
			{
				santaDice = null;
			}
		}
	}
}
