﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Back.Dice
{
	public class RedDice : IDice, INotifyPropertyChanged
	{
		private DiceSide side;
		private int footstepCount = 0;
		private int remaining = 3;

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
				side = DiceSide.SHOTGUN;
			else if (randomInt == 3)
				side = DiceSide.BRAIN;
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
			Remaining = 3;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
