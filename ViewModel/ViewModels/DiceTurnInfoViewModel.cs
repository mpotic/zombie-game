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

		public int GreenDiceCount
		{ 
			get => greenDiceCount;
			set
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

		public DiceTurnInfoViewModel()
		{
			GreenDiceCount = GameSingleton.instance.Game.Bag.GreenCount;
			YellowDiceCount = GameSingleton.instance.Game.Bag.YellowCount;
			RedDiceCount = GameSingleton.instance.Game.Bag.RedCount;

			((Bag)GameSingleton.instance.Game.Bag).PropertyChanged += UpdateDiceProperties;
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
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
