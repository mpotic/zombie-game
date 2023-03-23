using Back.Dice;
using Back.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace Back.UnitTests.HandTests
{
	[TestClass]
	public class HandUnitTests
	{
		HandTestsHelper helper = new HandTestsHelper();

		[TestMethod]
		public void GrabbedDice_OnCreation_ReturnsEmptyList()
		{
			//Arrange
			IHand hand = new Hand();

			//Act
			var actual = hand.GrabbedDice;

			//Assert
			Assert.IsNotNull(actual);
			Assert.AreEqual(0, actual.Count);
		}

		[TestMethod]
		public void GrabbedDice_OnGrabAndRollDice_HasThreeDice()
		{
			//Arrange
			IGame gameSub = Substitute.For<IGame>();
			gameSub.Hand = new Hand();
			gameSub.Bag = new Bag();
			Hand hand = (Hand)gameSub.Hand;

			//Act
			hand.GrabAndRollDice();
			var actual = hand.GrabbedDice;

			//Assert
			Assert.AreEqual(3, actual.Count);
		}

		[TestMethod]
		public void GrabbedDice_OnGrabAndRollOnlyGreenDice_HasThreeGreenDice()
		{
			//Arrange
			IGame gameStub = helper.InitGameStub();
			gameStub.Bag.Dice = new List<IDice>() 
			{ 
				new GreenDice(), 
				new GreenDice(), 
				new GreenDice() 
			};
			Hand hand = (Hand)gameStub.Hand;

			//Act
			hand.GrabAndRollDice();
			var actual = hand.GrabbedDice;

			//Assert
			Assert.AreEqual(typeof(GreenDice).Name, actual[0].GetType().Name);
			Assert.AreEqual(typeof(GreenDice).Name, actual[1].GetType().Name);
			Assert.AreEqual(typeof(GreenDice).Name, actual[2].GetType().Name);
		}

		/// <summary>
		/// If the there is only one GreenDice with footsteps check if it is saved in Hands GrabbedDice list after calling GrabPreviousTurnFootsteps.
		/// </summary>
		[TestMethod]
		public void GrabbedDice_OnGrabPreviousTurnFootsteps_ContainsOneGreenDiceFootsteps()
		{
			//Arrange
			IGame gameStub = helper.InitGameStub();
			gameStub.ScoreDecorator.ScoreComponent.AllRolledDice.Add(new GreenDice() { Side = DiceSide.FOOTSTEPS});
			PrivateObject hand = new PrivateObject(gameStub.Hand);
			
			//Act
			hand.Invoke("GrabPreviousTurnFootsteps");

			//Assert
			List<IDice> grabbedDiceFromHand = (List<IDice>)hand.GetProperty("GrabbedDice");
			Assert.AreEqual(1, grabbedDiceFromHand.Count);
			Assert.AreEqual(typeof(GreenDice).Name, grabbedDiceFromHand[0].GetType().Name);
			Assert.AreEqual(DiceSide.FOOTSTEPS, grabbedDiceFromHand[0].Side);
		}
	}
}
