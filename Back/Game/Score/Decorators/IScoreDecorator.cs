namespace Back.Game
{
	public interface IScoreDecorator : IScore
	{
		IScore ScoreComponent { get; set; }

		void SetScoreComponent(IScore score);
	}
}
