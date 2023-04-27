using Back.Dice;
using System.Collections.Generic;
using System.Linq;

namespace Back.Game
{
	public class ScoreDecoratorHero : IScoreDecorator
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

		public void AddDice(IDice dice)
		{
			ScoreComponent.AddDice(dice);
		}

		public void ResetScore()
		{
			ScoreComponent.ResetScore();
		}

		public void DelayedResetScore()
		{
			ScoreComponent.DelayedResetScore();
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
					game.Score.RemoveDice(santaDice);
					game.Score.BrainsCount--;
				}

				if (heroineDice != null)
				{
					game.Score.RemoveDice(heroineDice);
					game.Bag.ReturnDice(heroineDice);
					game.Score.BrainsCount--;
				}
			}
		}
	}
}
