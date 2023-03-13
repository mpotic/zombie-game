using Back.Dice;
using System.Collections.ObjectModel;

namespace ViewModel
{
	public interface ITableDiceViewModel
	{
		ObservableCollection<IDice> Dice { get; }
	}
}
