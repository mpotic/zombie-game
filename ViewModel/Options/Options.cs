using ViewModel.Command;
using Back.PlayerModel.Singleton;
using Common.DTO;

namespace ViewModel.Options
{
	public class Options : IOptions
	{
		Invoker invoker = new Invoker();

		public void AddNewPlayer(string name)
		{
			PlayerListSingleton.instance.PlayersList.AddPlayer(name);
		}

		public void RollAction()
		{
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
			{
				return;
			}

			RollCommand command = new RollCommand();
			invoker.ExecuteCommand(command);
		}

		public void StopAction()
		{
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
			{
				return;
			}

			ICommand command = new StopCommand();
			invoker.ExecuteCommand(command);
		}

		public void ResetAction()
		{
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
			{
				return;
			}

			ICommand command = new ResetCommand();
			invoker.ExecuteCommand(command);
		}

		public void StartAction()
		{
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
			{
				return;
			}

			ICommand command = new StartCommand();
			invoker.ExecuteCommand(command);
		}

		public void SetupNewGameAction(IGameSettingsInfo gameSettingsInfo)
		{
			NewGameCommand command = new NewGameCommand(gameSettingsInfo);

			invoker.ExecuteCommand(command);
		}

		public void ConfigureBussAction(bool useBuss)
		{
			ConfigBussCommand command = new ConfigBussCommand(useBuss);

			invoker.ExecuteCommand(command);
		}
	}
}
