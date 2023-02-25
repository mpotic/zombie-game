using System;

namespace Back.Command
{
	public class Invoker : IInvoker
	{
		private ICommand command;

		public ICommand Command { get => command; set => command = value; }

		public void ExecuteCommand()
		{
			throw new NotImplementedException();
		}

		public void SetCommand(ICommand command)
		{
			command.Execute();
		}

		public void ExecuteCommand(ICommand executeCommand)
		{
			executeCommand.Execute();
		}
	}
}
