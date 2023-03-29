using Back.Game;
using System.Collections.Generic;

namespace Back.Dice
{
	public interface IBag
	{
		List<IDice> Dice { get; }

		int GreenCount { get; }

		int YellowCount { get; }

		int RedCount { get; }

		int SantaCount { get;}

		int HeroCount { get; }

		int HeroineCount { get; }

		List<IDice> GrabDice(int count, IGameSettings settings, IRandomNumberProvider randomNumberProvider);

		void ResetBag(IGameSettings settings);

		void ReturnDice(IDice dice);
	}
}
