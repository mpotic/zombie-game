using Back.Dice;
using Back.PlayerModel;
using Common.DTO;

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

		void SetupNewGame(IGameSettingsInfo gameSettingsInfo);

		void ConfigureBuss(bool includedBuss);

		void StopAction();

		void RollAction();

		void ResetGame();

		void StartGame();
	}
}
