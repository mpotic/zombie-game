using Back.Game;
using Back.Options;
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
using ZombieGame.Callback;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for Options.xaml
	/// </summary>
	public partial class Options : UserControl
	{
		public Options()
		{
			InitializeComponent();
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.Options.ResetAction();
		}

		private void RollButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.Options.RollAction(new PlayerCallback());
		}

		private void StopButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.Options.StopAction(new PlayerCallback());
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.Options.StartAction(new PlayerCallback());
		}
	}
}
