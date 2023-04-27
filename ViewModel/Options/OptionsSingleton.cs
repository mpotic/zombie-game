namespace ViewModel.Options
{
	public class OptionsSingleton : IOptionsSingleton
	{
		public static readonly IOptionsSingleton instance = new OptionsSingleton();

		private OptionsSingleton() 
		{
			this.Options = new Options();
		}

		public IOptions Options { get; set; }
	}
}
