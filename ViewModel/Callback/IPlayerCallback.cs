namespace ViewModel.Callback
{
	public interface IPlayerCallback: IFrontCallback
	{
		void ChangeActivePlayer(int current);
	}
}
