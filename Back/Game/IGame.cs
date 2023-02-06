using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Game
{
	public interface IGame
	{
		AllDice Dice { get; set; }
		Player Player { get; set; }
		Turn Turn { get; set; }
	}
}
