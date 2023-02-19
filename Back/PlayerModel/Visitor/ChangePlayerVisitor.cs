using Back.Game;
using Back.PlayerModel.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PlayerModel.Visitor
{
	public class ChangePlayerVisitor : IPlayerVisitor
	{
		public void Visit(IPlayer player)
		{
			int currentPlayerIndex = PlayerListSingleton.PlayerList.Players.IndexOf(player);
			currentPlayerIndex++;
			int	nextPlayerIndex = currentPlayerIndex % PlayerListSingleton.PlayerList.Players.Count;
			GameSingleton.Game.CurrentPlayer = PlayerListSingleton.PlayerList.Players[nextPlayerIndex];
		}
	}
}
