using ViewModel.Options;
using System.Windows;
using System.Windows.Controls;
using ZombieGame.Callback;
using ViewModel;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for Players.xaml
	/// </summary>
	public partial class Players : UserControl
	{
		private IPlayersViewModel playersViewModel = new PlayersViewModel();

		public Players()
		{
			InitializeComponent();

			PlayersListElement.ItemsSource = playersViewModel.Players;
			PlayerListViewElementSingleton.PlayersList = PlayersListElement;
		}

		private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			PlayerCallback callback = new PlayerCallback();
			OptionsSingleton.Options.AddNewPlayer(PlayerName.Text, callback);
			PlayerName.Text = "";
		}

		// TODO: Rewrite so that Command is used.
		//private void Item_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		//{
		//	IPlayer player = (IPlayer)((ContentPresenter)sender).Content;
		//	if (player == GameSingleton.instance.Game.CurrentPlayer)
		//		return;

		//	PlayerListSingleton.instance.PlayersList.Players.Remove(player);
		//}
	}
}
