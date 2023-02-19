using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
