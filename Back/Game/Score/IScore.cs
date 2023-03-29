using Back.Dice;
using System.Collections.Generic;

namespace Back.Game
{

	public interface IScore
	{
		int BrainsCount { get; set; }

		int ShotgunCount { get; set; }

		bool Killed { get; set; }

		List<IDice> AllRolledDice { get; set; }

		bool CheckAndKill();

		void KillPlayer();

		void ResetScore();
		
		void UpdateScore();

		void RemoveDice(IDice dice);

		List<IDice> RetrieveFootsteps();
	}
}
