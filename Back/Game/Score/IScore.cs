using Back.Dice;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Game
{

	public interface IScore
	{
		int BrainsCount { get; set; }

		int ShotgunCount { get; set; }

		bool Killed { get; set; }

		List<IDice> AllRolledDice { get; set; }

		bool CheckAndKill();

		Task SetKilledToTrueAfterDelay(int delay);

		void ResetScore();
		
		void UpdateScore(IGame game);

		void RemoveDice(IDice dice);

		List<IDice> RetrieveFootsteps();
	}
}
