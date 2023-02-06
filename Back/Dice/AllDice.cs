using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
	public class AllDice
	{
		private  GreenDice greenDice;
		private YellowDice yellowDice;
		private RedDice redDice;

		public AllDice() { }

		public GreenDice GreenDice { get => greenDice; set => greenDice = value; }
		public YellowDice YellowDice { get => yellowDice; set => yellowDice = value; }
		public RedDice RedDice { get => redDice; set => redDice = value; }

		public void ThrowDice()
		{

		}
	}
}
