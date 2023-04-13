using Back.Dice;
using Back.PlayerModel;
using System.Threading.Tasks;

namespace Back.Game
{
	public interface IGame
	{
		IScore Score { get; set; }

		IHand Hand { get; set; }

		IBag Bag { get; set; }

		IGameSettings GameSettings { get; set; }

		IScoreFlyweightFactory Factory { get; set; }

		IPlayerList PlayerList { get; set; }

		void SetupNewGame(bool includeSanta, bool includeHero, bool includeHeroine);

		void StopAction();

		void RollAction();

		void ResetGame();

		void StartGame();
	}
}
