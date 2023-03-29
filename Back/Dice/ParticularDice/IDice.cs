namespace Back.Dice
{
	public interface IDice
	{
		DiceSide Side { get; set; }

		string DiceType { get; }

		void Roll(IRandomNumberProvider randomNumberProvider);
	}
}
