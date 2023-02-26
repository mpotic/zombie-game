using Back.Game;
using System.Windows.Controls;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for TableDice.xaml
	/// </summary>
	public partial class TableDice : UserControl
	{

		public TableDice()
		{
			InitializeComponent();

			Dice.ItemsSource = GameSingleton.instance.Game.Score.AllRolledDice;
		}
	}
}
