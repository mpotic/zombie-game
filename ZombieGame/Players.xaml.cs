using Back;
using Back.Game;
using Back.PlayerModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

			PlayersListElement.ItemsSource = PlayerListSingleton.PlayerList.Players;
		}

		private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			Player player = new Player();
			player.Name = PlayerName.Text;
			PlayerListSingleton.PlayerList.Players.Add(player);
		}
	}
}
