using Back.Dice;
using Back.Game;
using NSubstitute;

namespace Back.UnitTests.BagTests
{
	class BagTestsHelper
	{
		internal IGame InitGameStub()
		{
			IGame gameStub = Substitute.For<IGame>();
			gameStub.Hand = new Hand();
			gameStub.Bag = new Bag();
			gameStub.GameSettings = new GameSettings();
			gameStub.ScoreDecorator = new ScoreDecorator();

			return gameStub;
		}
	}
}
