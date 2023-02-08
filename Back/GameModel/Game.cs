using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Back.PlayerModel;

namespace Back.Game
{
	public class Game : IGame
	{
		private AllDice dice = new AllDice();
		private IPlayer currentPlayer = null;
		private Turn turn = new Turn();

		public AllDice Dice { get => dice; set => dice = value; }
		public Turn Turn { get => turn; set => turn = value; }
		public IPlayer CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
	}
}
