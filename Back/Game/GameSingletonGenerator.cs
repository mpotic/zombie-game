namespace Back.Game
{
	public class GameSingletonGenerator
	{
		private readonly IGameSingleton gameSingleton;

		public GameSingletonGenerator()
		{
			gameSingleton = GameSingleton.instance;
		}

		internal GameSingletonGenerator(IGameSingleton gameSingleton)
		{
			this.gameSingleton = gameSingleton;
		}

		public IGameSingleton GetGameSingleton()
		{
			return gameSingleton;
		}
	}
}
