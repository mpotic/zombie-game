using Back;
using Back.Game;
using Back.Options;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZombieGame.Callback;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for Players.xaml
	/// </summary>
	public delegate void SetActivePlayerColor(int index);
	public partial class Players : UserControl
	{

		public Players()
		{
			InitializeComponent();

			PlayersListElement.ItemsSource = PlayerListSingleton.PlayerList.Players;
			PlayersListElement.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
			PlayerCallback.playersList = PlayersListElement;
		}
		private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			PlayerCallback callback = new PlayerCallback();
			OptionsSingleton.Options.AddNewPlayer(PlayerName.Text, callback);
			PlayerName.Text = "";
		}
		private void ItemContainerGenerator_StatusChanged(object sender, System.EventArgs e)
		{
			if (PlayersListElement.Items.Count != 1 || PlayersListElement.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
				return;

			ListViewItem item = PlayersListElement.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
			item.Background = Brushes.LightGreen;
		}

		private void Item_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			IPlayer player = (IPlayer)((ContentPresenter)sender).Content;
			if (player == GameSingleton.Game.CurrentPlayer)
				return;

			PlayerListSingleton.PlayerList.Players.Remove(player);

		}

		private void PlayersListElement_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
