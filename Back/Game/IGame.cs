using Back.Dice;
using Back.PlayerModel;

namespace Back.Game
{
	public interface IGame
	{
		IScoreDecorator ScoreDecorator { get; set; }

		IPlayer CurrentPlayer { get; set; }

		IHand Hand { get; set; }

		IBag Bag { get; set; }

		IGameSettings GameSettings { get; set; }

		IScoreFlyweightFactory Factory { get; set; }

		void SetupNewGame(bool includeSanta, bool includeHero, bool includeHeroine);

		void StopAction();

		void RollAction();

		void ResetGame();

		void StartGame();
	}
}
