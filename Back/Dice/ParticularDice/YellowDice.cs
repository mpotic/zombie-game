namespace Back.Dice
{
	public class YellowDice : IDice
	{
		private DiceSide side;

		public DiceSide Side { get => side; set => side = value; }

		public string DiceType
		{
			get
			{
				return this.GetType().Name;
			}
		}

		public void Roll(IRandomNumberProvider randomNumberProvider)
		{
			int randomInt = randomNumberProvider.GetRandomNumber(0, 3);
			side = (DiceSide)randomInt;
		}
	}
}
