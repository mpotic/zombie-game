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
	/// Interaction logic for ScorePanel.xaml
	/// </summary>
	public partial class TurnPanel : UserControl
	{
		public TurnPanel()
		{
			InitializeComponent();

			Binding brainsBinding = new Binding();
			brainsBinding.Source = GameSingleton.Game.Score;
			brainsBinding.Path = new PropertyPath("BrainsCount");
			BrainsTextBlock.SetBinding(TextBlock.TextProperty, brainsBinding);

			Binding shotgunBinding = new Binding();
			shotgunBinding.Source = GameSingleton.Game.Score;
			shotgunBinding.Path = new PropertyPath("ShotgunCount");
			ShotgunsTextBlock.SetBinding(TextBlock.TextProperty, shotgunBinding);

			Binding footstepsBinding = new Binding();
			footstepsBinding.Source = GameSingleton.Game.Score;
			footstepsBinding.Path = new PropertyPath("FootstepsCount");
			FootstepsTextBlock.SetBinding(TextBlock.TextProperty, footstepsBinding);

		}
	}
}
