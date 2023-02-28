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
			GrabbedDice = GrabPreviousTurnFootsteps();
			
			if(GrabbedDice.Count < 3)
			{
				GrabbedDice.AddRange(GameSingleton.instance.Game.Bag.GrabDice(3 - GrabbedDice.Count));
			}

			GrabbedDice.ForEach(x => x.Roll());
		}

		/// <summary>
		/// Removes all dice that have their side equal to FOOTSTEPS from Score.AllRolledDice and returns them as a List.
		/// </summary>
		/// <returns></returns>
		private List<IDice> GrabPreviousTurnFootsteps()
		{
			List<IDice> dice = GameSingleton.instance.Game.Score.AllRolledDice.ToList<IDice>();
			dice.RemoveAll(x => x.Side != DiceSide.FOOTSTEPS);

			foreach (IDice element in dice)
			{
				GameSingleton.instance.Game.Score.AllRolledDice.Remove(element);
			}

			return dice;
		}
	}
}
