namespace ViewModel.Options
{
	public interface IOptions
	{
		void AddNewPlayer(string name);

		void RollAction();

		void StopAction();
		
		void ResetAction();

		void StartAction();

		void SetupNewGameAction(bool includeSanta, bool includeHero, bool includeHeroine);
	}
}
