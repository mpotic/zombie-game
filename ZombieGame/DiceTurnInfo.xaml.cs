using System.Windows.Controls;
using ViewModel;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for DiceTurnInfo.xaml
	/// </summary>
	public partial class DiceTurnInfo : UserControl
	{
		private IDiceTurnInfoViewModel diceTurnInfoViewModel = new DiceTurnInfoViewModel();

		public IDiceTurnInfoViewModel DiceTurnInfoViewModel { get => diceTurnInfoViewModel; set => diceTurnInfoViewModel = value; }

		public DiceTurnInfo()
		{
			InitializeComponent();
		}
	}
}
