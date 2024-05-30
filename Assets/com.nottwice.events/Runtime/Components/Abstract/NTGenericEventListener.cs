using System;
using UnityEngine.Events;
using UnityEngine;
using NotTwice.Events.Runtime.ScriptableObjects.Abstract;

namespace NotTwice.Events.Runtime.Components.Abstract
{
    /// <summary>
	/// Generic listener event class providing type expectations for classes that inherit from it
	/// </summary>
	/// <typeparam name="T">Type of event</typeparam>
	/// <typeparam name="U">The type of response</typeparam>
	public abstract class NTGenericEventListener<T, U> : NTBaseEventListener<T, UnityEvent<U>>
        where T : NTGenericGameEvent<T, U>
    {
        /// <summary>
        /// Generic method called when an event is raised
        /// </summary>
        /// <param name="value">The serializable value returned by the</param>
        public void OnEventRaised(U value)
        {
            Debug.Log($"Event raise: {Event.name}");
            Response?.Invoke(value);
        }

        public override void OnEventRaised()
        {
            throw new NotImplementedException("Method not implemented for an event with no upstream value");
        }
    }
}
