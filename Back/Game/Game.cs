using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Game
{
	public class Game : IGame
	{
		private AllDice dice = new AllDice();
		private Player player = new Player();
		private Turn turn = new Turn();

		public AllDice Dice { get => dice; set => dice = value; }
		public Player Player { get => player; set => player = value; }
		public Turn Turn { get => turn; set => turn = value; }

		
	}
}
