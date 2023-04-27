using Back.Dice;
using Back.PlayerModel.Singleton;
using System.Collections.Generic;
using System.Linq;

namespace Back.Game
{
	public class ScoreDecoratorBuss : IScoreDecorator
	{
		private bool isStop = false;

		public IScore ScoreComponent { get; set; }

		public int BrainsCount { get => ScoreComponent.BrainsCount; set => ScoreComponent.BrainsCount = value; }

		public int ShotgunCount { get => ScoreComponent.ShotgunCount; set => ScoreComponent.ShotgunCount = value; }

		public bool Killed { get => ScoreComponent.Killed; set => ScoreComponent.Killed = value; }

		public List<IDice> AllRolledDice { get => ScoreComponent.AllRolledDice; set => ScoreComponent.AllRolledDice = value; }

		public bool CheckAndKill()
		{
			bool isKilled = ScoreComponent.CheckAndKill();

			if (!isKilled && isStop)
			{
				PlayerListSingleton.instance.PlayersList.CurrentPlayer.SaveScore(BrainsCount);
				Killed = true;

				isStop = false;

				return true;
			}

			return isKilled;
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

			BussDice dice = (BussDice)game.Hand.GrabbedDice.FirstOrDefault(x => x.DiceType == typeof(BussDice).Name);
			if (dice == null)
			{
				return;
			}

			if(dice.Side == DiceSide.DOUBLE_BRAIN_ONE_SHOTGUN)
			{
				BrainsCount += 2;
				ShotgunCount++;
			}
			else if(dice.Side == DiceSide.STOP)
			{
				isStop = true;
			}
			else if(dice.Side == DiceSide.DEAD_END)
			{
				List<IDice> footstepsList = game.Hand.GrabbedDice.FindAll(x => x.Side == DiceSide.FOOTSTEPS);
				
				foreach(IDice footstepDice in footstepsList)
				{
					footstepDice.Side = DiceSide.BRAIN;

					RemoveDice(footstepDice);
					AddDice(footstepDice);
				}
			}
			else if(dice.Side == DiceSide.YIELD)
			{
				List<IDice> shotgunsList = game.Hand.GrabbedDice.FindAll(x => x.Side == DiceSide.SHOTGUN || x.Side == DiceSide.DOUBLE_SHOTGUN);

				foreach (IDice shotgunDice in shotgunsList)
				{
					shotgunDice.Side = DiceSide.FOOTSTEPS;

					ShotgunCount--;

					RemoveDice(shotgunDice);
					AddDice(shotgunDice);
				}
			}
			else if(dice.Side == DiceSide.RUN_OVER)
			{
				if(BrainsCount > 0)
				{
					BrainsCount--;
				}
			}
		}
	}
}
