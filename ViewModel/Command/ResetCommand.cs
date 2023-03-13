using Back.Game;

namespace ViewModel.Command
{
	public class ResetCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.ResetGame();
		}
	}
}
