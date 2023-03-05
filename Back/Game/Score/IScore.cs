using Back.Dice;
using System.Collections.ObjectModel;

namespace Back.Game
{

	public interface IScore
	{
		int BrainsCount { get; set; }

		int ShotgunCount { get; set; }

		bool Killed { get; set; }

		ObservableCollection<IDice> AllRolledDice { get; set; }

		void CheckAndKill();

		void PlayerKilled();

		void ResetScore();
		
		void UpdateScore();
	}
}
