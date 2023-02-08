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
		AllDice Dice { get; set; }
		Turn Turn { get; set; }
		IPlayer CurrentPlayer { get; set; }
	}
}
