namespace ViewModel.Command
{
	public interface IInvoker
	{
		void ExecuteCommand(ICommand executeCommand);
	}
}
