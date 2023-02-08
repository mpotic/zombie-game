using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PlayerModel
{
	public class ChangePlayerVisitor : IPlayerVisitor
	{
		public void Visit(IPlayer player)
		{
			int nextPlayerIndex = -1;
			do
			{
				int currentPlayerIndex = PlayerListSingleton.PlayerList.Players.IndexOf(player);
				currentPlayerIndex++;
				nextPlayerIndex = currentPlayerIndex % PlayerListSingleton.PlayerList.Players.Count;
			} while (PlayerListSingleton.PlayerList.Players[nextPlayerIndex].Status == PlayerStatus.DEAD);
		}
	}
}
