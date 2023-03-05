using Back.Game;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
			brainsBinding.Source = GameSingleton.instance.Game.ScoreDecorator;
			brainsBinding.Path = new PropertyPath("BrainsCount");
			BrainsTextBlock.SetBinding(TextBlock.TextProperty, brainsBinding);

			Binding shotgunBinding = new Binding();
			shotgunBinding.Source = GameSingleton.instance.Game.ScoreDecorator;
			shotgunBinding.Path = new PropertyPath("ShotgunCount");
			ShotgunsTextBlock.SetBinding(TextBlock.TextProperty, shotgunBinding);

			Binding footstepsBinding = new Binding();
			footstepsBinding.Source = GameSingleton.instance.Game.ScoreDecorator;
			footstepsBinding.Path = new PropertyPath("FootstepsCount");
			FootstepsTextBlock.SetBinding(TextBlock.TextProperty, footstepsBinding);

		}
	}
}
