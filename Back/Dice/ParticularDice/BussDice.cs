using System.Collections.Generic;

namespace Back.Dice
{
	public class BussDice : IDice
	{
		private Dictionary<int, DiceSide> RandomNumberDiceSideMapper = new Dictionary<int, DiceSide>();

		public BussDice()
		{
			RandomNumberDiceSideMapper.Add(0, DiceSide.BRAIN);
			RandomNumberDiceSideMapper.Add(1, DiceSide.SHOTGUN);
			RandomNumberDiceSideMapper.Add(2, DiceSide.DOUBLE_BRAIN_ONE_SHOTGUN);
			RandomNumberDiceSideMapper.Add(3, DiceSide.STOP);
			RandomNumberDiceSideMapper.Add(4, DiceSide.YIELD);
			RandomNumberDiceSideMapper.Add(5, DiceSide.RUN_OVER);
			RandomNumberDiceSideMapper.Add(6, DiceSide.DEAD_END);
		}

		public DiceSide Side { get; set; }

		public string DiceType => this.GetType().Name;

		public void Roll(IRandomNumberProvider randomNumberProvider)
		{
			int randomValue = randomNumberProvider.GetRandomNumber(0, 7);
			Side = RandomNumberDiceSideMapper[randomValue];
		}
	}
}
