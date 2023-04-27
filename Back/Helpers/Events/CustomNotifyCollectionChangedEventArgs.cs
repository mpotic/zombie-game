using System.Collections;
using System.Collections.Specialized;

namespace Back.Helpers.Events
{
	public class CustomNotifyCollectionChangedEventArgs : NotifyCollectionChangedEventArgs
	{
		public CustomEnumNotifyCollectionChangedEventArgs SpecifiedAction { get; set;}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, changedItem)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, changedItems)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, changedItem, index)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int startingIndex, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, changedItems, startingIndex)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, newItem, oldItem)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, newItems, oldItems)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem, int index, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, newItem, oldItem, index)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, newItems, oldItems, startingIndex)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index, int oldIndex, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, changedItem, index, oldIndex)
		{
			SpecifiedAction = specifiedAction;
		}

		public CustomNotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int index, int oldIndex, CustomEnumNotifyCollectionChangedEventArgs specifiedAction) : base(action, changedItems, index, oldIndex)
		{
			SpecifiedAction = specifiedAction;
		}
	}
}
