using Back.Dice;
using Back.PlayerModel;
using System.Threading.Tasks;

namespace Back.Game
{
	public interface IGame
	{
		IScoreDecorator ScoreDecorator { get; set; }

		IHand Hand { get; set; }

		IBag Bag { get; set; }

		IGameSettings GameSettings { get; set; }

		IScoreFlyweightFactory Factory { get; set; }

		IPlayerList PlayerList { get; set; }

		void SetupNewGame(bool includeSanta, bool includeHero, bool includeHeroine);

		void StopAction();

		Task RollAction();

		void ResetGame();

		void StartGame();
	}
}
