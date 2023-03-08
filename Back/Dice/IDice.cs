namespace Back.Dice
{
	public enum DiceSide { BRAIN = 0, FOOTSTEPS, SHOTGUN, DOUBLE_BRAIN_GIFT, ENERGY_DRINK, HELMET};

	public interface IDice
	{
		DiceSide Side { get; set; }

		string DiceType { get; }

		void Roll();
	}
}
