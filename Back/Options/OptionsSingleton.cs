using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Options
{
	public class OptionsSingleton : IOptionsSingleton
	{
		private static Options options = null;
		private OptionsSingleton() { }
		public static Options Options
		{
			get
			{
				if (options == null)
					options = new Options();

				return options;
			}
		}
	}
}
