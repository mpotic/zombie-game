﻿using ViewModel.Options;
using System.Windows;
using System.Windows.Controls;

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
			OptionsSingleton.Options.RollAction();
		}

		private void StopButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.Options.StopAction();
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			OptionsSingleton.Options.StartAction();
		}

		private void NewGameButton_Click(object sender, RoutedEventArgs e)
		{
			NewGameSettings gameSettingsWindow = new NewGameSettings();

			gameSettingsWindow.Owner = Application.Current.MainWindow;
			gameSettingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

			gameSettingsWindow.ShowDialog();
		}
	}
}
