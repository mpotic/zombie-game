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
			bindingGreenLeft.Source = GameSingleton.Game.Score;
			bindingGreenLeft.Path = new PropertyPath("GreenLeft");
			GreenCount.SetBinding(TextBlock.TextProperty, bindingGreenLeft);

			Binding bindingYellowLeft = new Binding();
			bindingYellowLeft.Source = GameSingleton.Game.Score;
			bindingYellowLeft.Path = new PropertyPath("YellowLeft");
			YellowCount.SetBinding(TextBlock.TextProperty, bindingYellowLeft);

			Binding bindingRedCount = new Binding();
			bindingRedCount.Source = GameSingleton.Game.Score;
			bindingRedCount.Path = new PropertyPath("RedLeft");
			RedCount.SetBinding(TextBlock.TextProperty, bindingRedCount);
		}

		private void ButtonPlus1_Click(object sender, RoutedEventArgs e)
		{
			string buttonName = (e.Source as Button).Name;

			switch (buttonName)
			{
				//case "GreenBrainsButton":
				//	GameSingleton.Game.Score.BrainsCount++;
				//	GameSingleton.Game.Score.GreenLeft--;
				//	break;
				//case "YellowBrainsButton":
				//	GameSingleton.Game.Score.BrainsCount++;
				//	GameSingleton.Game.Score.YellowLeft--;
				//	break;
				//case "RedBrainsButton":
				//	GameSingleton.Game.Score.BrainsCount++;
				//	GameSingleton.Game.Score.RedLeft--;
				//	break;
				//case "GreenShotgunButton":
				//	GameSingleton.Game.Score.ShotgunCount++;
				//	GameSingleton.Game.Score.GreenLeft--;
				//	break;
				//case "YellowShotgunButton":
				//	GameSingleton.Game.Score.ShotgunCount++;
				//	GameSingleton.Game.Score.YellowLeft--;
				//	break;
				//case "RedShotgunButton":
				//	GameSingleton.Game.Score.ShotgunCount++;
				//	GameSingleton.Game.Score.RedLeft--;
				//	break;
				//case "GreenFootstepsButton":
				//	GameSingleton.Game.Score.FootstepsCount++;
				//	GameSingleton.Game.Score.GreenLeft--;
				//	break;
				//case "YellowFootstepsButton":
				//	GameSingleton.Game.Score.FootstepsCount++;
				//	GameSingleton.Game.Score.YellowLeft--;
				//	break;
				//case "RedFootstepsButton":
				//	GameSingleton.Game.Score.FootstepsCount++;
				//	GameSingleton.Game.Score.RedLeft--;
				//	break;
			}
		}
	}
}
