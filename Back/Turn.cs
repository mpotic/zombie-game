using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
	public class Turn : NotifyPropertyChanged
	{
		private int brainsCount = 0;
		private int shotgunCount = 0;
		private int footstepsCount = 0;
		private int totalLeft = 13;
		private int greenLeft = 6;
		private int yellowLeft = 4;
		private int redLeft = 3;

		public int BrainsCount
		{
			get => brainsCount; set
			{
				brainsCount = value;
				OnPropertyChanged();
			}
		}
		public int ShotgunCount
		{
			get => shotgunCount;
			set
			{
				shotgunCount = value;
				OnPropertyChanged();
			}
		}
		public int FootstepsCount
		{
			get => footstepsCount;
			set
			{
				footstepsCount = value;
				OnPropertyChanged();
			}
		}
		public int TotalLeft
		{
			get => totalLeft;
			set
			{
				totalLeft = value;
				OnPropertyChanged();
			}
		}
		public int GreenLeft
		{
			get => greenLeft;
			set
			{
				greenLeft = value;
				OnPropertyChanged();
			}
		}
		public int YellowLeft
		{
			get => yellowLeft;
			set
			{
				yellowLeft = value;
				OnPropertyChanged();
			}
		}
		public int RedLeft
		{
			get => redLeft;
			set
			{
				redLeft = value;
				OnPropertyChanged();
			}
		}
		public void ResetTurn()
		{
			BrainsCount = 0;
			ShotgunCount = 0;
			FootstepsCount = 0;
			TotalLeft = 13;
			GreenLeft = 6;
			YellowLeft = 4;
			RedLeft = 3;
		}
	}
}
