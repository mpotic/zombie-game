namespace Back.Game
{
	public interface IScoreDecorator : IScore
	{
		IScore ScoreComponent { get; }
		void SetScoreComponent(IScore score);
	}
}
