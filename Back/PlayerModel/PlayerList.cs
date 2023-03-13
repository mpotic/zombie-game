using Back.Game;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Back.PlayerModel
{
	public class PlayerList : IPlayerList, INotifyCollectionChanged
	{
		List<IPlayer> players = new List<IPlayer>();

		public List<IPlayer> Players
		{
			get => players;
			set
			{
				players = value;
			}
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;
		
		public void AddPlayer(string name)
		{
			Player newPlayer = new Player(name);

			if (Players.Contains(newPlayer) || string.IsNullOrWhiteSpace(name))
			{
				return;
			}

			Players.Add(newPlayer);
			if (GameSingleton.instance.Game.CurrentPlayer == null)
			{
				GameSingleton.instance.Game.CurrentPlayer = newPlayer;
			}

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newPlayer));
		}

		public void ResetPlayersScore()
		{
			foreach(IPlayer player in Players)
			{
				player.TotalBrainCount = 0;
			}
		}

		public void RemoveAllPlayers()
		{
			while(Players.Count > 0)
			{
				Players.RemoveAt(0);
			}
			
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
}
