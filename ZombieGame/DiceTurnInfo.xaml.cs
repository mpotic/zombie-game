using Back.Game;
using System.Windows.Controls;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for DiceTurnInfo.xaml
	/// </summary>
	public partial class DiceTurnInfo : UserControl
	{
		public DiceTurnInfo()
		{
			InitializeComponent();
			RemainingGreen.DataContext = GameSingleton.instance.Game.Dice.GreenDice;
			RemainingYellow.DataContext = GameSingleton.instance.Game.Dice.YellowDice;
			RemainingRed.DataContext = GameSingleton.instance.Game.Dice.RedDice;
		}
	}
}
