using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Back.Dice
{
	public class YellowDice : IDice
	{
		private DiceSide side;

		public DiceSide Side { get => side; set => side = value; }

		public string DiceType
		{
			get
			{
				return this.ToString();
			}
		}

		public void Roll()
		{
			Thread.Sleep(1);

			int randomInt = new Random().Next(0, 3);
			side = (DiceSide)randomInt;
		}

		public override string ToString()
		{
			return "YellowDice";
		}
	}
}
