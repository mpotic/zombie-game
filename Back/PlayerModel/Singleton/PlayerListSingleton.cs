using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PlayerModel.Singleton
{
	public class PlayerListSingleton
	{
		private static IPlayerList playerList;
		public static IPlayerList PlayerList
		{
			get
			{
				if (playerList == null)
					playerList = new PlayerList();

				return playerList;
			}

			set => playerList = value;
		}
	}
}
