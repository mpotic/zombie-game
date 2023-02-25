using Back.Game;
using Back.Options;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZombieGame.Callback;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for Players.xaml
	/// </summary>
	public partial class Players : UserControl
	{
		public Players()
		{
			InitializeComponent();

			PlayersListElement.ItemsSource = PlayerListSingleton.instance.PlayersList.Players;
			PlayerListViewElementSingleton.PlayersList = PlayersListElement;
		}

		private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			PlayerCallback callback = new PlayerCallback();
			OptionsSingleton.Options.AddNewPlayer(PlayerName.Text, callback);
			PlayerName.Text = "";
		}

		private void Item_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			IPlayer player = (IPlayer)((ContentPresenter)sender).Content;
			if (player == GameSingleton.instance.Game.CurrentPlayer)
				return;

			PlayerListSingleton.instance.PlayersList.Players.Remove(player);
		}
	}
}
