using Back.Game;

namespace Back.PlayerModel.Visitor
{
	public class SaveTurnPlayerVisitor : IPlayerVisitor
	{
		public void Visit(IPlayer player)
		{
			player.TotalBrainCount += GameSingleton.instance.Game.Score.BrainsCount;
		}
	}
}
