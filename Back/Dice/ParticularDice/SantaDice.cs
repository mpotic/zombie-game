using System;

namespace Back.Dice
{
	public class SantaDice : IDice
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

		public void Roll()
		{
			Random random = new Random();
			int randNumber = random.Next(0, 6);

			switch (randNumber)
			{
				case (0):
					side = DiceSide.BRAIN;
					break;

				case (1):
					side = DiceSide.DOUBLE_BRAIN_GIFT;
					break;

				case (2):
					side = DiceSide.ENERGY_DRINK;
					break;

				case (3):
					side = DiceSide.FOOTSTEPS;
					break;

				case (4):
					side = DiceSide.HELMET;
					break;

				case (5):
					side = DiceSide.SHOTGUN;
					break;
			}
		}
	}
}
