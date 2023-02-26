using Back.Dice;
using System.Collections.Generic;

namespace Back.Callback
{
	public interface ITableDiceCallback
	{
		void PopulateWithDice(List<IDice> dice);
	}
}
