using System;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Abstract
{
	/// <summary>
	/// Scriptable variable that triggers an event when its value changes
	/// </summary>
	/// <typeparam name="T">Type of event</typeparam>
	/// <typeparam name="U">The type of reactive property</typeparam>
	/// <typeparam name="V">The primary type associated with the reactive property</typeparam>
	public abstract class NTGenericReactiveVariableEvent<T, U, V> : ScriptableObject
		where T : NTGenericGameEvent<T, V>
		where U : ReactiveProperty<V>
	{
		/// <summary>
		/// Event triggered when the value of the variable changes
		/// </summary>
		public NTGenericGameEvent<T, V> BoundEvent;

		/// <summary>
		/// Current value of the variable
		/// </summary>
		public U Value;

		protected IDisposable _valueObserver;

		/// <summary>
		/// Method used to subscribe to the observer which will trigger an event when the value of the variable changes
		/// </summary>
		public void Subscribe()
		{
			_valueObserver = Value.Subscribe(value =>
			{
				Debug.Log(BoundEvent);
				BoundEvent?.Raise(value);
			});
		}

		/// <summary>
		/// Method used to unsubscribe to the observer which will trigger an event when the value of the variable changes
		/// </summary>
		public void UnSubscribe()
		{
			_valueObserver?.Dispose();
		}

		/// <summary>
		/// Method used to define the value for the variable
		/// </summary>
		/// <param name="value">New value</param>
		public void SetValue(V value)
		{
			Value.Value = value;
		}

		/// <summary>
		/// Method used to define the value for the variable and force an event
		/// </summary>
		/// <param name="value">New value</param>
		public void SetValueAndForceNotify(V value)
		{
			Value.SetValueAndForceNotify(value);
		}
	}
}
