using ViewModel.Callback;
using ViewModel.Command;
using Back.Game;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using System.Threading;
using System.Threading.Tasks;

namespace ViewModel.Options
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
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
				return;

			RollCommand command = new RollCommand();
			invoker.ExecuteCommand(command);

			if (GameSingleton.instance.Game.ScoreDecorator.Killed)
			{
				IPlayer player = GameSingleton.instance.Game.CurrentPlayer;
				int currentPlayerIndex = PlayerListSingleton.instance.PlayersList.Players.IndexOf(player);
				Task.Run(() => 
				{
					Thread.Sleep(1200);
					playerCallback.ChangeActivePlayer(currentPlayerIndex);
				});
			}
		}

		public void StopAction(IPlayerCallback playerCallback)
		{
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
				return;

			ICommand command = new StopCommand();
			invoker.ExecuteCommand(command);

			IPlayer player = GameSingleton.instance.Game.CurrentPlayer;
			int currentPlayerIndex = PlayerListSingleton.instance.PlayersList.Players.IndexOf(player);
			playerCallback.ChangeActivePlayer(currentPlayerIndex);
		}

		public void ResetAction()
		{
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
				return;

			ICommand command = new ResetCommand();
			invoker.ExecuteCommand(command);
		}

		public void StartAction(IPlayerCallback playerCallback)
		{
			if (PlayerListSingleton.instance.PlayersList.Players.Count == 0)
				return;

			ICommand command = new StartCommand();
			invoker.ExecuteCommand(command);

			playerCallback.ChangeActivePlayer(0);
		}

		public void SetupNewGameAction(bool includeSanta, bool includeHero, bool includeHeroine, IPlayerCallback playerCallback)
		{
			NewGameCommand command = new NewGameCommand();
			command.IncludeSanta = includeSanta;
			command.IncludeSanta = includeSanta;
			command.IncludeSanta = includeSanta;

			invoker.ExecuteCommand(command);

			IPlayer player = GameSingleton.instance.Game.CurrentPlayer;
			int currentPlayerIndex = PlayerListSingleton.instance.PlayersList.Players.IndexOf(player);
			playerCallback.ChangeActivePlayer(currentPlayerIndex);
		}
	}
}
