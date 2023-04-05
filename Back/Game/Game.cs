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

			ScoreDecorator = (IScoreDecorator)Factory.GetFlyweight(typeof(ScoreDecorator));
			ScoreDecorator.SetScoreComponent(Factory.GetFlyweight(typeof(Score)));
		}

		public IScoreDecorator ScoreDecorator { get; set; }

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

			IScoreDecorator currentDecorator = (IScoreDecorator)Factory.GetFlyweight(typeof(ScoreDecorator));

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

			ScoreDecorator = currentDecorator;

			Hand = new Hand(new RandomNumberProvider());

			StartGame();
		}

		public void StopAction()
		{
			PlayerList.CurrentPlayer.SaveScore(ScoreDecorator.BrainsCount);
			PlayerList.ChangeCurrentPlayerToNext();
			ScoreDecorator.ResetScore();
			Bag.ResetBag(GameSettings);
		}

		public async Task RollAction()
		{
			Hand.GrabAndRollDice(ScoreDecorator, Bag, GameSettings);
			ScoreDecorator.UpdateScore(this);
			if (ScoreDecorator.CheckAndKill())
			{
				await ScoreDecorator.SetKilledToTrueAfterDelay(1200);
				PlayerList.ChangeCurrentPlayerToNext();
				Bag.ResetBag(GameSettings);
				ScoreDecorator.ResetScore();
			}
		}

		public void ResetGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag(GameSettings);
			PlayerList.CurrentPlayer = null;
			PlayerList.RemoveAllPlayers();
		}

		public void StartGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag(GameSettings);
			PlayerList.ResetPlayersScore();
			PlayerList.SetFirstPlayerAsCurrent();
		}
	}
}
