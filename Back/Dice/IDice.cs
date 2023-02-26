namespace Back.Dice
{
	public enum DiceSide { SHOTGUN = 0, FOOTSTEPS, BRAIN};
	public interface IDice
	{
		DiceSide Side { get; set; }

		string DiceType { get; }

		void Roll();
	}
}
