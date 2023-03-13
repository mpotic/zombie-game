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
		private List<IDice> dice = new List<IDice>();

		private bool usedSanta = false;

		public List<IDice> Dice 
		{ 
			get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

		public int TotalCount
		{
			get
			{
				return dice.Count;
			}
		}

		public int HeroDice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int HeroineDice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Bag()
		{
			dice.AddRange(Enumerable.Range(0, 6).Select(x => new GreenDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, 4).Select(x => new YellowDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, 3).Select(x => new RedDice()).ToList<IDice>());
		}

		public List<IDice> GrabDice(int count)
		{
			List<IDice> grabbedDice = new List<IDice>();
			Random random = new Random();

			CheckAndRefill();

			for (int i = 0; i < count; i++)
			{
				// To reduce the possibility of getting the same number twice in a row because randomness is based on time
				Thread.Sleep(1);

				int index = random.Next(0, TotalCount);
				grabbedDice.Add(dice[index]);
				dice.RemoveAt(index);
			}

			AlertPropertyChanged();

			return grabbedDice;
		}

		public void FillBag()
		{
			int greenDiceNeeded = 6 - GreenCount;
			int yellowDiceNeeded = 4 - YellowCount;
			int redDiceNeeded = 3 - RedCount;

			if (GameSingleton.instance.Game.GameSettings.IncludedSanta)
			{
				greenDiceNeeded--;
			}

			if (GameSingleton.instance.Game.GameSettings.IncludedHero)
			{
				yellowDiceNeeded--;
				//dice.Add(new HeroDice());
			}

			if (GameSingleton.instance.Game.GameSettings.IncludedHeroine)
			{
				yellowDiceNeeded--;
				//dice.Add(new HeroineDice());
			}

			if (GameSingleton.instance.Game.GameSettings.IncludedSanta && !usedSanta)
			{
				dice.Add(new SantaDice());
				usedSanta = true;
			}

			dice.AddRange(Enumerable.Range(0, greenDiceNeeded).Select(x => new GreenDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, yellowDiceNeeded).Select(x => new YellowDice()).ToList<IDice>());
			dice.AddRange(Enumerable.Range(0, redDiceNeeded).Select(x => new RedDice()).ToList<IDice>());

			AlertPropertyChanged();
		}

		public void ResetBag()
		{
			usedSanta = false;
			dice.Clear();
			FillBag();
		}

		public void CheckAndRefill()
		{
			if (TotalCount >= (3 - GameSingleton.instance.Game.Hand.GrabbedDice.Count))
			{
				return;
			}

			FillBag();
		}

		private void AlertPropertyChanged()
		{
			OnPropertyChanged("GreenCount");
			OnPropertyChanged("YellowCount");
			OnPropertyChanged("RedCount");
			OnPropertyChanged("SantaCount");
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
