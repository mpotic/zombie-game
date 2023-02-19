using Back.Callback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Options
{
	public interface IOptions
	{
		void AddNewPlayer(string name, IPlayerCallback playerCallback);
		void StopAction(IPlayerCallback playerCallback);
		void RollAction(IPlayerCallback playerCallback);
	}
}
