using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace ViewModel
{
	public class PlayersViewModel : IPlayersViewModel, INotifyPropertyChanged
	{
		private ObservableCollection<IPlayer> players = new ObservableCollection<IPlayer>();

		private IPlayer currentPlayer;

		public IPlayer CurrentPlayer 
		{
			get
			{
				return currentPlayer;
			}
			private set
			{
				currentPlayer = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPlayer"));
			}
		}

		public ObservableCollection<IPlayer> Players
		{
			get => players;
		}

		public PlayersViewModel()
		{
			((PlayerList)PlayerListSingleton.instance.PlayersList).CollectionChanged += UpdatePlayersProperty;
			((PlayerList)PlayerListSingleton.instance.PlayersList).PropertyChanged += PlayerChanged;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void UpdatePlayersProperty(object sender, NotifyCollectionChangedEventArgs args)
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

		private void PlayerChanged(object sender, PropertyChangedEventArgs args)
		{
			Task.Run(() =>
			{
				if(Players.Count > 1)
				{
					Thread.Sleep(1200);
				}
				CurrentPlayer = ((IPlayerList)sender).CurrentPlayer;
			});
		}
	}
}
