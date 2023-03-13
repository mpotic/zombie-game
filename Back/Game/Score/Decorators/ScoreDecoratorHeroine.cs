using Back.Dice;
using System.Linq;

namespace Back.Game
{
	public class ScoreDecoratorHeroine : ScoreDecorator
	{
		public override void UpdateScore()
		{
			base.UpdateScore();

			HeroineDice dice = (HeroineDice)GameSingleton.instance.Game.Hand.GrabbedDice.FirstOrDefault(x => x.DiceType == typeof(HeroineDice).Name);
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
					GameSingleton.instance.Game.ScoreDecorator.RemoveDice(santaDice);
					GameSingleton.instance.Game.ScoreDecorator.BrainsCount--;
				}

				if (heroDice != null)
				{
					GameSingleton.instance.Game.ScoreDecorator.RemoveDice(heroDice);
					GameSingleton.instance.Game.Bag.ReturnDice(heroDice);
					GameSingleton.instance.Game.ScoreDecorator.BrainsCount--;
				}
			}
		}
	}
}
