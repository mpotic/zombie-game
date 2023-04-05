using Back.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.UnitTests.ScenarioTests
{
	public class TestRandomNumberProvider : IRandomNumberProvider
	{
		public Queue<int> RandomNumberQueue { get; set; }

		public TestRandomNumberProvider(List<int> predefinedRandomNumbers)
		{
			this.RandomNumberQueue = new Queue<int>(predefinedRandomNumbers);
		}

		public int GetRandomNumber(int start, int end)
		{
			return RandomNumberQueue.Dequeue();
		}

		public void Reset()
		{
			return;
		}
	}
}
