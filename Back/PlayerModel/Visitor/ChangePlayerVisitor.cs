using Back.Game;
using Back.PlayerModel.Singleton;

namespace Back.PlayerModel.Visitor
{
	public class ChangePlayerVisitor : IPlayerVisitor
	{
		public void Visit(IPlayer player)
		{
			int currentPlayerIndex = PlayerListSingleton.instance.PlayersList.Players.IndexOf(player);
			currentPlayerIndex++;
			int	nextPlayerIndex = currentPlayerIndex % PlayerListSingleton.instance.PlayersList.Players.Count;
			GameSingleton.instance.Game.CurrentPlayer = PlayerListSingleton.instance.PlayersList.Players[nextPlayerIndex];
		}
	}
}
