﻿using Back.Dice;
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

		void SetKilledToFalse();

		void ResetScore();

		void DelayedResetScore();

		void UpdateScore(IGame game);

		void RemoveDice(IDice dice);

		void AddDice(IDice dice);

		List<IDice> RetrieveFootsteps();
	}
}
