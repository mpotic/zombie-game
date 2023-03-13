using Back.Dice;
using Back.Game;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Data;

namespace ViewModel
{
	public class TableDiceViewModel : ITableDiceViewModel
	{
		private ObservableCollection<IDice> dice = new ObservableCollection<IDice>();

		public ObservableCollection<IDice> Dice
		{
			get => dice;
		}

		public TableDiceViewModel()
		{
			BindingOperations.EnableCollectionSynchronization(Dice, new object());
			((Score)GameSingleton.instance.Game.Factory.GetFlyweight(typeof(Score))).CollectionChanged += UpdateDiceProperty;
		}

		public void UpdateDiceProperty(object sender, NotifyCollectionChangedEventArgs args)
		{
			if(args.Action == NotifyCollectionChangedAction.Reset)
			{
				while(Dice.Count > 0)
				{
					Dice.RemoveAt(0);
				}
			}
			else if(args.Action == NotifyCollectionChangedAction.Add)
			{
				foreach(IDice dice in args.NewItems)
				{
					Dice.Add(dice);
				}
			}
			else if(args.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach(IDice dice in args.OldItems)
				{
					Dice.Remove(dice);
				}
			}
		}
	}
}
