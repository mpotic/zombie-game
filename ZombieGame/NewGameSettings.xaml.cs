using ViewModel.Options;
using System.Windows;
using Common.DTO;

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
			bool useSanta = IncludeSanta.IsChecked.Value;
			bool useHero = IncludeHero.IsChecked.Value;
			bool useHeroine = IncludeHeroine.IsChecked.Value;
			IGameSettingsInfo gameSettingsInfo = new GameSettingsInfo(useSanta, useHero, useHeroine);

			OptionsSingleton.instance.Options.SetupNewGameAction(gameSettingsInfo);

			this.DialogResult = true;
			this.Close();
		}
	}
}
