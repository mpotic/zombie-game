using Back.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Back.Dice
{
	public class GreenDice : IDice, INotifyPropertyChanged
	{
		private DiceSide side;
		private int footstepCount = 0;
		private int remaining = 6;

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
			Thread.Sleep(0);

			int randomInt = new Random().Next(0, 6);
			if (randomInt < 3)
				side = DiceSide.BRAIN;
			else if (randomInt == 3)
				side = DiceSide.SHOTGUN;
			else
			{
				side = DiceSide.FOOTSTEPS;
				footstepCount++;
			}

			Remaining--;
		}

		public void Reset()
		{
			FootstepCount = 0;
			Remaining = 6;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
