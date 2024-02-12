using Assets.com.nottwice.data.Runtime.Serializables;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Collections;
using System;
using UniRx;

namespace Assets.com.nottwice.data.Runtime.ScriptableObjects
{
	public abstract class ReactiveDataItemStore<T> : ScriptableReactiveDataSetEvent<T>
		where T : DataItem
	{
		public void SubscribeAdd(Action<int> saveAction)
		{
			_addObserver = DataSet.ObserveAdd()
					.Subscribe(addEvent =>
					{
						saveAction?.Invoke(addEvent.Value.Id);

						if (BoundEventAdd != null)
						{
							BoundEventAdd.Raise();
						}				
					});		
		}

		public void SubscribeRemove(Action<int> saveAction)
		{
			_removeObserver = DataSet.ObserveRemove()
					.Subscribe(removeEvent =>
					{
						saveAction?.Invoke(removeEvent.Value.Id);

						if (BoundEventRemove != null)
						{
							BoundEventRemove.Raise();
						}					
					});			
		}
	}
}
