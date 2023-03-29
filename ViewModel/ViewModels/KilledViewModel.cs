using Back.Game;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
	public class KilledViewModel : IKilledViewModel, INotifyPropertyChanged
	{
		private bool killed = false;

		public bool Killed
		{
			get => killed;
			private set
			{
				killed = value;
				OnPropertyChanged();
			}
		}

		public KilledViewModel()
		{
			Score score = (Score)GameSingleton.instance.Game.Factory.GetFlyweight(typeof(Score));
			score.PropertyChanged += UpdateKilled;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void UpdateKilled(object sender, PropertyChangedEventArgs args)
		{
			Killed = ((Score)sender).Killed;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
