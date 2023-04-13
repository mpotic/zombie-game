using Back.Dice;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using System.Threading.Tasks;

namespace Back.Game
{
	public sealed class Game : IGame
	{
		private IPlayerList playerList;

		public Game()
		{
			Hand = new Hand(new RandomNumberProvider());
			GameSettings = new GameSettings();
			Bag = new Bag();
			Factory = new ScoreFlyweightFactory();

			Score = (IScore)Factory.GetFlyweight(typeof(Score));
		}

		public IScore Score { get; set; }

		public IHand Hand { get; set; }

		public IBag Bag { get; set; }

		public IGameSettings GameSettings { get; set; }

		public IScoreFlyweightFactory Factory { get; set; }

		public IPlayerList PlayerList 
		{
			get
			{
				if(playerList == null)
				{
					playerList = PlayerListSingleton.instance.PlayersList;
				}

				return playerList;
			}
			set
			{
				playerList = value;
			}
		} 

		public void SetupNewGame(bool includeSanta = false, bool includeHero = false, bool includeHeroine = false)
		{
			GameSettings.Configure(includeSanta, includeHero, includeHeroine);

			IScore currentDecorator = Factory.GetFlyweight(typeof(Score));

			if (GameSettings.IncludedSanta)
			{
				IScoreDecorator santaDecorator = (IScoreDecorator)Factory.GetFlyweight(typeof(SantaScoreDecorator));
				santaDecorator.SetScoreComponent(currentDecorator);
				currentDecorator = santaDecorator;
			}

			if (GameSettings.IncludedHero)
			{
				IScoreDecorator heroDecorator = (IScoreDecorator)Factory.GetFlyweight(typeof(ScoreDecoratorHero));
				heroDecorator.SetScoreComponent(currentDecorator);
				currentDecorator = heroDecorator;
			}

			if (GameSettings.IncludedHeroine)
			{
				IScoreDecorator heroineDecorator = (IScoreDecorator)Factory.GetFlyweight(typeof(ScoreDecoratorHeroine));
				heroineDecorator.SetScoreComponent(currentDecorator);
				currentDecorator = heroineDecorator;
			}

			Score = currentDecorator;

			Hand = new Hand(new RandomNumberProvider());

			StartGame();
		}

		public void StopAction()
		{
			PlayerList.CurrentPlayer.SaveScore(Score.BrainsCount);
			PlayerList.ChangeCurrentPlayerToNext();
			Score.ResetScore();
			Bag.ResetBag(GameSettings);
		}

		public void RollAction()
		{
			Hand.GrabAndRollDice(Score, Bag, GameSettings);
			Score.UpdateScore(this);
			if (Score.CheckAndKill())
			{
				Score.SetKilledToFalse();
				PlayerList.ChangeCurrentPlayerToNext();
				Bag.ResetBag(GameSettings);
				Score.ResetScore();
			}
		}

		public void ResetGame()
		{
			Score.ResetScore();
			Bag.ResetBag(GameSettings);
			PlayerList.CurrentPlayer = null;
			PlayerList.RemoveAllPlayers();
		}

		public void StartGame()
		{
			Score.ResetScore();
			Bag.ResetBag(GameSettings);
			PlayerList.ResetPlayersScore();
			PlayerList.SetFirstPlayerAsCurrent();
		}
	}
}
