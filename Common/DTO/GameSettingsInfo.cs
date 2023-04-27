namespace Common.DTO
{
	public class GameSettingsInfo : IGameSettingsInfo
	{
		public GameSettingsInfo(bool useSanta, bool useHero, bool useHeroine)
		{
			UseSanta = useSanta;
			UseHero = useHero;
			UseHeroine = useHeroine;
		}

		public bool UseSanta { get; set; }
		
		public bool UseHero { get; set; }

		public bool UseHeroine { get; set; }
	}
}
