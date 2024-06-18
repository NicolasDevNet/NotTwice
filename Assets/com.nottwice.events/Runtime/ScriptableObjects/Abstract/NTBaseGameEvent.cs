using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NotTwice.Events.Runtime.Components.Abstract;

namespace NotTwice.Events.Runtime.ScriptableObjects.Abstract
{
    /// <summary>
	/// Scriptable event base class providing basic event management methods
	/// </summary>
	/// <typeparam name="T">Type of event</typeparam>
	/// <typeparam name="U">type of response</typeparam>
	public abstract class NTBaseGameEvent<T, U> : ScriptableObject
        where T : NTBaseGameEvent<T, U>
        where U : UnityEventBase
    {
        protected List<NTBaseEventListener<T, U>> _listeners = new List<NTBaseEventListener<T, U>>();

        /// <summary>
        /// Method for raising this event and notifying all listeners
        /// </summary>
        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        /// <summary>
        /// Method for registering a new listener for this event
        /// </summary>
        /// <param name="listener">The listener instance</param>
        public void RegisterListener(NTBaseEventListener<T, U> listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
            }
        }

        /// <summary>
        /// Method for decommissioning a previously registered listener
        /// </summary>
        /// <param name="listener">The listener instance</param>
        public void UnregisterListener(NTBaseEventListener<T, U> listener)
        {
            if (_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
            }
        }
    }
}
