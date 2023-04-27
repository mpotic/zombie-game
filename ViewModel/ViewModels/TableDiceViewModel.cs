using Back.Dice;
using Back.Game;
using Back.Helpers.Events;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ViewModel
{
	public class TableDiceViewModel : ITableDiceViewModel
	{
		private readonly ObservableCollection<IDice> dice = new ObservableCollection<IDice>();

		private readonly int delayDurationMilliseconds = 1600;

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
			if (args is CustomNotifyCollectionChangedEventArgs customArgs)
			{
				DelayedResetUpdate(sender, customArgs);
				return;
			}

			if (args.Action == NotifyCollectionChangedAction.Reset)
			{
				while (Dice.Count > 0)
				{
					Dice.RemoveAt(0);
				}
			}
			else if (args.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (IDice dice in args.NewItems)
				{
					Dice.Add(dice);
				}
			}
			else if (args.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (IDice dice in args.OldItems)
				{
					Dice.Remove(dice);
				}
			}
		}

		public void DelayedResetUpdate(object sender, CustomNotifyCollectionChangedEventArgs customArgs)
		{
			if (customArgs.SpecifiedAction == CustomEnumNotifyCollectionChangedEventArgs.DELAYED_RESET)
			{
				Task.Run(() =>
				{
					Thread.Sleep(delayDurationMilliseconds);
					while (Dice.Count > 0)
					{
						Dice.RemoveAt(0);
					}
				});
			}
		}
	}
}
