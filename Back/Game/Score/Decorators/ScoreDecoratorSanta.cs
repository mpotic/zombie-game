using Back.Dice;
using System.Collections.Generic;
using System.Linq;

namespace Back.Game
{
	public class SantaScoreDecorator : IScoreDecorator
	{
		protected SantaDice santaDice = null;

		public IScore ScoreComponent { get; set; }

		public int BrainsCount { get => ScoreComponent.BrainsCount; set => ScoreComponent.BrainsCount = value; }

		public int ShotgunCount { get => ScoreComponent.ShotgunCount; set => ScoreComponent.ShotgunCount = value; }

		public bool Killed { get => ScoreComponent.Killed; set => ScoreComponent.Killed = value; }

		public List<IDice> AllRolledDice { get => ScoreComponent.AllRolledDice; set => ScoreComponent.AllRolledDice = value; }

		public bool CheckAndKill()
		{
			if (santaDice != null && santaDice.Side == DiceSide.HELMET && ShotgunCount < 4)
			{
				return false;
			}

			return ScoreComponent.CheckAndKill();
		}

		public void DelayedResetScore()
		{
			ScoreComponent.DelayedResetScore();
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

			santaDice = null;
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

			if (santaDice == null)
			{
				SantaDice dice = (SantaDice)game.Hand.GrabbedDice.FirstOrDefault(x => x.DiceType == typeof(SantaDice).Name);
				if (dice == null)
				{
					return;
				}

				santaDice = dice;

				if (santaDice.Side == DiceSide.DOUBLE_BRAIN_GIFT)
				{
					BrainsCount += 2;
				}
				else if (santaDice.Side == DiceSide.SHOTGUN)
				{
					HeroDice heroDice = (HeroDice)AllRolledDice.FirstOrDefault(x => (x.DiceType == typeof(HeroDice).Name && x.Side == DiceSide.DOUBLE_BRAIN));
					HeroineDice heroineDice = (HeroineDice)AllRolledDice.FirstOrDefault(x => (x.DiceType == typeof(HeroineDice).Name && x.Side == DiceSide.BRAIN));

					if(heroDice != null)
					{
						game.Score.RemoveDice(heroDice);
						game.Bag.ReturnDice(heroDice);
						game.Score.BrainsCount--;
					}

					if(heroineDice != null)
					{
						game.Score.RemoveDice(heroineDice);
						game.Bag.ReturnDice(heroineDice);
						game.Score.BrainsCount--;
					}
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
	}
}
