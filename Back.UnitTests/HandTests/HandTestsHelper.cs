using Back.Dice;
using Back.Game;
using NSubstitute;

namespace Back.UnitTests.HandTests
{
	class HandTestsHelper
	{
		internal IGame InitGameStub()
		{
			IGame gameStub = Substitute.For<IGame>();
			gameStub.Hand = new Hand(gameStub);
			gameStub.Bag = new Bag(gameStub);
			gameStub.ScoreDecorator = new ScoreDecorator();

			return gameStub;
		}
	}
}
