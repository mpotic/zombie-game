using Back.Callback;
using Back.Command;
using Back.Game;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;

namespace Back.Options
{
	public class Options : IOptions
	{
		Invoker invoker = new Invoker();

		public void AddNewPlayer(string name, IPlayerCallback playerCallback)
		{
			PlayerListSingleton.instance.PlayersList.AddPlayer(name);
			IPlayer player = GameSingleton.instance.Game.CurrentPlayer;
			int currentPlayerIndex = PlayerListSingleton.instance.PlayersList.Players.IndexOf(player);
			playerCallback.ChangeActivePlayer(currentPlayerIndex);
		}

		public void RollAction(IPlayerCallback playerCallback)
		{
			RollCommand command = new RollCommand();
			invoker.ExecuteCommand(command);

			if (GameSingleton.instance.Game.Score.Killed)
			{

				IPlayer player = GameSingleton.instance.Game.CurrentPlayer;
				int currentPlayerIndex = PlayerListSingleton.instance.PlayersList.Players.IndexOf(player);
				playerCallback.ChangeActivePlayer(currentPlayerIndex); 
				GameSingleton.instance.Game.Score.Killed = false;
			}
		}

		public void StopAction(IPlayerCallback playerCallback)
		{
			ICommand command = new StopCommand();
			invoker.ExecuteCommand(command);

			IPlayer player = GameSingleton.instance.Game.CurrentPlayer;
			int currentPlayerIndex = PlayerListSingleton.instance.PlayersList.Players.IndexOf(player);
			playerCallback.ChangeActivePlayer(currentPlayerIndex);
		}

		public void ResetAction()
		{
			ICommand command = new ResetCommand();
			invoker.ExecuteCommand(command);
		}

		public void StartAction(IPlayerCallback playerCallback)
		{
			ICommand command = new StartCommand();
			invoker.ExecuteCommand(command);

			playerCallback.ChangeActivePlayer(0);
		}
	}
}
