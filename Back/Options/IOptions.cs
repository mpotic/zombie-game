using Back.Callback;

namespace Back.Options
{
	public interface IOptions
	{
		void AddNewPlayer(string name, IPlayerCallback playerCallback);
		void StopAction(IPlayerCallback playerCallback);
		void RollAction(IPlayerCallback playerCallback);
		void ResetAction();
	}
}
