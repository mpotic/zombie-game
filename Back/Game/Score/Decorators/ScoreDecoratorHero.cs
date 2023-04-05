using Back.Dice;
using System.Linq;

namespace Back.Game
{
	public class ScoreDecoratorHero : ScoreDecorator
	{
		public override void UpdateScore(IGame game)
		{
			base.UpdateScore(game);

			HeroDice dice = (HeroDice)game.Hand.GrabbedDice.FirstOrDefault(x => x.DiceType == typeof(HeroDice).Name);
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
					game.ScoreDecorator.RemoveDice(santaDice);
					game.ScoreDecorator.BrainsCount--;
				}

				if (heroineDice != null)
				{
					game.ScoreDecorator.RemoveDice(heroineDice);
					game.Bag.ReturnDice(heroineDice);
					game.ScoreDecorator.BrainsCount--;
				}
			}
		}
	}
}
