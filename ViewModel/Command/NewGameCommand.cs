using Back.Game;

namespace ViewModel.Command
{
	public class NewGameCommand : ICommand
	{
		private readonly bool includedSanta;

		private readonly bool includedHero;

		private readonly bool includedHeroine;

		public NewGameCommand(bool includedSanta, bool includedHero, bool includedHeroine)
		{
			this.includedSanta = includedSanta;
			this.includedHero = includedHero;
			this.includedHeroine = includedHeroine;
		}

		public void Execute()
		{
			GameSingleton.instance.Game.SetupNewGame(includedSanta, includedHero, includedHeroine);
		}
	}
}
