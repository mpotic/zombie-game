using ViewModel.Options;
using System.Windows;
using System.Windows.Controls;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for Options.xaml
	/// </summary>
	public partial class Options : UserControl
	{
		public Options()
		{
			InitializeComponent();
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.instance.Options.ResetAction();
		}

		private void RollButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.instance.Options.RollAction();
		}

		private void StopButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.instance.Options.StopAction();
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.instance.Options.StartAction();
		}

		private void NewGameButton_Click(object sender, RoutedEventArgs e)
		{
			NewGameSettings gameSettingsWindow = new NewGameSettings();

			gameSettingsWindow.Owner = Application.Current.MainWindow;
			gameSettingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

			gameSettingsWindow.ShowDialog();
		}

		private void BussCheckBox_CheckedUnchecked(object sender, RoutedEventArgs e)
		{
			bool? useBuss = BussCheckBox.IsChecked;

			if(useBuss == null)
			{
				return;
			}

			OptionsSingleton.instance.Options.ConfigureBussAction((bool)useBuss);
		}
	}
}
