using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ViewModel;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IKilledViewModel killedViewModel = new KilledViewModel();

		private int delayDurationMilliseconds = 1600;

		public MainWindow()
		{
			InitializeComponent();

			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			((KilledViewModel)KilledViewModel).PropertyChanged += SwitchRipOptionsVisibility_PropertyChanged;
		}

		public IKilledViewModel KilledViewModel { get => killedViewModel; set => killedViewModel = value; }

		/// <summary>
		/// Makes RIP image visible and buttons (Options) invisible for 1.2 seconds, and vice versa.
		/// </summary>
		private void SwitchRipOptionsVisibility_PropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			if (!args.PropertyName.Equals("Killed") || !((IKilledViewModel)sender).Killed)
			{
				return;
			}

			Task.Run(() =>
			{
				Dispatcher.Invoke(() =>
				{
					Options_UserControl.Visibility = Visibility.Hidden;
					RIPImage_Border.Visibility = Visibility.Visible;
				});

				Thread.Sleep(delayDurationMilliseconds);

				Dispatcher.Invoke(() =>
				{
					Options_UserControl.Visibility = Visibility.Visible;
					RIPImage_Border.Visibility = Visibility.Hidden;
				});
			});
		}
	}
}
