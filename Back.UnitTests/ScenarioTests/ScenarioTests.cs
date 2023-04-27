using Back.Dice;
using Back.Game;
using Back.PlayerModel;
using Common.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Back.UnitTests.ScenarioTests
{
	/// <summary>
	/// Summary description for ScenarioTests
	/// </summary>
	[TestClass]
	public class ScenarioTests
	{
		private IGame game;

		[TestInitialize]
		public void InitializeScenarioTests()
		{
			game = new Game.Game();

			var playerListStub = Substitute.For<IPlayerList>();
			playerListStub.When(x => x.ChangeCurrentPlayerToNext()).Do(x => { });
			game.PlayerList = playerListStub;
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeGreenBrains_IsThree()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 0, 1, 2);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(3, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeYellowBrains_IsThree()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(6, 6, 6, 0, 0, 0);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(3, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeRedBrains_IsThree()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(10, 10, 10, 3, 3, 3);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(3, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeGreenFootsteps_IsZero()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 4, 5, 4); 
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(0, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeYellowFootsteps_IsZero()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(6, 6, 6, 2, 2, 2);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(0, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithThreeRedFootsteps_IsZero()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(10, 10, 10, 4, 4, 5); 
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(0, game.Score.BrainsCount);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeGreenShotguns_IsTrue()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 3, 3, 3);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeYellowShotguns_IsTrue()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(6, 6, 6, 2, 2, 2);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeRedShotguns_IsTrue()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(10, 10, 10, 0, 1, 2);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionFinishesWithThreeGreenShotguns_IsTrue()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 3, 3, 3);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionFinishesWithThreeYellowShotguns_IsTrue()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(6, 6, 6, 2, 2, 2);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionFinishesWithThreeRedShotguns_IsTrue()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(10, 10, 10, 0, 1, 2);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionStartsWithThreeMixedShotguns_IsFalse()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(12, 9, 5, 0, 2, 3);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionFinishesWithThreeMixedShotguns_IsTrue()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(12, 9, 5, 0, 2, 3);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void BrainCount_AfterRollActionWithThreeMixedBrains_IsThree()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(12, 9, 5, 3, 0, 2);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(3, game.Score.BrainsCount);
		}

		[TestMethod]
		public void Killed_AfterRollActionWithOneOfEachColorEachWithADifferentSide_IsFalse()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(12, 9, 5, 3, 1, 3);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void BrainCount_AfterRollActionWithOneOfEachColorEachWithADifferentSide_IsOne()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(12, 9, 5, 3, 1, 3);
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(1, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainCount_AfterRollActionWithSantaDoubleBrainGiftAndTwoOtherBrains_IsFour()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 1, 0, 0);
			game.SetupNewGame(new GameSettingsInfo(true, false, false));
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(4, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainCount_AfterRollActionWithSantaDoubleBrainGiftHeroDoubleBrainGreenBrain_IsFive()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 1, 5, 0);
			game.SetupNewGame(new GameSettingsInfo(true, true, false));
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(5, game.Score.BrainsCount);
		}

		[TestMethod]
		public void Killed_AfterRollActionWithSantaHeroHeroineAllWithShotgun_IsFalse()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 5, 2, 4);
			game.SetupNewGame(new GameSettingsInfo(true, true, true));
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void Killed_AfterRollActionWithSantaHeroineWithShotgunAndHeroWithDoubleShotgun_IsFalse()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 5, 4, 4);
			game.SetupNewGame(new GameSettingsInfo(true, true, true));
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(false, game.Score.Killed);
		}

		[TestMethod]
		public void BrainsCount_AfterRollActionWithSantaHeroHeroineAllWithShotgun_IsZero()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 5, 2, 4);
			game.SetupNewGame(new GameSettingsInfo(true, true, true));
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(0, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainCount_AfterRollActionWithSantaHeroineWithShotgunAndHeroWithDoubleShotgun_IsZero()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 5, 4, 4);
			game.SetupNewGame(new GameSettingsInfo(true, true, true));
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(0, game.Score.BrainsCount);
		}

		[TestMethod]
		public void BrainCount_AfterRollActionWithSantaDoubleBrainHeroHeroineFootsteps_IsTwo()
		{
			var randomNumberProviderStub = Substitute.For<IRandomNumberProvider>();
			randomNumberProviderStub.GetRandomNumber(Arg.Any<int>(), Arg.Any<int>()).Returns<int>(0, 0, 0, 1, 0, 0);
			game.SetupNewGame(new GameSettingsInfo(true, true, true));
			game.Hand = new Hand(randomNumberProviderStub);

			game.RollAction();

			Assert.AreEqual(2, game.Score.BrainsCount);
		}
	}
}
