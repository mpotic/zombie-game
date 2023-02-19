using Back.Callback;
using Back.Game;
using Back.PlayerModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZombieGame.Callback
{
	public class PlayerCallback : IPlayerCallback
	{
		public static ListView playersList = null;
		public PlayerCallback() { }
		public void ChangeActivePlayer(int previous, int current)
		{
			ListViewItem item = playersList.ItemContainerGenerator.ContainerFromIndex(previous) as ListViewItem;
			item.Background = Brushes.Transparent;
			item = playersList.ItemContainerGenerator.ContainerFromIndex(current) as ListViewItem;
			item.Background = Brushes.LightGreen;
		}
	}
}