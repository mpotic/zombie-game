using Back.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Command
{
	public class ResetCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.Game.ResetGame();
		}
	}
}
