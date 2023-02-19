using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Command
{
	public interface IInvoker
	{
		void SetCommand(ICommand command);
		void ExecuteCommand();
		void ExecuteCommand(ICommand executeCommand);
	}
}
