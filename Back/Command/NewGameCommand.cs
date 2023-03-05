using Back.Game;

namespace Back.Command
{
	public class NewGameCommand : ICommand
	{
		public bool IncludeSanta { get; set; }
		public void Execute()
		{
			GameSingleton.instance.Game.SetupNewGame(IncludeSanta);
		}
	}
}
