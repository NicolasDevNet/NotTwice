using NotTwice.Events.Runtime.Components.Abstract;
using System.Collections.Generic;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.ScriptableObjects.Abstract
{
    /// <summary>
    /// Generic event class providing type expectations for classes that inherit from it
    /// </summary>
    /// <typeparam name="T">Type of event</typeparam>
    /// <typeparam name="U">The type of response</typeparam>
    public abstract class NTGenericGameEvent<T, U> : NTBaseGameEvent<T, UnityEvent<U>>
        where T : NTGenericGameEvent<T, U>
    {
        private List<NTGenericEventListener<T, U>> _genericListeners = new List<NTGenericEventListener<T, U>>();

        /// <summary>
        /// Method for notifying all listeners of event occurrence
        /// </summary>
        /// <param name="value">The expected serializable value to transmit to them</param>
        public void Raise(U value)
        {
            for (int i = _genericListeners.Count - 1; i >= 0; i--)
            {
				_genericListeners[i].OnEventRaised(value);
            }
        }

		/// <summary>
		/// Method for registering a new listener for this event
		/// </summary>
		/// <param name="listener">The listener instance</param>
		public void RegisterListener(NTGenericEventListener<T, U> listener)
		{
			if (!_genericListeners.Contains(listener))
			{
				_genericListeners.Add(listener);
			}
		}

		/// <summary>
		/// Method for decommissioning a previously registered listener
		/// </summary>
		/// <param name="listener">The listener instance</param>
		public void UnregisterListener(NTGenericEventListener<T, U> listener)
		{
			if (_genericListeners.Contains(listener))
			{
				_genericListeners.Remove(listener);
			}
		}
	}
}
