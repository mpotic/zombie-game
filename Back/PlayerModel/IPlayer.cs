using Back.PlayerModel.Visitor;

namespace Back.PlayerModel
{
	public interface IPlayer
	{
		int TotalBrainCount { get; set; }
		string Name { get; set; }
		void Accept(IPlayerVisitor visitor);
	}
}
