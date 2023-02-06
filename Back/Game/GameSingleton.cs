using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Game
{
	public class GameSingleton
	{
		private static IGame game;
		public static IGame Game
		{
			get
			{
				if (game == null)
					game = new Game();

				return game;
			}
		}

		private GameSingleton() { }

	}
}
