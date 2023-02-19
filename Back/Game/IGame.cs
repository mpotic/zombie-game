using Back.Dice;
using Back.PlayerModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Game
{
	public interface IGame
	{
		IAllDice Dice { get; set; }
		Score Score { get; set; }
		IPlayer CurrentPlayer { get; set; }
		void StopAction();
		void RollAction();
	}
}
