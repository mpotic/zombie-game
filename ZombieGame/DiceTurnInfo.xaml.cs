using Back.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
			RemainingGreen.DataContext = GameSingleton.Game.Dice.GreenDice;
			RemainingYellow.DataContext = GameSingleton.Game.Dice.YellowDice;
			RemainingRed.DataContext = GameSingleton.Game.Dice.RedDice;
		}
	}
}
