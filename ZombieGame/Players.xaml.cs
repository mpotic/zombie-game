using ViewModel.Options;
using System.Windows;
using System.Windows.Controls;
using ViewModel;
using System.Windows.Data;

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

			Binding selectedItemBinding = new Binding
			{
				Source = playersViewModel,
				Path = new PropertyPath("CurrentPlayer"),
				Mode = BindingMode.OneWay
			};

			BindingOperations.SetBinding(PlayersListElement, ListView.SelectedItemProperty, selectedItemBinding);
		}

		private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.Options.AddNewPlayer(PlayerName.Text);
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
