﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}