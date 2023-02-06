using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
	public class Dice
	{
		private int diceLeft;
		private int brains;
		private int shotguns;
		private int footsteps;

		public int DiceLeft { get => diceLeft; set => diceLeft = value; }
		public int Brains { get => brains; set => brains = value; }
		public int Shotguns { get => shotguns; set => shotguns = value; }
		public int Footsteps { get => footsteps; set => footsteps = value; }
	}
}
