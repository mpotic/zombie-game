using Back.Game;

namespace Back.PlayerModel.Visitor
{
	public class SaveTurnPlayerVisitor : IPlayerVisitor
	{
		public void Visit(IPlayer player)
		{
			if(GameSingleton.instance.Game.ScoreDecorator.Killed)
			{
				return;
			}	

			player.TotalBrainCount += GameSingleton.instance.Game.ScoreDecorator.BrainsCount;
		}
	}
}
