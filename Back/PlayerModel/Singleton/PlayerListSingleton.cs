namespace Back.PlayerModel.Singleton
{
	public class PlayerListSingleton : IPlayerListSingleton
	{
		public static readonly PlayerListSingleton instance = new PlayerListSingleton();

		public IPlayerList PlayersList { get; }

		private PlayerListSingleton()
		{
			this.PlayersList = new PlayerList();
		}
	}
}
