using Back.PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.UnitTests.ScenarioTests
{
	public class TestPlayerList : IPlayerList
	{
		public List<IPlayer> Players { get; set; }

		public IPlayer CurrentPlayer { get; set; }

		public void AddPlayer(string name)
		{
			return;
		}

		public void ChangeCurrentPlayerToNext()
		{
			return;
		}

		public void RemoveAllPlayers()
		{
			return;
		}

		public void ResetPlayersScore()
		{
			return;
		}

		public void SetFirstPlayerAsCurrent()
		{
			return;
		}
	}
}
