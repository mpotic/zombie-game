using System.Collections.Generic;
using Back.Dice;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using Back.PlayerModel.Visitor;

namespace Back.Game
{
	public class Game : IGame
	{
		//private IAllDice dice = new AllDice();
		
		private IPlayer currentPlayer = null;
		
		private Score score = new Score();

		private IHand hand = new Hand();

		private IBag bag = new Bag();

		//public IAllDice Dice { get => dice; set => dice = value; }

		public Score Score { get => score; set => score = value; }

		public IPlayer CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

		public IHand Hand { get => hand; set => hand = value; }

		public IBag Bag { get => bag; set => bag = value; }

		public void StopAction()
		{
			currentPlayer.Accept(new SaveTurnPlayerVisitor());
			currentPlayer.Accept(new ChangePlayerVisitor());
			Score.ResetScore();
			Bag.ResetBag();
		}

		public void RollAction()
		{
			Hand.GrabAndRollDice();
			Score.UpdateScore();

			if (Score.ShotgunCount >= 3)
			{
				Score.Killed = true;
				StopAction();
				return;
			}
			//List<DiceSide> rolledSides = dice.RollDice();

			//foreach (DiceSide side in rolledSides)
			//{
			//	if (side == DiceSide.BRAIN)
			//	{
			//		Score.BrainsCount++;
			//	}
			//	else if (side == DiceSide.FOOTSTEPS)
			//	{
			//		Score.FootstepsCount++;
			//	}
			//	else
			//	{
			//		Score.ShotgunCount++;
			//	}
			//}

			//if (Score.ShotgunCount >= 3)
			//{
			//	Score.Killed = true;
			//	Score.BrainsCount = 0;
			//	StopAction();
			//	return;
			//}
			// Reduce attributes of Turn according to rolled sides and dice types
		}

		public void ResetGame()
		{
			Score.ResetScore();
			Bag.ResetBag();

			CurrentPlayer = null;

			// For some reasons after calling Clear() on ObservableCollection it takes 1-2 seconds to reflect the changes on the UI.
			while (PlayerListSingleton.instance.PlayersList.Players.Count > 0)
				PlayerListSingleton.instance.PlayersList.Players.RemoveAt(0);
		}

		public void StartGame()
		{
			Score.ResetScore();
			Bag.ResetBag();
			PlayerListSingleton.instance.PlayersList.ResetPlayersScore();
			CurrentPlayer = PlayerListSingleton.instance.PlayersList.Players[0];
		}
	}
}
