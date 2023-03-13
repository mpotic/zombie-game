namespace ViewModel
{
	public interface IDiceTurnInfoViewModel
	{
		int GreenDiceCount { get; set; }
		
		int YellowDiceCount { get; set; }

		int RedDiceCount { get; set; }

		int SantaDiceCount { get; set; }

		int HeroDiceCount { get; set; }

		int HeroineDiceCount { get; set; }

		bool IncludedSanta { get; set; }

		bool IncludedHero { get; set; }

		bool IncludedHeroine { get; set; }
	}
}
