using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dice
{
	public class RandomNumberProvider : IRandomNumberProvider
	{
		private Random random;

		public RandomNumberProvider()
		{
			random = new Random();
		}

		public int GetRandomNumber(int start, int end)
		{
			return random.Next(start, end);
		}

		public void Reset()
		{
			random = new Random();
		}
	}
}
