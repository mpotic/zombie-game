using Back.Game;

namespace Back.Command
{
	public class StopCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.instance.Game.StopAction();
		}
	}
}
