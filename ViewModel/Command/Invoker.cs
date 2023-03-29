namespace ViewModel.Command
{
	public class Invoker : IInvoker
	{
		public ICommand Command { get; set; }


		public void ExecuteCommand(ICommand executeCommand)
		{
			executeCommand.Execute();
		}
	}
}
