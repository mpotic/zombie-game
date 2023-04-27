using Back.Dice;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using Common.DTO;

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

			Score = Factory.GetFlyweight(typeof(Score));
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

		public void SetupNewGame(IGameSettingsInfo gameSettingsInfo)
		{
			GameSettings.Configure(gameSettingsInfo);

			ConfigureScoreDecorator();

			Hand = new Hand(new RandomNumberProvider());

			StartGame();
		}

		private void ConfigureScoreDecorator()
		{
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

			if (GameSettings.IncludedBuss)
			{
				IScoreDecorator bussDecorator = (IScoreDecorator)Factory.GetFlyweight(typeof(ScoreDecoratorBuss));
				bussDecorator.SetScoreComponent(currentDecorator);
				currentDecorator = bussDecorator;
			}

			Score = currentDecorator;
		}

		public void ConfigureBuss(bool includedBuss)
		{
			if (includedBuss)
			{
				IScoreDecorator bussDecorator = (IScoreDecorator)Factory.GetFlyweight(typeof(ScoreDecoratorBuss));
				bussDecorator.SetScoreComponent(Score);
				Score = bussDecorator;

				GameSettings.IncludedBuss = true;
			}
			else
			{
				GameSettings.IncludedBuss = false;

				ConfigureScoreDecorator();
			}
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
				PlayerList.DelayedChangeCurrentPlayerToNext();
				Bag.ResetBag(GameSettings);
				Score.DelayedResetScore();
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
