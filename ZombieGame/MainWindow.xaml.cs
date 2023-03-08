using Back.Game;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static bool Killed = true;

		public MainWindow()
		{
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
		}
	}
}
