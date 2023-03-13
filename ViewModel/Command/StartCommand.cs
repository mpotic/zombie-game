using Back.Game;

namespace ViewModel.Command
{
	public class StartCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.StartGame();
		}
	}
}
