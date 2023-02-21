using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Back.Dice;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using Back.PlayerModel.Visitor;

namespace Back.Game
{
	public class Game : IGame
	{
		private IAllDice dice = new AllDice();
		private IPlayer currentPlayer = null;
		private Score score = new Score();

		public IAllDice Dice { get => dice; set => dice = value; }

		public Score Score { get => score; set => score = value; }

		public IPlayer CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

		public void StopAction()
		{
			currentPlayer.Accept(new SaveTurnPlayerVisitor());
			currentPlayer.Accept(new ChangePlayerVisitor());
			Score.ResetScore();
			dice.ResetDice();
		}

		public void RollAction()
		{
			List<DiceSide> rolledSides = dice.RollDice();

			foreach (DiceSide side in rolledSides)
			{
				if (side == DiceSide.BRAIN)
				{
					Score.BrainsCount++;
				}
				else if (side == DiceSide.FOOTSTEPS)
				{
					Score.FootstepsCount++;
				}
				else
				{
					Score.ShotgunCount++;
				}
			}

			if (Score.ShotgunCount >= 3)
			{
				Score.Killed = true;
				Score.BrainsCount = 0;
				StopAction();
				return;
			}
			// Reduce attributes of Turn according to rolled sides and dice types
		}

		public void ResetGame()
		{
			Score.ResetScore();
			Dice.ResetDice();

			CurrentPlayer = null;

			// For some reasons after calling Clear() on ObservableCollection it takes 1-2 seconds to reflect the changes on the UI.
			while (PlayerListSingleton.PlayerList.Players.Count > 0)
				PlayerListSingleton.PlayerList.Players.RemoveAt(0);
		}

		public void StartGame()
		{
			Score.ResetScore();
			Dice.ResetDice();
			PlayerListSingleton.PlayerList.ResetPlayersScore();
			CurrentPlayer = PlayerListSingleton.PlayerList.Players[0];
		}
	}
}
