using Back.Dice;
using Back.Game;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.UnitTests.BagTests
{
	class BagTestsHelper
	{
		internal IGame InitGameStub()
		{
			IGame gameStub = Substitute.For<IGame>();
			gameStub.Hand = new Hand(gameStub);
			gameStub.Bag = new Bag(gameStub);
			gameStub.GameSettings = new GameSettings();
			gameStub.ScoreDecorator = new ScoreDecorator();

			return gameStub;
		}
	}
}
