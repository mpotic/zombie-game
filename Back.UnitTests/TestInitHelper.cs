using Back.Dice;
using Back.Game;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.UnitTests
{
	class TestInitHelper
	{
		internal IGame InitGameStub()
		{
			IGame gameStub = Substitute.For<IGame>();
			gameStub.Hand = new Hand(new RandomNumberProvider());
			gameStub.Bag = new Bag();
			gameStub.ScoreDecorator = new ScoreDecorator();
			gameStub.GameSettings = new GameSettings();

			return gameStub;
		}
	}
}
