using Back.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Back.Dice
{
	public class Bag : IBag, INotifyPropertyChanged
	{
		int greenCount = 6;

		int yellowCount = 4;

		int redCount = 3;

		int santaCount = 0;

		bool includeSanta = false;

		public int GreenCount
		{
			get
			{
				return greenCount;
			}
			set
			{
				this.greenCount = value;
				OnPropertyChanged();
			}
		}

		public int RedCount
		{
			get
			{
				return redCount;
			}
			set
			{
				this.redCount = value;
				OnPropertyChanged();
			}
		}

		public int YellowCount
		{
			get
			{
				return yellowCount;
			}
			set
			{
				this.yellowCount = value;
				OnPropertyChanged();
			}
		}

		public int SantaCount { get => santaCount; set => santaCount = value; }

		public bool IncludeSanta { get => includeSanta; set => includeSanta = value; }

		public int TotalCount
		{
			get
			{
				return greenCount + yellowCount + redCount;
			}
		}

		public List<IDice> GrabDice(int count)
		{
			List<IDice> dice = new List<IDice>();
			Random random = new Random();

			CheckAndRefil();

			for (int i = 0; i < count; i++)
			{
				// To reduce the possibility of getting the same number twice in a row because randomness is based on time
				Thread.Sleep(1);

				int number = random.Next(0, TotalCount);
				if (number < GreenCount)
				{
					dice.Add(new GreenDice());
					GreenCount--;
				}
				else if (number < (GreenCount + YellowCount))
				{
					dice.Add(new YellowDice());
					YellowCount--;
				}
				else
				{
					dice.Add(new RedDice());
					RedCount--;
				}
			}

			return dice;
		}

		public void ResetBag()
		{
			GreenCount = 6;
			YellowCount = 4;
			RedCount = 3;
			if (IncludeSanta)
			{
				SantaCount = 1;
			}
		}

		public void CheckAndRefil()
		{
			if (TotalCount >= GameSingleton.instance.Game.Hand.GrabbedDice.Count)
				return;

			ResetBag();
			GameSingleton.instance.Game.Hand.GrabbedDice.ForEach(x =>
			{
				if(x.DiceType == "GreenDice")
				{
					GreenCount--;
				}
				else if (x.DiceType == "YellowDice")
				{
					YellowCount--;
				}
				else
				{
					RedCount--;
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
