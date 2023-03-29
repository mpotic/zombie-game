using Back.Dice;
using Back.Game;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
	public class DiceTurnInfoViewModel : IDiceTurnInfoViewModel, INotifyPropertyChanged
	{
		private int greenDiceCount;

		private int yellowDiceCount;

		private int redDiceCount;

		private int santaDiceCount;

		private int heroDiceCount;

		private int heroineDiceCount;

		private bool includedSanta;

		private bool includedHero;

		private bool includedHeroine;

		public int GreenDiceCount
		{
			get => greenDiceCount;
			private set
			{
				greenDiceCount = value;
				OnPropertyChanged();
			}
		}

		public int YellowDiceCount
		{
			get => yellowDiceCount;
			set
			{
				yellowDiceCount = value;
				OnPropertyChanged();
			}
		}

		public int RedDiceCount
		{
			get => redDiceCount;
			set
			{
				redDiceCount = value;
				OnPropertyChanged();
			}
		}

		public int SantaDiceCount
		{
			get => santaDiceCount;
			set
			{
				santaDiceCount = value;
				OnPropertyChanged();
			}
		}

		public int HeroDiceCount
		{
			get => heroDiceCount;
			set
			{
				heroDiceCount = value;
				OnPropertyChanged();
			}
		}

		public int HeroineDiceCount
		{
			get => heroineDiceCount;
			set
			{
				heroineDiceCount = value;
				OnPropertyChanged();
			}
		}

		public bool IncludedSanta
		{ 
			get => includedSanta;
			set 
			{
				includedSanta = value;
				OnPropertyChanged();
			}
		}

		public bool IncludedHero
		{
			get => includedHero;
			set
			{
				includedHero = value;
				OnPropertyChanged();
			}
		}

		public bool IncludedHeroine
		{
			get => includedHeroine;
			set
			{
				includedHeroine = value;
				OnPropertyChanged();
			}
		}

		public DiceTurnInfoViewModel()
		{
			GreenDiceCount = GameSingleton.instance.Game.Bag.GreenCount;
			YellowDiceCount = GameSingleton.instance.Game.Bag.YellowCount;
			RedDiceCount = GameSingleton.instance.Game.Bag.RedCount;

			((Bag)GameSingleton.instance.Game.Bag).PropertyChanged += UpdateDiceProperties;
			((GameSettings)GameSingleton.instance.Game.GameSettings).PropertyChanged += UpdateSettingsProperties;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void UpdateDiceProperties(object sender, PropertyChangedEventArgs args)
		{
			IBag bag = (IBag)sender;

			switch (args.PropertyName)
			{
				case "GreenCount":
					GreenDiceCount = bag.GreenCount;
					break;

				case "YellowCount":
					YellowDiceCount = bag.YellowCount;
					break;

				case "RedCount":
					RedDiceCount = bag.RedCount;
					break;

				case "SantaCount":
					SantaDiceCount = bag.SantaCount;
					break;

				case "HeroCount":
					HeroDiceCount = bag.HeroCount;
					break;

				case "HeroineCount":
					HeroineDiceCount = bag.HeroineCount;
					break;
			}
		}

		void UpdateSettingsProperties(object sender, PropertyChangedEventArgs args)
		{
			IGameSettings settings = (IGameSettings)sender;

			switch (args.PropertyName)
			{
				case "IncludedSanta":
					IncludedSanta = settings.IncludedSanta;
					break;

				case "IncludedHero":
					IncludedHero = settings.IncludedHero;
					break;
					
				case "IncludedHeroine":
					IncludedHeroine = settings.IncludedHeroine;
					break;
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
