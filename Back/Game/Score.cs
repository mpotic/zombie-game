using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Back.Game
{
	public class Score : INotifyPropertyChanged
	{
		private int brainsCount = 0;
		private int shotgunCount = 0;
		private int footstepsCount = 0;
		private bool killed = false;

		public int BrainsCount
		{
			get => brainsCount; set
			{
				brainsCount = value;
				OnPropertyChanged();
			}
		}
		public int ShotgunCount
		{
			get => shotgunCount;
			set
			{
				shotgunCount = value;
				OnPropertyChanged();
			}
		}
		public int FootstepsCount
		{
			get => footstepsCount;
			set
			{
				footstepsCount = value;
				OnPropertyChanged();
			}
		}

		public bool Killed { get => killed; set => killed = value; }

		public void ResetScore()
		{
			BrainsCount = 0;
			ShotgunCount = 0;
			FootstepsCount = 0;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
