using Back.Dice;
using Back.PlayerModel.Visitor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Back.Game
{
	public class Score : INotifyPropertyChanged
	{
		private int brainsCount = 0;

		private int shotgunCount = 0;

		private bool killed = false;

		private ObservableCollection<IDice> allRolledDice = new ObservableCollection<IDice>();

		public Score()
		{
			allRolledDice = new ObservableCollection<IDice>();
			BindingOperations.EnableCollectionSynchronization(allRolledDice, new object());
		}

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
			set
			{
				killed = value;
				OnPropertyChanged();
			}
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
				try
				{
					while (AllRolledDice.Count > 0)
						AllRolledDice.RemoveAt(0);
				}
				catch (Exception e)
				{

				}
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
				else if (x.Side == DiceSide.SHOTGUN)
				{
					ShotgunCount++;
				}
			});

			if (ShotgunCount >= 3)
			{
				PlayerKilled();
			}
		}

		private void PlayerKilled()
		{
			Killed = true; 

			GameSingleton.instance.Game.CurrentPlayer.Accept(new ChangePlayerVisitor());

			Task.Run(() =>
			{
				Thread.Sleep(1200);
				ResetScore();
				GameSingleton.instance.Game.Bag.ResetBag();
				Killed = false;
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
