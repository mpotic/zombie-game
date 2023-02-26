using System.Collections.Generic;

namespace Back.Dice
{
	public interface IBag
	{
		int GreenCount { get; set; }

		int YellowCount { get; set; }

		int RedCount { get; set; }

		List<IDice> GrabDice(int count);

		void ResetBag();
	}
}
