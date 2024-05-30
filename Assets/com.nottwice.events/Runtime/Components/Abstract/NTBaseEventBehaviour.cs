using NaughtyAttributes;
using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Components.Abstract
{
	/// <summary>
	/// Abstract unity component class for linking a component to an event
	/// </summary>
	/// <typeparam name="T">Type of event</typeparam>
	/// <typeparam name="U">type of response</typeparam>
	public abstract class NTBaseEventBehaviour<T, U> : MonoBehaviour
        where T : NTBaseGameEvent<T, U>
        where U : UnityEventBase
    {
        /// <summary>
        /// Unity component event
        /// </summary>
        [Required, Tooltip("Unity component event")]
        public T Event;

        /// <summary>
        /// Method for raising the event associated with the component
        /// </summary>
        public abstract void Raise();
    }
}
