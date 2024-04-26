using Assets.com.nottwice.events.Runtime.Components.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Events
{
	public abstract class ReactiveGameEvent<T, U> : ScriptableObject
		where T : ReactiveProperty<U>
	{
		private List<ReactiveEventListener<T, U>> _listeners = new List<ReactiveEventListener<T, U>>();

		public int GetGameEventListenerCount()
		{
			return _listeners.Count;
		}

		public void Raise(U value)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaised(value);
			}
		}

		public void RegisterListener(ReactiveEventListener<T, U> listener)
		{
			if (!_listeners.Contains(listener))
			{
				_listeners.Add(listener);
			}
		}

		public void UnregisterListener(ReactiveEventListener<T, U> listener)
		{
			if (_listeners.Contains(listener))
			{
				_listeners.Remove(listener);
			}
		}
	}
}
