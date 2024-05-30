using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using System;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Components.Abstract
{
    /// <summary>
    /// Abstract unity component class for linking a component to an event
    /// </summary>
    /// <typeparam name="T">Type of event</typeparam>
    /// <typeparam name="U">Type of response</typeparam>
    public abstract class NTGenericEventBehaviour<T, U> : NTBaseEventBehaviour<T, UnityEvent<U>>
        where T : NTGenericGameEvent<T, U>
    {
        public override void Raise()
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Method for raising the event associated with the component
		/// </summary>
		public void Raise(U value)
        {
            Event?.Raise(value);
        }
    }
}
