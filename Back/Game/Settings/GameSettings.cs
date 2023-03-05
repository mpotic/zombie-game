using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Back.Game
{
	public class GameSettings : IGameSettings, INotifyPropertyChanged
	{
		bool includedSanta = false;

		public bool IncludedSanta
		{
			get
			{
				return includedSanta;
			}
			set
			{
				includedSanta = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
