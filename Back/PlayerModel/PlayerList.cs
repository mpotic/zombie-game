using Back.Helpers.Events;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Back.PlayerModel
{
	public class PlayerList : IPlayerList, INotifyCollectionChanged, INotifyPropertyChanged
	{
		private IPlayer currentPlayer;

		public PlayerList()
		{
			Players = new List<IPlayer>();
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public event PropertyChangedEventHandler PropertyChanged;

		public IPlayer CurrentPlayer
		{
			get
			{
				return currentPlayer;
			}
			set
			{
				currentPlayer = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPlayer"));
			}
		}

		public List<IPlayer> Players { get; set; }

		public void AddPlayer(string name)
		{
			Player newPlayer = new Player(name);

			if (Players.Contains(newPlayer) || string.IsNullOrWhiteSpace(name))
			{
				return;
			}

			Players.Add(newPlayer);
			if (CurrentPlayer == null)
			{
				CurrentPlayer = newPlayer;
			}

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newPlayer));
		}

		public void ResetPlayersScore()
		{
			foreach (IPlayer player in Players)
			{
				player.TotalBrainCount = 0;
			}
		}

		public void RemoveAllPlayers()
		{
			while (Players.Count > 0)
			{
				Players.RemoveAt(0);
			}

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void SetFirstPlayerAsCurrent()
		{
			CurrentPlayer = Players.FirstOrDefault();
		}

		public void ChangeCurrentPlayerToNext()
		{
			CurrentPlayer = Players[(Players.IndexOf(CurrentPlayer) + 1) % Players.Count];
		}

		public void DelayedChangeCurrentPlayerToNext()
		{
			currentPlayer = Players[(Players.IndexOf(CurrentPlayer) + 1) % Players.Count];
			PropertyChanged?.Invoke(this, new CustomPropertyChangedEventArgs(nameof(CurrentPlayer),
				CustomEnumPropertyChangedEventArgs.DELAYED_UPDATE));
		}
	}
}
