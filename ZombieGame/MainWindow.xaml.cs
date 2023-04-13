using System;
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

		public MainWindow()
		{
			InitializeComponent();

			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			((KilledViewModel)KilledViewModel).PropertyChanged += SwitchVisibility_PropertyChanged;
		}

		public IKilledViewModel KilledViewModel { get => killedViewModel; set => killedViewModel = value; }

		/// <summary>
		/// Makes RIP image visible and buttons (Options) invisible for 1.2 seconds.
		/// </summary>
		private void SwitchVisibility_PropertyChanged(object sender, PropertyChangedEventArgs args)
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

				Thread.Sleep(1200);

				Dispatcher.Invoke(() =>
				{
					Options_UserControl.Visibility = Visibility.Visible;
					RIPImage_Border.Visibility = Visibility.Hidden;
				});
			});
		}
	}
}
