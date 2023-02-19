using Back.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Back.PlayerModel
{
	public class PlayerList : IPlayerList, INotifyPropertyChanged
	{
		ObservableCollection<IPlayer> players = new ObservableCollection<IPlayer>();
		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<IPlayer> Players
		{
			get => players;
			set
			{
				players = value;
				OnPropertyChanged();
			}
		}

		public void AddPlayer(string name)
		{
			Player newPlayer = new Player(name);
			
			if (Players.Contains(newPlayer))
				return; //TODO: Maybe add alert
			
			Players.Add(newPlayer);
			if (GameSingleton.Game.CurrentPlayer == null)
				GameSingleton.Game.CurrentPlayer = newPlayer;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
