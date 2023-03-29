using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dice
{
	public interface IRandomNumberProvider
	{
		int GetRandomNumber(int start, int end);

		void Reset();
	}
}
