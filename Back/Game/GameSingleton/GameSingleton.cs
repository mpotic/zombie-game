namespace Back.Game
{
	public class GameSingleton : IGameSingleton
	{
		public static readonly IGameSingleton instance = new GameSingleton();

		public IGame Game { get; }

		private GameSingleton()
		{
			Game = new Game();
		}
	}
}
