using Back.Game;

namespace ViewModel.Command
{
	public class NewGameCommand : ICommand
	{
		public bool IncludeSanta { get; set; }

		public bool IncludeHero { get; set; }

		public bool IncludeHeroine { get; set; }

		public void Execute()
		{
			GameSingleton.instance.Game.SetupNewGame(IncludeSanta, IncludeHero, IncludeHeroine);
		}
	}
}
