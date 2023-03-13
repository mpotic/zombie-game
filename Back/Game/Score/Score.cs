using Back.Dice;
using Back.PlayerModel.Visitor;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Back.Game
{
	public class Score : IScore, INotifyPropertyChanged, INotifyCollectionChanged
	{
		private int brainsCount = 0;

		private int shotgunCount = 0;

		private bool killed = false;

		private List<IDice> allRolledDice;

		public Score()
		{
			AllRolledDice = new List<IDice>();
		}

		public Score(List<IDice> dice)
		{
			AllRolledDice = dice;
		}

		public int BrainsCount
		{
			get => brainsCount; set
			{
				brainsCount = value;
			}
		}

		public int ShotgunCount
		{
			get => shotgunCount;
			set
			{
				shotgunCount = value;
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

		public List<IDice> AllRolledDice
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

		public void CheckAndKill() 
		{
			if (ShotgunCount >= 3)
			{
				PlayerKilled();
			}
		}

		public void PlayerKilled()
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

		public void RemoveDice(IDice dice)
		{
			AllRolledDice.Remove(dice);

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, dice));
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
