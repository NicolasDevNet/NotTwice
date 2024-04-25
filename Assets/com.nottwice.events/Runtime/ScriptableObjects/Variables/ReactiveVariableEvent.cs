using Assets.com.nottwice.events.Runtime.ScriptableObjects.Events;
using System;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	public abstract class ReactiveVariableEvent<T, U> : ScriptableObject
		where T : ReactiveProperty<U>
	{
		public T Value;

		public ReactiveGameEvent<T, U> BoundEvent;

		protected IDisposable _valueObserver;

		public abstract void Subscribe();

		public abstract void UnSubscribe();
	}
}
