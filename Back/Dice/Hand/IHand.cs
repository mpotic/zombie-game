using Back.Game;
using System.Collections.Generic;

namespace Back.Dice
{
	public interface IHand
	{
		List<IDice> GrabbedDice { get; }

		void GrabAndRollDice(IScore score, IBag bag, IGameSettings settings);
	}
}
