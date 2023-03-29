namespace ViewModel
{
	public interface IDiceTurnInfoViewModel
	{
		int GreenDiceCount { get; }
		
		int YellowDiceCount { get; }

		int RedDiceCount { get; }

		int SantaDiceCount { get; }

		int HeroDiceCount { get; }

		int HeroineDiceCount { get; }

		bool IncludedSanta { get; }

		bool IncludedHero { get; }

		bool IncludedHeroine { get; }
	}
}
