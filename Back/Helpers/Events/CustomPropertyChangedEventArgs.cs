using System.ComponentModel;

namespace Back.Helpers.Events
{
	public class CustomPropertyChangedEventArgs : PropertyChangedEventArgs
	{
		public CustomEnumPropertyChangedEventArgs CustomArgs { get; set; }

		public CustomPropertyChangedEventArgs(string propertyName, CustomEnumPropertyChangedEventArgs customArgs) : base(propertyName)
		{
			CustomArgs = customArgs; 
		}
	}
}
