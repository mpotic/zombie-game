using Back.Game;

namespace ViewModel.Command
{
	public class StopCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.StopAction();
		}
	}
}
