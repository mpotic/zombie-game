using System.Windows.Controls;
using ViewModel;

namespace ZombieGame
{
	/// <summary>
	/// Interaction logic for TableDice.xaml
	/// </summary>
	public partial class TableDice : UserControl
	{
		private ITableDiceViewModel tableDiceViewModel = new TableDiceViewModel();

		public ITableDiceViewModel TableDiceViewModel { get => tableDiceViewModel; set => tableDiceViewModel = value; }

		public TableDice()
		{
			InitializeComponent();

			Dice.ItemsSource = TableDiceViewModel.Dice;
		}
	}
}
