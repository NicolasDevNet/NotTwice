using NaughtyAttributes;
using UnityEngine.Events;
using UnityEngine;
using NotTwice.Events.Runtime.ScriptableObjects.Abstract;

namespace NotTwice.Events.Runtime.Components.Abstract
{
    /// <summary>
	/// Base class for listener events, providing basic methods and fields for other listeners
	/// </summary>
	/// <typeparam name="T">Type of event</typeparam>
	/// <typeparam name="U">Type of event response</typeparam>
	public abstract class NTBaseEventListener<T, U> : MonoBehaviour
        where T : NTBaseGameEvent<T, U>
        where U : UnityEventBase
    {
        /// <summary>
        /// Event to register with.
        /// </summary>
        [Required, Tooltip("Event to register with.")]
        public T Event;

        /// <summary>
        /// Response to invoke when Event is raised.
        /// </summary>
        [Tooltip("Response to invoke when Event is raised.")]
        public U Response;

        /// <summary>
        /// Method for responding to the lifting of an event
        /// </summary>
        public abstract void OnEventRaised();

        #region LifeCycle

        protected void OnEnable()
        {
            Event.RegisterListener(this);
        }

        protected void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        #endregion
    }
}
