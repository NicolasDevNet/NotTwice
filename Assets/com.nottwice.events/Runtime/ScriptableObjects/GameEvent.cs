using Assets.com.nottwice.events.Runtime.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects
{
	[CreateAssetMenu(menuName = "NotTwice/Events/GameEvent")]
	public class GameEvent : ScriptableObject
	{
		private List<GameEventListener> _listeners = new List<GameEventListener>();

		public int GetGameEventListenerCount()
		{
			return _listeners.Count;
		}

		public void Raise()
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener)
		{
			if(!_listeners.Contains(listener))
			{
				_listeners.Add(listener);
			}
		}

		public void UnregisterListener(GameEventListener listener)
		{
			if (_listeners.Contains(listener))
			{
				_listeners.Remove(listener);
			}
		}
	}
}
