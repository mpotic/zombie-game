using Back.Game;

namespace ViewModel.Command
{
	class ConfigBussCommand : ICommand
	{
		public bool UseBuss { get; set; }

		public ConfigBussCommand(bool useBuss)
		{
			UseBuss = useBuss;
		}

		public void Execute()
		{
			GameSingleton.instance.Game.ConfigureBuss(UseBuss);
		}
	}
}
