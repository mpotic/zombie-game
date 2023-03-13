using ViewModel.Options;
using System.Windows;
using ZombieGame.Callback;

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
			bool includeHero = IncludeHero.IsChecked.Value;
			bool includedHeroine = IncludeHeroine.IsChecked.Value;

			OptionsSingleton.Options.SetupNewGameAction(includeSanta, includeHero, includedHeroine, new PlayerCallback());

			this.DialogResult = true;
			this.Close();
		}
	}
}
