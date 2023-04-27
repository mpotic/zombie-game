namespace Back.Dice
{
	public interface IRandomNumberProvider
	{
		/// <summary>
		/// Returns a random integer from the range including start, but excluding end.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		int GetRandomNumber(int start, int end);

		void Reset();
	}
}
