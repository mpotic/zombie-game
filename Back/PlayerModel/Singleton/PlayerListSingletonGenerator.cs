namespace Back.PlayerModel.Singleton
{
	public class PlayerListSingletonGenerator
	{
		private readonly IPlayerListSingleton playerListSingleton;

		public PlayerListSingletonGenerator()
		{
			playerListSingleton = PlayerListSingleton.instance;
		}

		internal PlayerListSingletonGenerator(IPlayerListSingleton playerListSingleton)
		{
			this.playerListSingleton = playerListSingleton;
		}

		public IPlayerListSingleton GetPlayerListSingleton()
		{
			return playerListSingleton;
		}
	}
}
