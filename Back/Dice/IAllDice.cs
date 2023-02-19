using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dice
{
	public interface IAllDice
	{
		GreenDice GreenDice { get; set; }
		YellowDice YellowDice { get; set; }
		RedDice RedDice { get; set; }

		List<DiceSide> RollDice();
		void ResetDice();
	}
}
