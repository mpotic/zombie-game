namespace Back.Dice
{
	public enum DiceSide { SHOTGUN = 0, FOOTSTEPS, BRAIN};
	public interface IDice
	{
		DiceSide Side { get; set; }
		int FootstepCount { get; set; }
		int Remaining { get; set; }
		void Roll();
	}
}
