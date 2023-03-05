using System.Collections.Generic;

namespace Back.Dice
{
	public interface IBag
	{
		int GreenCount { get; }

		int YellowCount { get; }

		int RedCount { get; }

		List<IDice> GrabDice(int count);

		void FillBag();

		void ResetBag();
	}
}
