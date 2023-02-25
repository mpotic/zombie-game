using Back.Game;

namespace Back.Command
{
	public class RollCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.RollAction();
		}
	}
}
