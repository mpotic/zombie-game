using Back.Dice;
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
				foreach (IDice dice in GameSingleton.instance.Game.Hand.GrabbedDice)
				{
					if (dice.DiceType == typeof(GreenDice).Name && dice.Side == DiceSide.FOOTSTEPS)
					{
						dice.Side = DiceSide.BRAIN;
					}
				}
			}
		}

		public override void CheckAndKill()
		{
			if(santaDice == null || santaDice.Side != DiceSide.HELMET)
			{
				base.CheckAndKill();
				return;
			}

			if(ShotgunCount >= 4)
			{
				PlayerKilled();
				santaDice = null;
			}
		}
	}
}
