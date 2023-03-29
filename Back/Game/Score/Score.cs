using Back.Dice;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Back.Game
{
	public class Score : IScore, INotifyPropertyChanged, INotifyCollectionChanged
	{
		private bool killed;

		public Score()
		{
			AllRolledDice = new List<IDice>();
		}

		public Score(List<IDice> dice)
		{
			AllRolledDice = dice;
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public event PropertyChangedEventHandler PropertyChanged;

		public int BrainsCount { get; set; }

		public int ShotgunCount { get; set; }

		public bool Killed
		{
			get => killed;
			set
			{
				killed = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Kiled"));
			}
		}

		public List<IDice> AllRolledDice { get; set; }

		public void ResetScore()
		{
			if (killed)
			{
				Thread.Sleep(1200);
			}

			BrainsCount = 0;
			ShotgunCount = 0;
			if (AllRolledDice != null)
			{
				AllRolledDice.Clear();
				CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
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

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
				GameSingleton.instance.Game.Hand.GrabbedDice));
		}

		public bool CheckAndKill()
		{
			if (ShotgunCount >= 3)
			{
				return true;
			}

			return false;
		}

		public void KillPlayer()
		{
			Killed = true;
			Thread.Sleep(1200);
			Killed = false;
		}

		public void RemoveDice(IDice dice)
		{
			AllRolledDice.Remove(dice);

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, dice));
		}

		public void AddDice(IDice dice)
		{
			AllRolledDice.Add(dice);

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, dice));
		}

		public List<IDice> RetrieveFootsteps()
		{
			List<IDice> footsteps = AllRolledDice.FindAll(x => x.Side == DiceSide.FOOTSTEPS);

			AllRolledDice.RemoveAll(x => x.Side == DiceSide.FOOTSTEPS);
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, footsteps));

			return footsteps;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
