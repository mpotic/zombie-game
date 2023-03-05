using Back.Options;
using System.Windows;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for NewGameSettings.xaml
	/// </summary>
	public partial class NewGameSettings : Window
	{
		public NewGameSettings()
		{
			InitializeComponent();
		}

		private void StartNewGame_Click(object sender, RoutedEventArgs e)
		{
			bool includeSanta = IncludeSanta.IsChecked.Value;
			OptionsSingleton.Options.SetupNewGame(includeSanta);

			this.DialogResult = true;
			this.Close();
		}
	}
}
