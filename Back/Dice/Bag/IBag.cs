using System.Collections.Generic;

namespace Back.Dice
{
	public interface IBag
	{
		List<IDice> Dice { get; set; }

		int GreenCount { get; }

		int YellowCount { get; }

		int RedCount { get; }

		int SantaCount { get;}

		int HeroDice { get; }

		int HeroineDice { get; }

		List<IDice> GrabDice(int count);

		void FillBag();

		void ResetBag();
	}
}
