using Back.Callback;

namespace Back.Options
{
	public interface IOptions
	{
		void AddNewPlayer(string name, IPlayerCallback playerCallback);

		void RollAction(IPlayerCallback playerCallback);

		void StopAction(IPlayerCallback playerCallback);
		
		void ResetAction();

		void StartAction(IPlayerCallback playerCallback);

		void SetupNewGameAction(bool includeSanta, bool includeHero, bool includeHeroine, IPlayerCallback playerCallback);
	}
}
