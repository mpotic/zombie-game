using Back.Dice;
using Back.Game;
using Back.PlayerModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Back.UnitTests.ScenarioTests
{
	/// <summary>
	/// Summary description for ScenarioTests
	/// </summary>
	[TestClass]
	public class ScenarioTests
	{
		private IGame game;

		private TestInitHelper testInitHelper = new TestInitHelper();

		[TestInitialize]
		public void InitializeScenarioTests()
		{
			game = new Game.Game();
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeGreenBrains_IsThree()
		{
			List<int> queueInit = new List<int>() { 0, 0, 0, 0, 1, 2};
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);

			game.RollAction();

			Assert.AreEqual(3, game.ScoreDecorator.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeYellowBrains_IsThree()
		{
			List<int> queueInit = new List<int>() { 6, 6, 6, 0, 0, 0 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);

			game.RollAction();

			Assert.AreEqual(3, game.ScoreDecorator.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeRedBrains_IsThree()
		{
			List<int> queueInit = new List<int>() { 10, 10, 10, 3, 3, 3};
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);

			game.RollAction();

			Assert.AreEqual(3, game.ScoreDecorator.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeGreenFootsteps_IsZero()
		{
			List<int> queueInit = new List<int>() { 0, 0, 0, 4, 5, 4};
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);

			game.RollAction();

			Assert.AreEqual(0, game.ScoreDecorator.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeYellowFootsteps_IsZero()
		{
			List<int> queueInit = new List<int>() { 6, 6, 6, 2, 2, 2 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);

			game.RollAction();

			Assert.AreEqual(0, game.ScoreDecorator.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeRedFootsteps_IsZero()
		{
			List<int> queueInit = new List<int>() { 10, 10, 10, 4, 4, 5 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);

			game.RollAction();

			Assert.AreEqual(0, game.ScoreDecorator.BrainsCount);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeGreenShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 0, 0, 0, 3, 3, 3};
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			game.RollAction();

			Assert.AreEqual(true, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeYellowShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 6, 6, 6, 2, 2, 2 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			game.RollAction();

			Assert.AreEqual(true, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeRedShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 10, 10, 10, 0, 1, 2 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			game.RollAction();

			Assert.AreEqual(true, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public async Task Killed_AfterRollActionFinishesWithThreeGreenShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 0, 0, 0, 3, 3, 3 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			await game.RollAction();

			Assert.AreEqual(false, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public async Task Killed_AfterRollActionFinishesWithThreeYellowShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 6, 6, 6, 2, 2, 2 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			await game.RollAction();

			Assert.AreEqual(false, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public async Task Killed_AfterRollActionFinishesWithThreeRedShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 10, 10, 10, 0, 1, 2 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			await game.RollAction();

			Assert.AreEqual(false, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeMixedShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 12, 9, 5, 0, 2, 3 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			game.RollAction();

			Assert.AreEqual(true, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public async Task Killed_AfterRollActionFinishesWithThreeMixedShotguns_IsTrue()
		{
			List<int> queueInit = new List<int>() { 12, 9, 5, 0, 2, 3 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			await game.RollAction();

			Assert.AreEqual(false, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public async Task BrainCount_AfterRollActionWithThreeMixedBrains_IsThree()
		{
			List<int> queueInit = new List<int>() { 12, 9, 5, 3, 0, 2 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			await game.RollAction();

			Assert.AreEqual(3, game.ScoreDecorator.BrainsCount);
		}

		[TestMethod]
		public void Killed_AfterRollActionWithOneOfEachColorEachWithADifferentSide_IsFalse()
		{
			List<int> queueInit = new List<int>() { 12, 9, 5, 3, 1, 3 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			game.RollAction();

			Assert.AreEqual(false, game.ScoreDecorator.Killed);
		}

		[TestMethod]
		public void BrainCount_AfterRollActionWithOneOfEachColorEachWithADifferentSide_IsOne()
		{
			List<int> queueInit = new List<int>() { 12, 9, 5, 3, 1, 3 };
			TestRandomNumberProvider randomNumberProvider = new TestRandomNumberProvider(queueInit);
			game.Hand = new Hand(randomNumberProvider);
			game.PlayerList = new TestPlayerList();

			game.RollAction();

			Assert.AreEqual(1, game.ScoreDecorator.BrainsCount);
		}
	}
}
