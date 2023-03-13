using Back.PlayerModel.Visitor;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Back.PlayerModel
{
	public class Player : IPlayer, INotifyPropertyChanged		// TODO: Is used in the View. Maybe should utilize a seperate ViewModel for Player.
	{
		private string name;

		private int totalBrainCount = 0;

		public Player() { }

		public Player(string name)
		{
			Name = name;
		}

		public int TotalBrainCount
		{
			get { return totalBrainCount; }
			set
			{
				totalBrainCount = value;
				OnPropertyChanged();
			}
		}

		public string Name { get => name; set => name = value; }

		public void Accept(IPlayerVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;

			Player player = (Player)obj;
			return player.Name == this.Name;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
