using Back.Dice;
using Back.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Back.UnitTests.BagTests
{
	/// <summary>
	/// Summary description for BagUnitTests
	/// </summary>
	[TestClass]
	public class BagUnitTests
	{
		private Bag bag;
		
		private IGame game;

		private TestInitHelper testInitHelper = new TestInitHelper();

		[TestInitialize()]
		public void BagUnitTestsInitialize() 
		{
			game = testInitHelper.InitGameStub();
			bag = (Bag)game.Bag;
		}

		#region Properties testing

		[TestMethod]
		public void Dice_OnCreation_ReturnsListWithThirteenElements()
		{
			var diceList = bag.Dice;

			Assert.IsNotNull(diceList);
			Assert.AreEqual(13, diceList.Count);
		}

		[TestMethod]
		public void UsedSanta_OnCreation_IsFalse()
		{
			PrivateObject privateBag = new PrivateObject(bag);
			
			var usedSanta = privateBag.GetField("usedSanta");

			Assert.AreEqual(false, usedSanta);
		}

		[TestMethod]
		public void GreenCount_OnCreation_ReturnsSix()
		{
			var greenCount = bag.GreenCount;

			Assert.AreEqual(6, greenCount);
		}

		[TestMethod]
		public void YellowCount_OnCreation_ReturnsFour()
		{
			var yellowCount = bag.YellowCount;

			Assert.AreEqual(4, yellowCount);
		}

		[TestMethod]
		public void RedCount_OnCreation_ReturnsThree()
		{
			var redCount = bag.RedCount;

			Assert.AreEqual(3, redCount);
		}

		[TestMethod]
		public void SantaCount_OnCreation_ReturnsZero()
		{
			var santaCount = bag.SantaCount;

			Assert.AreEqual(0, santaCount);
		}

		[TestMethod]
		public void SantaCount_OnResetBagIfSantaIncluded_ReturnsOne()
		{
			game.GameSettings.IncludedSanta = true;
			bag.ResetBag(game.GameSettings);

			var santaCount = bag.SantaCount;

			Assert.AreEqual(1, santaCount);
		}

		[TestMethod]
		public void HeroCount_OnCreation_ReturnsZero()
		{
			var heroCount = bag.HeroCount;

			Assert.AreEqual(0, heroCount);
		}

		[TestMethod]
		public void HeroCount_OnResetBagIfHeroIncluded_ReturnsOne()
		{
			game.GameSettings.IncludedHero = true;
			bag.ResetBag(game.GameSettings);

			var heroCount = bag.HeroCount;

			Assert.AreEqual(1, heroCount);
		}


		[TestMethod]
		public void HeroineCount_OnCreation_ReturnsZero()
		{
			var heroineCount = bag.HeroineCount;

			Assert.AreEqual(0, heroineCount);
		}

		[TestMethod]
		public void HeroineCount_OnResetBagIfHeroineIncluded_ReturnsOne()
		{
			game.GameSettings.IncludedHeroine = true;
			bag.ResetBag(game.GameSettings);

			var heroineCount = bag.HeroineCount;

			Assert.AreEqual(1, heroineCount);
		}

		#endregion

		#region Methods testing

		[TestMethod]
		public void GrabDice_OnCallAfterInitWithCountSetToThree_ReturnsListWithThreeDice()
		{
			int count = 3;
			IGameSettings gameSettings = game.GameSettings;
			IRandomNumberProvider randomNumberProvider = new RandomNumberProvider();

			var diceList = bag.GrabDice(count, gameSettings, randomNumberProvider);

			Assert.AreEqual(3, diceList.Count);	
			Assert.IsInstanceOfType(diceList[0], typeof(IDice));
		}

		[TestMethod]
		public void GrabDice_WhenDiceEmptyWithCountSetToThree_ReturnsListWithThreeDice()
		{
			bag.Dice.Clear(); 
			int count = 3;
			IGameSettings gameSettings = game.GameSettings;
			IRandomNumberProvider randomNumberProvider = new RandomNumberProvider();

			var diceList = bag.GrabDice(count, gameSettings, randomNumberProvider);

			Assert.AreEqual(3, diceList.Count);
			Assert.IsInstanceOfType(diceList[0], typeof(IDice));
		}

		[TestMethod]
		public void GrabDice_WithDiceListHasFiveDiceWithCountSetToThree_DiceHasTwoElements()
		{
			bag.Dice.Clear();
			bag.Dice.Add(new GreenDice());
			bag.Dice.Add(new GreenDice());
			bag.Dice.Add(new RedDice());
			bag.Dice.Add(new GreenDice());
			bag.Dice.Add(new YellowDice());

			int count = 3;
			IGameSettings gameSettings = game.GameSettings;
			IRandomNumberProvider randomNumberProvider = new RandomNumberProvider();

			bag.GrabDice(count, gameSettings, randomNumberProvider);
			var diceList = bag.Dice;

			Assert.AreEqual(2, diceList.Count);
		}

		[TestMethod]
		public void ResetBag_AfterResetWithNoExtraDice_DiceCountIsThirteen()
		{
			bag.ResetBag(game.GameSettings);
			int totalCount = bag.TotalCount;

			Assert.AreEqual(13, totalCount);
		}

		[TestMethod]
		public void ResetBag_AfterResetWithSantaHeroHeroineIncluded_DiceCountIsThirteen()
		{
			game.GameSettings.IncludedSanta = true;
			game.GameSettings.IncludedHero = true;
			game.GameSettings.IncludedHeroine = true;

			bag.ResetBag(game.GameSettings);
			int totalCount = bag.TotalCount;

			Assert.AreEqual(13, totalCount);
		}

		[TestMethod]
		public void ResetBag_AfterResetWithNoExtraDice_SantaCountIsZero()
		{
			bag.ResetBag(game.GameSettings);
			int santaCount = bag.SantaCount;

			Assert.AreEqual(0, santaCount);
		}

		[TestMethod]
		public void ResetBag_AfterResetWithNoExtraDice_HeroCountIsZero()
		{
			bag.ResetBag(game.GameSettings);
			int heroCount = bag.HeroCount;

			Assert.AreEqual(0, heroCount);
		}

		[TestMethod]
		public void ResetBag_AfterResetWithNoExtraDice_HeroineCountIsZero()
		{
			bag.ResetBag(game.GameSettings);
			int heroineCount = bag.HeroineCount;

			Assert.AreEqual(0, heroineCount);
		}

		[TestMethod]
		public void ResetBag_IncludedSanta_SantaCountIsOne()
		{
			game.GameSettings.IncludedSanta = true;

			bag.ResetBag(game.GameSettings);
			int santaCount = bag.SantaCount;

			Assert.AreEqual(1, santaCount);
		}

		[TestMethod]
		public void ResetBag_IncludedHero_HeroCountIsOne()
		{
			game.GameSettings.IncludedHero = true;

			bag.ResetBag(game.GameSettings);
			int heroCount = bag.HeroCount;

			Assert.AreEqual(1, heroCount);
		}

		[TestMethod]
		public void ResetBag_IncludedHeroine_HeroineCountIsOne()
		{
			game.GameSettings.IncludedHeroine = true;

			bag.ResetBag(game.GameSettings);
			int heroineCount = bag.HeroineCount;

			Assert.AreEqual(1, heroineCount);
		}

		[TestMethod]
		public void ResetBag_IncludedSantaHeroHeroine_HeroHeroineSantaCountIsOne()
		{
			game.GameSettings.IncludedSanta = true;
			game.GameSettings.IncludedHero = true;
			game.GameSettings.IncludedHeroine = true;

			bag.ResetBag(game.GameSettings);
			int santaCount = bag.SantaCount;
			int heroCount = bag.HeroCount;
			int heroineCount = bag.HeroineCount;

			Assert.AreEqual(1, santaCount);
			Assert.AreEqual(1, heroCount);
			Assert.AreEqual(1, heroineCount);
		}

		[TestMethod]
		public void ResetBag_IncludedSantaHeroHeroine_GreenCountFiveYellowCountTwoRedCountThree()
		{
			game.GameSettings.IncludedSanta = true;
			game.GameSettings.IncludedHero = true;
			game.GameSettings.IncludedHeroine = true;

			bag.ResetBag(game.GameSettings);
			int greenCount = bag.GreenCount;
			int yellowCount = bag.YellowCount;
			int redCount = bag.RedCount;

			Assert.AreEqual(5, greenCount);
			Assert.AreEqual(2, yellowCount);
			Assert.AreEqual(3, redCount);
		}

		[TestMethod]
		public void ReturnDice_AfterCreation_DiceCountFourteen()
		{
			bag.ReturnDice(new GreenDice());

			Assert.AreEqual(14, bag.Dice.Count);
		}

		[TestMethod]
		public void ReturnDice_IfDiceListIsEmpty_DiceCountOne()
		{
			bag.Dice.Clear();

			bag.ReturnDice(new GreenDice());

			Assert.AreEqual(1, bag.Dice.Count);
		}

		#endregion

		/*
ResetBag_OnCall_usedSantaIsFalse
ResetBag_OnCall_DiceHasThirteenDice

CheckAndRefill_OnCallAfterInit_DiceHasThirteenElements
CheckAndRefill_OnCallIfDiceHasZeroElements_DiceHasThirteenElements
CheckAndRefill_OnCallIfDiceHasThreeElements_DiceHasZeroElements
		 */
	}
}
