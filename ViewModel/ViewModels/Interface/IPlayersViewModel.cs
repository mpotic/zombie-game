using Back.PlayerModel;
using System.Collections.ObjectModel;

namespace ViewModel
{
	public interface IPlayersViewModel
	{
		ObservableCollection<IPlayer> Players { get; }
	}
}
