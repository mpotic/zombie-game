using Back.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dice
{
	public class YellowDice : IDice, INotifyPropertyChanged
	{
		private DiceSide side;
		private int footstepCount = 0;
		private int remaining = 4;

		public event PropertyChangedEventHandler PropertyChanged;

		public DiceSide Side { get => side; set => side = value; }

		public int FootstepCount { get => footstepCount; set => footstepCount = value; }

		public int Remaining
		{
			get => remaining;
			set
			{
				remaining = value;
				OnPropertyChanged();
			}
		}

		public void Roll()
		{
			int randomInt = new Random().Next(0, 3);
			side = (DiceSide)randomInt;

			if (side == DiceSide.FOOTSTEPS)
			{
				footstepCount++;
			}

			Remaining--;
		}

		public void Reset()
		{
			FootstepCount = 0;
			Remaining = 4;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
