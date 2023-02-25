using Back.Game;

namespace Back.Command
{
	public class StartCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.StartGame();
		}
	}
}
