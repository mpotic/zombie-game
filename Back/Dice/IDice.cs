using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dice
{
	public enum DiceSide { SHOTGUN = 0, FOOTSTEPS, BRAIN};
	public interface IDice
	{
		DiceSide Side { get; set; }
		int FootstepCount { get; set; }
		int Remaining { get; set; }
		void Roll();
	}
}
