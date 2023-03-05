using System.Collections.ObjectModel;

namespace Back.PlayerModel
{
	public interface IPlayerList
	{
		ObservableCollection<IPlayer> Players { get; set; }
		
		void AddPlayer(string name);
		
		void ResetPlayersScore();

		void RemoveAllPlayers();
	}
}
