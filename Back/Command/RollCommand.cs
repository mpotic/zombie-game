using Back.Dice;
using Back.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Command
{
	class RollCommand : ICommand
	{
		public void Execute()
		{
			GameSingleton.Game.RollAction();
		}
	}
}
