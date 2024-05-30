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
        private List<NTGenericEventListener<T, U>> _listeners = new List<NTGenericEventListener<T, U>>();

        /// <summary>
        /// Method for notifying all listeners of event occurrence
        /// </summary>
        /// <param name="value">The expected serializable value to transmit to them</param>
        public void Raise(U value)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(value);
            }
        }
    }
}
