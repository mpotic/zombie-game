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

		int HeroCount { get; }

		int HeroineCount { get; }

		List<IDice> GrabDice(int count);

		void FillBag();

		void ResetBag();

		void ReturnDice(IDice dice);
	}
}
