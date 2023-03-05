using Back.Game;
using System.Collections.Generic;
using System.Linq;

namespace Back.Dice
{
	/// <summary>
	/// Provides the functionality of picking random dice and rolling the dice to get random sides. Takes into consideration leftover footsteps.
	/// </summary>
	public class Hand : IHand
	{
		List<IDice> grabbedDice = new List<IDice>();

		public List<IDice> GrabbedDice { get => grabbedDice; set => grabbedDice = value; }

		public void GrabAndRollDice()
		{
			GrabPreviousTurnFootsteps();

			if (GrabbedDice.Count < 3)
			{
				GrabbedDice.AddRange(GameSingleton.instance.Game.Bag.GrabDice(3 - GrabbedDice.Count));
			}

			GrabbedDice.ForEach(x => x.Roll());
		}

		/// <summary>
		/// Removes all dice that have their side equal to FOOTSTEPS from Score.AllRolledDice and saves them to GrabbedDice.
		/// </summary>
		/// <returns></returns>
		private void GrabPreviousTurnFootsteps()
		{
			GrabbedDice = GameSingleton.instance.Game.ScoreDecorator.AllRolledDice.ToList<IDice>();
			GrabbedDice.RemoveAll(x => x.Side != DiceSide.FOOTSTEPS);

			foreach (IDice element in GrabbedDice)
			{
				GameSingleton.instance.Game.ScoreDecorator.AllRolledDice.Remove(element);
			}
		}
	}
}
