using NaughtyAttributes;
using System;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Abstract
{
	/// <summary>
	/// This scriptable object is not to be used directly, it is to be implemented by a child class that can contain and store a dataset.
	/// </summary>
	public abstract class NTGenericReactiveDataSetEvent<T, U> : ScriptableObject
		where T : NTGenericGameEvent<T, U>
	{
		/// <summary>
		/// Reactive collection that triggers an event each time an item is added or removed
		/// </summary>
		[Expandable ,Tooltip("Reactive collection that triggers an event each time an item is added or removed")]
		public ReactiveCollection<U> DataSet = new ReactiveCollection<U>();

		/// <summary>
		/// Event triggered when an element is added to the collection
		/// </summary>
		[Tooltip("Event triggered when an element is added to the collection")]
		public NTGenericGameEvent<T, U> BoundEventAdd;

		/// <summary>
		/// Event triggered when an element is removed from the collection
		/// </summary>
		[Tooltip("Event triggered when an element is removed from the collection")]
		public NTGenericGameEvent<T, U> BoundEventRemove;

		protected IDisposable _addObserver;
		protected IDisposable _removeObserver;

		/// <summary>
		/// Method for registering with the observer, which triggers an event when an item in the collection is removed
		/// </summary>
		public virtual void SubscribeRemove()
		{
			if (BoundEventRemove != null)
			{
				_removeObserver = DataSet.ObserveRemove()
					.Subscribe(e => 
					{
						BoundEventRemove.Raise(e.Value);
					});
			}
		}

		/// <summary>
		/// Method for unregistering with the observer, which triggers an event when an item in the collection is removed
		/// </summary>
		public virtual void UnSubscribeRemove()
		{
			if (BoundEventRemove != null)
			{
				_removeObserver.Dispose();
			}
		}

		/// <summary>
		/// Method for registering with the observer, which triggers an event when an item in the collection is added
		/// </summary>
		public virtual void SubscribeAdd()
		{
			if (BoundEventAdd != null)
			{
				_addObserver = DataSet.ObserveAdd()
					.Subscribe(e => 
					{
						BoundEventAdd.Raise(e.Value);
					});
			}
		}

		/// <summary>
		/// Method for unregistering with the observer, which triggers an event when an item in the collection is added
		/// </summary>
		public virtual void UnSubscribeAdd()
		{
			if (BoundEventAdd != null)
			{
				_addObserver.Dispose();
			}
		}

		/// <summary>
		/// Method used to add an element to the collection if it does not already exist
		/// </summary>
		/// <param name="data">The item to be added</param>
		public void Add(U data)
		{
			if (!DataSet.Contains(data))
			{
				DataSet.Add(data);
			}
		}

		/// <summary>
		/// Method used to remove an element to the collection if it does exist
		/// </summary>
		/// <param name="data">The item to be removed</param>
		public void Remove(U data)
		{
			if (DataSet.Contains(data))
			{
				DataSet.Remove(data);
			}
		}
	}
}
