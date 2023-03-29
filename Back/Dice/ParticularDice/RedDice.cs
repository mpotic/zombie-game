using System;
using System.Threading;

namespace Back.Dice
{
	public class RedDice : IDice
	{
		private DiceSide side;

		public DiceSide Side { get => side; set => side = value; }

		public string DiceType
		{
			get
			{
				return this.GetType().Name;
			}
		}

		public void Roll(IRandomNumberProvider randomNumberProvider)
		{
			int randomInt = randomNumberProvider.GetRandomNumber(0, 6);
			if (randomInt < 3)
			{
				side = DiceSide.SHOTGUN;
			}
			else if (randomInt == 3)
			{ 
				side = DiceSide.BRAIN; 
			}
			else
			{
				side = DiceSide.FOOTSTEPS;
			}
		}
	}
}
