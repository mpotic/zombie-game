using Back.Dice;
using System.Linq;

namespace Back.Game
{
	public class ScoreDecoratorHeroine : ScoreDecorator
	{
		public override void UpdateScore(IGame game)
		{
			base.UpdateScore(game);

			HeroineDice dice = (HeroineDice)game.Hand.GrabbedDice.FirstOrDefault(x => x.DiceType == typeof(HeroineDice).Name);
			if (dice == null)
			{
				return;
			}

			if (dice.Side == DiceSide.SHOTGUN || dice.Side == DiceSide.DOUBLE_SHOTGUN)
			{
				SantaDice santaDice = (SantaDice)AllRolledDice.FirstOrDefault(x => (x.DiceType == typeof(SantaDice).Name && x.Side == DiceSide.BRAIN));
				HeroDice heroDice = (HeroDice)AllRolledDice.FirstOrDefault(x => (x.DiceType == typeof(HeroDice).Name && x.Side == DiceSide.DOUBLE_BRAIN));

				if (santaDice != null)
				{
					game.ScoreDecorator.RemoveDice(santaDice);
					game.ScoreDecorator.BrainsCount--;
				}

				if (heroDice != null)
				{
					game.ScoreDecorator.RemoveDice(heroDice);
					game.Bag.ReturnDice(heroDice);
					game.ScoreDecorator.BrainsCount--;
				}
			}
		}
	}
}
