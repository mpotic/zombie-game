using Back.Dice;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using Back.PlayerModel.Visitor;
using System.Linq;

namespace Back.Game
{
	public class Game : IGame
	{
		private IPlayer currentPlayer;

		private IScoreDecorator scoreDecorator;

		private IHand hand;

		private IGameSettings gameSettings;

		private IBag bag;

		public IScoreDecorator ScoreDecorator { get => scoreDecorator; set => scoreDecorator = value; }

		public IPlayer CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

		public IHand Hand { get => hand; set => hand = value; }

		public IBag Bag { get => bag; set => bag = value; }

		public IGameSettings GameSettings { get => gameSettings; set => gameSettings = value; }

		public Game()
		{
			scoreDecorator = new ScoreDecorator();
			hand = new Hand();
			gameSettings = new GameSettings();
			bag = new Bag();
		}

		public void SetupNewGame(bool includeSanta)
		{
			GameSettings.IncludedSanta = includeSanta;

			if (includeSanta)
			{
				ScoreDecorator = new SantaScoreDecorator();
			}
			else
			{
				ScoreDecorator = new ScoreDecorator();
			}

			StartGame();
		}

		public void StopAction()
		{
			currentPlayer.Accept(new SaveTurnPlayerVisitor());
			currentPlayer.Accept(new ChangePlayerVisitor());
			ScoreDecorator.ResetScore();
			Bag.ResetBag();
		}

		public void RollAction()
		{
			Hand.GrabAndRollDice();
			ScoreDecorator.UpdateScore();
			ScoreDecorator.CheckAndKill();
		}

		public void ResetGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag();
			CurrentPlayer = null;
			PlayerListSingleton.instance.PlayersList.RemoveAllPlayers();
		}

		public void StartGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag();
			PlayerListSingleton.instance.PlayersList.ResetPlayersScore();
			CurrentPlayer = PlayerListSingleton.instance.PlayersList.Players.FirstOrDefault();
		}
	}
}
