using Back.Game;
using System.Collections.ObjectModel;

namespace Back.PlayerModel
{
	public class PlayerList : IPlayerList
	{
		ObservableCollection<IPlayer> players = new ObservableCollection<IPlayer>();

		public ObservableCollection<IPlayer> Players
		{
			get => players;
			set
			{
				players = value;
			}
		}

		public void AddPlayer(string name)
		{
			Player newPlayer = new Player(name);

			if (Players.Contains(newPlayer) || string.IsNullOrWhiteSpace(name))
				return; //TODO: Maybe add alert

			Players.Add(newPlayer);
			if (GameSingleton.instance.Game.CurrentPlayer == null)
				GameSingleton.instance.Game.CurrentPlayer = newPlayer;
		}

		public void ResetPlayersScore()
		{
			foreach(IPlayer player in Players)
			{
				player.TotalBrainCount = 0;
			}
		}
	}
}
