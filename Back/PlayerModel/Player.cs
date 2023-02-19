using Back.PlayerModel.Visitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Back.PlayerModel
{
	public class Player : IPlayer, INotifyPropertyChanged
	{
		private string name;
		private int totalBrainCount = 0;
		public event PropertyChangedEventHandler PropertyChanged;

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
				OnPropertyChanged(nameof(TotalBrainCount));
			}
		}

		public string Name { get => name; set => name = value; }

		public void Accept(IPlayerVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override string ToString()
		{
			return Name + '\n' + "Brains: " + TotalBrainCount;
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;

			Player player = (Player)obj;
			return player.Name == this.Name;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
