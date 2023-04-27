using Common.DTO;

namespace Back.Game
{
	public interface IGameSettings
	{
		bool IncludedSanta { get; set; }

		bool IncludedHero { get; set; }
		
		bool IncludedHeroine { get; set; }

		bool IncludedBuss { get; set; }

		void Configure(IGameSettingsInfo gameSettingsInfo);
	}
}
