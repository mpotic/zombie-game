using Back.Dice;
using Back.PlayerModel.Singleton;
using System.Threading.Tasks;

namespace Back.Game
{
	public sealed class Game : IGame
	{
		//public Game()
		//	: this(new Hand(), new GameSettings(), new Bag(), new ScoreFlyweightFactory())
		//{
		//}

		//private Game(IHand hand, IGameSettings gameSettings, IBag bag, IScoreFlyweightFactory factory)

		public Game()
		{
			Hand = new Hand();
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

			this.Hand = new Hand();

			StartGame();
		}

		public void StopAction()
		{
			PlayerListSingleton.instance.PlayersList.CurrentPlayer.SaveScore(ScoreDecorator.BrainsCount);
			PlayerListSingleton.instance.PlayersList.ChangeCurrentPlayerToNext();
			ScoreDecorator.ResetScore();
			Bag.ResetBag(GameSettings);
		}

		public void RollAction()
		{
			Hand.GrabAndRollDice(ScoreDecorator, Bag, GameSettings);
			ScoreDecorator.UpdateScore();
			if (ScoreDecorator.CheckAndKill())
			{
				Task.Run(() =>
				{
					ScoreDecorator.KillPlayer();
					PlayerListSingleton.instance.PlayersList.ChangeCurrentPlayerToNext();
					Bag.ResetBag(GameSettings);
					ScoreDecorator.ResetScore();
				});
			}
		}

		public void ResetGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag(GameSettings);
			PlayerListSingleton.instance.PlayersList.CurrentPlayer = null;
			PlayerListSingleton.instance.PlayersList.RemoveAllPlayers();
		}

		public void StartGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag(GameSettings);
			PlayerListSingleton.instance.PlayersList.ResetPlayersScore();
			PlayerListSingleton.instance.PlayersList.SetFirstPlayerAsCurrent();
		}
	}
}
