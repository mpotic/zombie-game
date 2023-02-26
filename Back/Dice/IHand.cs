using System.Collections.Generic;

namespace Back.Dice
{
	public interface IHand
	{
		List<IDice> GrabbedDice { get; set; }

		void GrabAndRollDice();
	}
}
