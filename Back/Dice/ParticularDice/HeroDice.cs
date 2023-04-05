using System;
using System.Threading;

namespace Back.Dice
{
	public class HeroDice : IDice
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
			if (randomInt < 2)
			{
				Side = DiceSide.FOOTSTEPS;
			}
			else if (randomInt >= 2 && randomInt <= 3)
			{
				Side = DiceSide.SHOTGUN;
			}
			else if(randomInt == 4)
			{
				Side = DiceSide.DOUBLE_SHOTGUN;
			}
			else
			{
				Side = DiceSide.DOUBLE_BRAIN;
			}
		}
	}
}
