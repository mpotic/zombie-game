using Back.Game;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Back.Dice
{
	/// <summary>
	/// Provides the functionality of picking random dice and rolling the dice to get random sides. Takes into consideration leftover footsteps.
	/// </summary>
	public class Hand : IHand
	{
		List<IDice> grabbedDice = new List<IDice>();

		private IGame game;

		public List<IDice> GrabbedDice { get => grabbedDice; set => grabbedDice = value; }

		public Hand()
		{
		}

		public Hand(IGame game)
		{
			this.game = game;
		}

		public void GrabAndRollDice()
		{
			CheckAndInit();
			GrabPreviousTurnFootsteps();

			if (GrabbedDice.Count < 3)
			{
				GrabbedDice.AddRange(game.Bag.GrabDice(3 - GrabbedDice.Count));
			}

			foreach(IDice dice in GrabbedDice)
			{
				Thread.Sleep(1);
				dice.Roll();
			}
		}

		private void CheckAndInit()
		{
			if(game == null)
			{
				game = GameSingleton.instance.Game;
			}
		}

		/// <summary>
		/// Removes all dice that have their side equal to FOOTSTEPS from Score.AllRolledDice and saves them to GrabbedDice.
		/// </summary>
		/// <returns></returns>
		private void GrabPreviousTurnFootsteps()
		{
			GrabbedDice = game.ScoreDecorator.AllRolledDice.ToList<IDice>();
			GrabbedDice.RemoveAll(x => x.Side != DiceSide.FOOTSTEPS);

			foreach (IDice element in GrabbedDice)
			{
				game.ScoreDecorator.RemoveDice(element);
			}
		}
	}
}
