using Back.Dice;
using System.Linq;

namespace Back.Game
{
	public class ScoreDecoratorHero : ScoreDecorator
	{
		public override void UpdateScore()
		{
			base.UpdateScore();

			HeroDice dice = (HeroDice)GameSingleton.instance.Game.Hand.GrabbedDice.FirstOrDefault(x => x.DiceType == typeof(HeroDice).Name);
			if (dice == null)
			{
				return;
			}

			if (dice.Side == DiceSide.DOUBLE_BRAIN)
			{
				BrainsCount += 2;
			}
			else if(dice.Side == DiceSide.DOUBLE_SHOTGUN)
			{
				ShotgunCount += 2;
			}

			if (dice.Side == DiceSide.SHOTGUN || dice.Side == DiceSide.DOUBLE_SHOTGUN)
			{
				SantaDice santaDice = (SantaDice)AllRolledDice.FirstOrDefault(x => (x.DiceType == typeof(SantaDice).Name && x.Side == DiceSide.BRAIN));
				HeroineDice heroineDice = (HeroineDice)AllRolledDice.FirstOrDefault(x => (x.DiceType == typeof(HeroineDice).Name && x.Side == DiceSide.BRAIN));

				if (santaDice != null)
				{
					GameSingleton.instance.Game.ScoreDecorator.RemoveDice(santaDice);
					GameSingleton.instance.Game.ScoreDecorator.BrainsCount--;
				}

				if (heroineDice != null)
				{
					GameSingleton.instance.Game.ScoreDecorator.RemoveDice(heroineDice);
					GameSingleton.instance.Game.Bag.ReturnDice(heroineDice);
					GameSingleton.instance.Game.ScoreDecorator.BrainsCount--;
				}
			}
		}
	}
}
