namespace Back.Dice
{
	public enum DiceSide { SHOTGUN = 0, FOOTSTEPS, BRAIN, DOUBLE_BRAIN_GIFT, ENERGY_DRINK, HELMET};

	public interface IDice
	{
		DiceSide Side { get; set; }

		string DiceType { get; }

		void Roll();
	}
}
