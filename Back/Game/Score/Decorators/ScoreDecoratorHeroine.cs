using Back.Dice;
using System.Collections.Generic;
using System.Linq;

namespace Back.Game
{
	public class ScoreDecoratorHeroine : IScoreDecorator
	{
		public IScore ScoreComponent { get; set; }

		public int BrainsCount { get => ScoreComponent.BrainsCount; set => ScoreComponent.BrainsCount = value; }

		public int ShotgunCount { get => ScoreComponent.ShotgunCount; set => ScoreComponent.ShotgunCount = value; }

		public bool Killed { get => ScoreComponent.Killed; set => ScoreComponent.Killed = value; }

		public List<IDice> AllRolledDice { get => ScoreComponent.AllRolledDice; set => ScoreComponent.AllRolledDice = value; }

		public bool CheckAndKill()
		{
			return ScoreComponent.CheckAndKill();
		}

		public void RemoveDice(IDice dice)
		{
			ScoreComponent.RemoveDice(dice);
		}

		public void ResetScore()
		{
			ScoreComponent.ResetScore();
		}

		public List<IDice> RetrieveFootsteps()
		{
			return ScoreComponent.RetrieveFootsteps();
		}

		public void SetKilledToFalse()
		{
			ScoreComponent.SetKilledToFalse();
		}

		public void SetScoreComponent(IScore score)
		{
			ScoreComponent = score;
		}

		public void UpdateScore(IGame game)
		{
			ScoreComponent.UpdateScore(game);

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
					game.Score.RemoveDice(santaDice);
					game.Score.BrainsCount--;
				}

				if (heroDice != null)
				{
					game.Score.RemoveDice(heroDice);
					game.Bag.ReturnDice(heroDice);
					game.Score.BrainsCount--;
				}
			}
		}
	}
}
