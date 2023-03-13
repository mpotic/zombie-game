using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ViewModel
{
	public class PlayersViewModel : IPlayersViewModel
	{
		private ObservableCollection<IPlayer> players = new ObservableCollection<IPlayer>();

		public ObservableCollection<IPlayer> Players
		{
			get => players;
		}

		public PlayersViewModel()
		{
			((PlayerList)PlayerListSingleton.instance.PlayersList).CollectionChanged += UpdatePlayersProperty;
		}

		void UpdatePlayersProperty(object sender, NotifyCollectionChangedEventArgs args)
		{
			if(args.Action == NotifyCollectionChangedAction.Reset)
			{
				while(Players.Count > 0)
				{
					Players.RemoveAt(0);
				}
			}
			else if (args.Action == NotifyCollectionChangedAction.Add)
			{
				Players.Add((IPlayer)args.NewItems[0]);
			}
			else if(args.Action == NotifyCollectionChangedAction.Remove)
			{
				Players.Remove((IPlayer)args.OldItems[0]);
			}
		}
	}
}
