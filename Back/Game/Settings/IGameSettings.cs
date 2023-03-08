namespace Back.Game
{
	public interface IGameSettings
	{
		bool IncludedSanta { get; set; }

		bool IncludedHero { get; set; }
		
		bool IncludedHeroine { get; set; }

		void Configure(bool includeSanta, bool includeHero, bool includeHeroine);
	}
}
