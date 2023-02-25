using Back.Game;

namespace Back.Command
{
	public class ResetCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.ResetGame();
		}
	}
}
