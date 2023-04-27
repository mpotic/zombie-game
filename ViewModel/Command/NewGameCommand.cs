using Back.Game;
using Common.DTO;

namespace ViewModel.Command
{
	public class NewGameCommand : ICommand
	{
		public IGameSettingsInfo GameSettingsInfo { get; set; }

		public NewGameCommand(IGameSettingsInfo gameSettingsInfo)
		{
			GameSettingsInfo = gameSettingsInfo;
		}

		public void Execute()
		{
			GameSingleton.instance.Game.SetupNewGame(GameSettingsInfo);
		}
	}
}
