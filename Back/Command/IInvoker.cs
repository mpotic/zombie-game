namespace Back.Command
{
	public interface IInvoker
	{
		void SetCommand(ICommand command);
		void ExecuteCommand();
		void ExecuteCommand(ICommand executeCommand);
	}
}
