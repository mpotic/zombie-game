using Back.Dice;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Back.Game
{
	public class Score : INotifyPropertyChanged
	{
		private int brainsCount = 0;

		private int shotgunCount = 0;

		private bool killed = false;

		private ObservableCollection<IDice> allRolledDice = new ObservableCollection<IDice>();

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

		public bool Killed
		{
			get => killed;
			set => killed = value;
		}

		public ObservableCollection<IDice> AllRolledDice
		{
			get => allRolledDice;
			set => allRolledDice = value;
		}


		public void ResetScore()
		{
			BrainsCount = 0;
			ShotgunCount = 0;
			if (AllRolledDice != null)
			{
				AllRolledDice.Clear();
			}
		}

		public void UpdateScore()
		{
			GameSingleton.instance.Game.Hand.GrabbedDice.ForEach(x =>
			{
				AllRolledDice.Add(x);

				if (x.Side == DiceSide.BRAIN)
				{
					BrainsCount++;
				}
				else if(x.Side == DiceSide.SHOTGUN)
				{
					ShotgunCount++;
				}
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
