using System;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	public abstract class ReactiveVariableEvent : ScriptableObject
	{
		public GameEvent BoundEvent;

		protected IDisposable _valueObserver;

		public abstract void Subscribe();

		public abstract void UnSubscribe();
	}
}
