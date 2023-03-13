using Back.Game;

namespace ViewModel.Command
{
	public class RollCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.RollAction();
		}
	}
}
