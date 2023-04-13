using Back.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Back.Dice
{
	// TODO: Make Decorator and Flyweight for Bag?
	public class Bag : IBag, INotifyPropertyChanged
	{
		private List<IDice> dice;

		private bool usedSanta;

		public Bag()
		{
			dice = new List<IDice>();
			dice.AddRange(Enumerable.Range(0, 6).Select(x => new GreenDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, 4).Select(x => new YellowDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, 3).Select(x => new RedDice()).ToList<IDice>());
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public List<IDice> Dice
		{
			get => dice;
		}

		public int GreenCount
		{
			get
			{
				return dice.FindAll(x => x.DiceType == typeof(GreenDice).Name).Count;
			}
		}

		public int YellowCount
		{
			get
			{
				return dice.FindAll(x => x.DiceType == typeof(YellowDice).Name).Count;
			}
		}

		public int RedCount
		{
			get
			{
				return dice.FindAll(x => x.DiceType == typeof(RedDice).Name).Count;
			}
		}

		public int SantaCount
		{
			get
			{
				return dice.FindAll(x => x.DiceType == typeof(SantaDice).Name).Count;
			}
		}

		public int HeroCount
		{
			get
			{
				return dice.FindAll(x => x.DiceType == typeof(HeroDice).Name).Count;
			}
		}

		public int HeroineCount
		{
			get
			{
				return dice.FindAll(x => x.DiceType == typeof(HeroineDice).Name).Count;
			}
		}

		public int TotalCount
		{
			get
			{
				return dice.Count;
			}

		}

		public List<IDice> GrabDice(int rollsNeeded, IGameSettings settings, IRandomNumberProvider randomNumberProvider)
		{
			List<IDice> grabbedDice = new List<IDice>();

			CheckAndRefill(rollsNeeded, settings);

			for (int i = 0; i < rollsNeeded; i++)
			{
				int index = randomNumberProvider.GetRandomNumber(0, TotalCount);
				grabbedDice.Add(dice[index]);
				dice.RemoveAt(index);
			}

			AlertPropertyChanged();

			return grabbedDice;
		}

		private void FillBag(IGameSettings settings)
		{
			int greenDiceNeeded = 6 - GreenCount;
			int yellowDiceNeeded = 4 - YellowCount;
			int redDiceNeeded = 3 - RedCount;

			if (settings.IncludedSanta)
			{
				if(greenDiceNeeded > 0)
				{
					greenDiceNeeded--;
				}
				else
				{
					int index = Dice.FindIndex(x => x.DiceType == typeof(GreenDice).Name);
					Dice.RemoveAt(index);
				}
			}

			if (settings.IncludedSanta && !usedSanta)
			{
				dice.Add(new SantaDice());
				usedSanta = true;
			}

			if (settings.IncludedHero)
			{
				if (yellowDiceNeeded > 0)
				{
					yellowDiceNeeded--;
				}
				else
				{
					Dice.RemoveAt(Dice.FindIndex(x => x.DiceType == typeof(YellowDice).Name));
				}
				 
				dice.Add(new HeroDice());
			}

			if (settings.IncludedHeroine)
			{
				if (yellowDiceNeeded > 0)
				{
					yellowDiceNeeded--;
				}
				else
				{
					Dice.RemoveAt(Dice.FindIndex(x => x.DiceType == typeof(YellowDice).Name));
				}
				dice.Add(new HeroineDice());
			}

			dice.AddRange(Enumerable.Range(0, greenDiceNeeded).Select(x => new GreenDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, yellowDiceNeeded).Select(x => new YellowDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, redDiceNeeded).Select(x => new RedDice()).ToList<IDice>());

			AlertPropertyChanged();
		}

		public void ResetBag(IGameSettings settings)
		{
			usedSanta = false;
			dice.Clear();
			FillBag(settings);
		}

		/// <summary>
		/// Refill checks if it will have enought dice to satisfy the current roll. Depending on how many footsteps have already been taken,
		/// the bag will be filled or not. This allows for bag to be filled only when necessary.
		/// </summary>
		private void CheckAndRefill(int count, IGameSettings settings)
		{
			if (TotalCount >= count)
			{
				return;
			}

			FillBag(settings);
		}

		public void ReturnDice(IDice dice)
		{
			Dice.Add(dice);
			AlertPropertyChanged();
		}

		private void AlertPropertyChanged()
		{
			OnPropertyChanged("GreenCount");
			OnPropertyChanged("YellowCount");
			OnPropertyChanged("RedCount");
			OnPropertyChanged("SantaCount");
			OnPropertyChanged("HeroCount");
			OnPropertyChanged("HeroineCount");
		}

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
