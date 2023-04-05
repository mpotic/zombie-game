﻿using Back.Dice;
using System.Collections.Generic;
using System.Linq;

namespace Back.Game
{
	public class SantaScoreDecorator : ScoreDecorator
	{
		protected SantaDice santaDice = null;

		public override void UpdateScore(IGame game)
		{
			base.UpdateScore(game);

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
						game.ScoreDecorator.RemoveDice(heroDice);
						game.Bag.ReturnDice(heroDice);
						game.ScoreDecorator.BrainsCount--;
					}

					if(heroineDice != null)
					{
						game.ScoreDecorator.RemoveDice(heroineDice);
						game.Bag.ReturnDice(heroineDice);
						game.ScoreDecorator.BrainsCount--;
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

		public override void ResetScore()
		{
			base.ResetScore();

			santaDice = null;
		}

		public override bool CheckAndKill()
		{
			if(santaDice != null && santaDice.Side == DiceSide.HELMET && ShotgunCount < 4)
			{
				return false;
			}

			return base.CheckAndKill();
		}
	}
}
