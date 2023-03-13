using System.Windows;
using ViewModel;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IKilledViewModel killedViewModel = new KilledViewModel();

		public IKilledViewModel KilledViewModel { get => killedViewModel; set => killedViewModel = value; }

		public MainWindow()
		{
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
		}
	}
}
