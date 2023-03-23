using Back.Dice;
using Back.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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

		[TestInitialize()]
		public void MyTestInitialize() 
		{
			BagTestsHelper helper = new BagTestsHelper();
			game = helper.InitGameStub();
			bag = new Bag(game);
			game.Bag = bag;
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
			bag.ResetBag();

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
			bag.ResetBag();

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
			bag.ResetBag();

			var heroineCount = bag.HeroineCount;

			Assert.AreEqual(1, heroineCount);
		}

		#endregion

		#region Methods testing

		[TestMethod]
		public void GrabDice_OnCallAfterInitWithParamThree_ReturnsListWithThreeIDice()
		{
			var diceList = bag.GrabDice(3);

			Assert.AreEqual(3, diceList.Count);	
			Assert.IsInstanceOfType(diceList[0], typeof(IDice));
		}

		[TestMethod]
		public void GrabDice_WhenDiceEmptyWithThree_ReturnsListWithThreeIDice()
		{
			bag.Dice.Clear();

			var diceList = bag.GrabDice(3);

			Assert.AreEqual(3, diceList.Count);
			Assert.IsInstanceOfType(diceList[0], typeof(IDice));
		}

		[TestMethod]
		public void GrabDice_WithThreeWhenDiceHasFiveElements_DiceHasTwoElements()
		{
			bag.Dice.Clear();
			bag.Dice.Add(new GreenDice());
			bag.Dice.Add(new GreenDice());
			bag.Dice.Add(new RedDice());
			bag.Dice.Add(new GreenDice());
			bag.Dice.Add(new YellowDice());

			bag.GrabDice(3);
			var diceList = bag.Dice;

			Assert.AreEqual(2, diceList.Count);
		}

		[TestMethod]
		public void FillBag_AfterInit_DiceContainsThirteenElements()
		{
			bag.FillBag();

			var diceList = bag.Dice;

			Assert.AreEqual(13, diceList.Count);
		}

		[TestMethod]
		public void FillBag_WhenDiceEmpty_DiceContainsThirteenElements()
		{
			bag.Dice.Clear();

			bag.FillBag();
			var diceList = bag.Dice;

			Assert.AreEqual(13, bag.Dice.Count);
		}

		[TestMethod]
		public void FillBag_WhenIncludedSantaAndNotUsedSanta_DiceContainsSanta()
		{
			game.GameSettings.IncludedSanta = true;

			bag.FillBag();
			var diceList = bag.Dice;

			Assert.AreEqual(13, diceList.Count);
			Assert.AreEqual(1, diceList.OfType<SantaDice>().Count<SantaDice>());
		}

		[TestMethod]
		public void FillBag_WhenIncludedSantaAndUsedSanta_DiceContainsSanta()
		{
			game.GameSettings.IncludedSanta = true;
			PrivateObject privateBag = new PrivateObject(bag);
			privateBag.SetField("usedSanta", true);
			
			bag.FillBag();
			var diceList = bag.Dice;

			Assert.AreEqual(12, diceList.Count);
			Assert.AreEqual(0, diceList.OfType<SantaDice>().Count<SantaDice>());
		}

		[TestMethod]
		public void FillBag_WhenIncludedHero_DiceContainsHeroDice()
		{
			game.GameSettings.IncludedHero = true;

			bag.FillBag();
			var diceList = bag.Dice;

			Assert.AreEqual(13, diceList.Count);
			Assert.AreEqual(1, diceList.OfType<HeroDice>().Count<HeroDice>());
		}

		[TestMethod]
		public void FillBag_WhenIncludedHeroine_DiceContainsHeroine()
		{
			game.GameSettings.IncludedHeroine = true;

			bag.FillBag();
			var diceList = bag.Dice;

			Assert.AreEqual(13, diceList.Count);
			Assert.AreEqual(1, diceList.OfType<HeroineDice>().Count<HeroineDice>());
		}

		[TestMethod]
		public void FillBag_WhenIncludedSantaHeroHeroine_DiceContainsSantaHeroHeroine()
		{
			game.GameSettings.IncludedSanta = true;
			game.GameSettings.IncludedHero = true;
			game.GameSettings.IncludedHeroine = true;

			bag.FillBag();
			var diceList = bag.Dice;

			Assert.AreEqual(13, diceList.Count);
			Assert.AreEqual(1, diceList.OfType<SantaDice>().Count<SantaDice>());
			Assert.AreEqual(1, diceList.OfType<HeroDice>().Count<HeroDice>());
			Assert.AreEqual(1, diceList.OfType<HeroineDice>().Count<HeroineDice>());
		}

		[TestMethod]
		public void FillBag_WhenIncludedSantaHeroHeroineAndUsedSanta_DiceContainsHeroHeroine()
		{
			game.GameSettings.IncludedSanta = true;
			game.GameSettings.IncludedHero = true;
			game.GameSettings.IncludedHeroine = true;
			PrivateObject privateBag = new PrivateObject(bag);
			privateBag.SetField("usedSanta", true);

			bag.FillBag();
			var diceList = bag.Dice;

			Assert.AreEqual(12, diceList.Count);
			Assert.AreEqual(0, diceList.OfType<SantaDice>().Count<SantaDice>());
			Assert.AreEqual(1, diceList.OfType<HeroDice>().Count<HeroDice>());
			Assert.AreEqual(1, diceList.OfType<HeroineDice>().Count<HeroineDice>());
		}

		[TestMethod]
		public void ResetBag_AfterCreation_UsedSantaIsFalse()
		{
			PrivateObject privateBag = new PrivateObject(bag);

			bag.ResetBag();
			var usedSanta = privateBag.GetField("usedSanta");

			Assert.AreEqual(false, usedSanta);
		}

		[TestMethod]
		public void ResetBag_IncludedSanta_UsedSantaIsTrue()
		{
			game.GameSettings.IncludedSanta = true;
			PrivateObject privateBag = new PrivateObject(bag);

			bag.ResetBag();
			var usedSanta = privateBag.GetField("usedSanta");

			Assert.AreEqual(true, usedSanta);
		}

		[TestMethod]
		public void CheckAndRefill_AfterCreation_DiceCountIsThirteen()
		{
			bag.CheckAndRefill();
			var diceList = bag.Dice;

			Assert.AreEqual(13, diceList.Count);
		}
		
		[TestMethod]
		public void CheckAndRefill_WhenDiceCountIsThree_DiceCountIsThree()
		{
			bag.Dice.Clear();
			bag.Dice.Add(new GreenDice());
			bag.Dice.Add(new YellowDice());
			bag.Dice.Add(new RedDice());

			bag.CheckAndRefill();
			var diceList = bag.Dice;

			Assert.AreEqual(3, diceList.Count);
		}

		[TestMethod]
		public void ReturnDice_AfterCreation_DiceCountFourteen()
		{
			bag.ReturnDice(new GreenDice());

			Assert.AreEqual(14, bag.Dice.Count);
		}

		[TestMethod]
		public void ReturnDice_IfDiceEmpty_DiceCountOne()
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
