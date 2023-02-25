using Back.Dice;
using Back.PlayerModel;

namespace Back.Game
{
	public interface IGame
	{
		IAllDice Dice { get; set; }
		Score Score { get; set; }
		IPlayer CurrentPlayer { get; set; }
		void StopAction();
		void RollAction();
		void ResetGame();
		void StartGame();
	}
}
