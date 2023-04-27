using Back.Game;
using System.Collections.Generic;

namespace Back.Dice
{
	/// <summary>
	/// Provides the functionality of picking random dice and rolling the dice to get random sides. Takes into consideration leftover footsteps.
	/// Interacts with the Bag that has all the dice available for rolling. Provides interface for handling the bag.
	/// </summary>
	public sealed class Hand : IHand
	{
		private readonly List<IDice> grabbedDice;

		public Hand(IRandomNumberProvider randomNumberProvider)
		{
			grabbedDice = new List<IDice>();
			this.randomNumberProvider = randomNumberProvider;
		}

		private IRandomNumberProvider randomNumberProvider;

		public List<IDice> GrabbedDice { get => grabbedDice; }

		public void GrabAndRollDice(IScore score, IBag bag, IGameSettings settings)
		{
			GrabbedDice.Clear();
			GrabbedDice.AddRange(score.RetrieveFootsteps());

			CheckIfBussIsInUse(settings);

			if (GrabbedDice.Count < 3)
			{
				GrabbedDice.AddRange(bag.GrabDice(3 - GrabbedDice.Count, settings, randomNumberProvider));
			}

			foreach(IDice dice in GrabbedDice)
			{
				dice.Roll(randomNumberProvider);
			}
		}

		private void CheckIfBussIsInUse(IGameSettings gameSettings)
		{
			if (gameSettings.IncludedBuss && GrabbedDice.Count < 3)
			{
				GrabbedDice.Add(new BussDice());
			}
		}
	}
}
