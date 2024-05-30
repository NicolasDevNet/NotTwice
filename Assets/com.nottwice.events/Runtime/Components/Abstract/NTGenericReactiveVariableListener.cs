using UnityEngine;
using System.Collections.Generic;
using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UniRx;

namespace NotTwice.Events.Runtime.Components.Abstract
{
    /// <summary>
	/// Abstract class to subscribe the modification of reactive variables
	/// </summary>
	/// <typeparam name="T">Type of <see cref="NTGenericGameEvent<T, V>"/></typeparam>
	/// <typeparam name="U">Type of <see cref="ReactiveProperty<V>>"/></typeparam>
	/// <typeparam name="V">Type of internal value for <see cref="NTGenericGameEvent<T, V>"/></typeparam>
    public abstract class NTGenericReactiveVariableListener<T, U, V> : MonoBehaviour
        where T : NTGenericGameEvent<T, V>
        where U : ReactiveProperty<V>
    {
        /// <summary>
        /// Collection of reactive variables to subscribe to
        /// </summary>
        [Tooltip("Collection of reactive variables to subscribe to")]
		public List<NTGenericReactiveVariableEvent<T, U, V>> ReactiveVariableEvents = new List<NTGenericReactiveVariableEvent<T, U, V>>();

		public void OnEnable()
		{
			foreach(var ev in ReactiveVariableEvents)
			{
				ev.Subscribe();
				Debug.Log($"Subscribe to {ev.name}");
			}
		}

		public void OnDisable()
		{
			foreach (var ev in ReactiveVariableEvents)
			{
				ev.UnSubscribe();
				Debug.Log($"UnSubscribe from {ev.name}");
			}
		}
	}
}
