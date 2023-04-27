using Back.Dice;
using Back.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Back.UnitTests.HandTests
{
	[TestClass]
	public class HandUnitTests
	{
		private Hand hand;

		private IGame game;

		private TestInitHelper testInitHelper = new TestInitHelper();

		[TestInitialize]
		public void HandUnitTestsInitialize()
		{
			game = testInitHelper.InitGameStub();
			hand = (Hand)game.Hand;
		}

		[TestMethod]
		public void GrabbedDice_OnCreation_ReturnsEmptyList()
		{
			var actual = hand.GrabbedDice;

			Assert.IsNotNull(actual);
			Assert.AreEqual(0, actual.Count);
		}

		[TestMethod]
		public void GrabbedDice_OnGrabAndRollDice_HasThreeDice()
		{
			hand.GrabAndRollDice(game.Score, game.Bag, game.GameSettings);
			var actual = hand.GrabbedDice;

			Assert.AreEqual(3, actual.Count);
		}
	}
}
