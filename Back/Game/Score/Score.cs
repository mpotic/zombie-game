using Back.Dice;
using Back.Helpers.Events;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

		public void DoResetScore()
		{
			BrainsCount = 0;
			ShotgunCount = 0;
			if (AllRolledDice != null)
			{
				AllRolledDice.Clear();
			}
		}

		public void ResetScore()
		{
			DoResetScore();
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void DelayedResetScore()
		{
			DoResetScore();
			CollectionChanged?.Invoke(this, new CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, CustomEnumNotifyCollectionChangedEventArgs.DELAYED_RESET));
		}

		public void UpdateScore(IGame game)
		{
			game.Hand.GrabbedDice.ForEach(x =>
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
				game.Hand.GrabbedDice));
		}

		public bool CheckAndKill()
		{
			if (ShotgunCount >= 3)
			{
				Killed = true;
				return true;
			}

			return false;
		}

		public void SetKilledToFalse()
		{
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
