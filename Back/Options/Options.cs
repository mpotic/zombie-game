using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Callback;
using Back.Command;
using Back.Dice;
using Back.Game;
using Back.PlayerModel.Singleton;
using Back.PlayerModel.Visitor;

namespace Back.Options
{
	public class Options : IOptions
	{
		Invoker invoker = new Invoker();

		public void AddNewPlayer(string name, IPlayerCallback playerCallback)
		{
			PlayerListSingleton.PlayerList.AddPlayer(name);
		}

		public void RollAction(IPlayerCallback playerCallback)
		{
			int previousIndex = PlayerListSingleton.PlayerList.Players.IndexOf(GameSingleton.Game.CurrentPlayer);
			RollCommand command = new RollCommand();
			invoker.ExecuteCommand(command);

			if (GameSingleton.Game.Score.Killed)
			{
				playerCallback.ChangeActivePlayer(previousIndex, PlayerListSingleton.PlayerList.Players.IndexOf(GameSingleton.Game.CurrentPlayer));
			}
		}

		public void StopAction(IPlayerCallback playerCallback)
		{
			int previousIndex = PlayerListSingleton.PlayerList.Players.IndexOf(GameSingleton.Game.CurrentPlayer);
			ICommand command = new StopCommand();
			invoker.ExecuteCommand(command);

			playerCallback.ChangeActivePlayer(previousIndex, PlayerListSingleton.PlayerList.Players.IndexOf(GameSingleton.Game.CurrentPlayer));
		}
	}
}
