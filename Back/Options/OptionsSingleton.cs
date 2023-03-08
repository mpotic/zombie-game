namespace Back.Options
{
	public class OptionsSingleton : IOptionsSingleton
	{
		private static IOptions options = null;
		private OptionsSingleton() { }
		public static IOptions Options
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
