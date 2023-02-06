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
	/// Interaction logic for DiceSelection.xaml
	/// </summary>
	public partial class DiceSelection : UserControl
	{
		public DiceSelection()
		{
			InitializeComponent();

			Binding bindingGreenLeft = new Binding();
			bindingGreenLeft.Source = GameSingleton.Game.Turn;
			bindingGreenLeft.Path = new PropertyPath("GreenLeft");
			GreenCount.SetBinding(TextBlock.TextProperty, bindingGreenLeft);

			Binding bindingYellowLeft = new Binding();
			bindingYellowLeft.Source = GameSingleton.Game.Turn;
			bindingYellowLeft.Path = new PropertyPath("YellowLeft");
			YellowCount.SetBinding(TextBlock.TextProperty, bindingYellowLeft);

			Binding bindingRedCount = new Binding();
			bindingRedCount.Source = GameSingleton.Game.Turn;
			bindingRedCount.Path = new PropertyPath("RedLeft");
			RedCount.SetBinding(TextBlock.TextProperty, bindingRedCount);
		}

		private void ButtonPlus1_Click(object sender, RoutedEventArgs e)
		{
			string buttonName = (e.Source as Button).Name;

			switch (buttonName)
			{
				case "GreenBrainsButton":
					GameSingleton.Game.Turn.BrainsCount++;
					GameSingleton.Game.Turn.GreenLeft--;
					break;
				case "YellowBrainsButton":
					GameSingleton.Game.Turn.BrainsCount++;
					GameSingleton.Game.Turn.YellowLeft--;
					break;
				case "RedBrainsButton":
					GameSingleton.Game.Turn.BrainsCount++;
					GameSingleton.Game.Turn.RedLeft--;
					break;
				case "GreenShotgunButton":
					GameSingleton.Game.Turn.ShotgunCount++;
					GameSingleton.Game.Turn.GreenLeft--;
					break;
				case "YellowShotgunButton":
					GameSingleton.Game.Turn.ShotgunCount++;
					GameSingleton.Game.Turn.YellowLeft--;
					break;
				case "RedShotgunButton":
					GameSingleton.Game.Turn.ShotgunCount++;
					GameSingleton.Game.Turn.RedLeft--;
					break;
				case "GreenFootstepsButton":
					GameSingleton.Game.Turn.FootstepsCount++;
					GameSingleton.Game.Turn.GreenLeft--;
					break;
				case "YellowFootstepsButton":
					GameSingleton.Game.Turn.FootstepsCount++;
					GameSingleton.Game.Turn.YellowLeft--;
					break;
				case "RedFootstepsButton":
					GameSingleton.Game.Turn.FootstepsCount++;
					GameSingleton.Game.Turn.RedLeft--;
					break;
			}
		}
	}
}
