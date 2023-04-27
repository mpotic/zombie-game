using Back.Dice;
using Back.Game;
using NSubstitute;

namespace Back.UnitTests
{
	class TestInitHelper
	{
		internal IGame InitGameStub()
		{
			IGame gameStub = Substitute.For<IGame>();

			gameStub.Hand = new Hand(new RandomNumberProvider());
			gameStub.Bag = new Bag();
			gameStub.Score = new Score();
			gameStub.GameSettings = new GameSettings();

			return gameStub;
		}
	}
}
