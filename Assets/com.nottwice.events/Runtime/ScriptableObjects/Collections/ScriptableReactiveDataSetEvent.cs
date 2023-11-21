using System;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Collections
{
	/// <summary>
	/// This scriptable object is not to be used directly, it is to be implemented by a child class that can contain and store a dataset.
	/// </summary>
	public abstract class ScriptableReactiveDataSetEvent<T> : ScriptableObject
	{
		public ReactiveCollection<T> DataSet = new ReactiveCollection<T>();

		public GameEvent BoundEventAdd;

		public GameEvent BoundEventRemove;

		private IDisposable _addObserver;
		private IDisposable _removeObserver;

		public void SubscribeRemove()
		{
			if (BoundEventRemove != null)
			{
				_removeObserver = DataSet.ObserveAdd()
					.Subscribe(_ => 
					{
						ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Event raise: {BoundEventRemove.name}");
						BoundEventRemove.Raise();
					});
			}
		}

		public void UnSubscribeRemove()
		{
			if (BoundEventRemove != null)
			{
				_removeObserver.Dispose();
			}
		}

		public void SubscribeAdd()
		{
			if (BoundEventAdd != null)
			{
				_addObserver = DataSet.ObserveAdd()
					.Subscribe(_ => 
					{
						ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Event raise: {BoundEventAdd.name}");
						BoundEventAdd.Raise();
					});
			}
		}

		public void UnSubscribeAdd()
		{
			if (BoundEventAdd != null)
			{
				_addObserver.Dispose();
			}
		}

		public void Add(T data)
		{
			if (!DataSet.Contains(data))
			{
				DataSet.Add(data);
			}
		}

		public void Remove(T data)
		{
			if (DataSet.Contains(data))
			{
				DataSet.Remove(data);
			}
		}
	}
}
