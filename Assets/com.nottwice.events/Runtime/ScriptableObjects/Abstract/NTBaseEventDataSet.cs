using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.ScriptableObjects.Abstract
{
	/// <summary>
	/// Basic scriptable object for holding a collection of <see cref="DataEventItem<U>"/>.
	/// </summary>
	/// <typeparam name="T">T is the concrete type of <see cref="DataEventItem<U>."/></typeparam>
	/// <typeparam name="U">U is the type associated with <see cref="DataEventItem<U>.</typeparam>
	public abstract class NTBaseEventDataSet<T, U, V> : ScriptableObject
        where T : NTBaseGameEvent<T, U>
        where U : UnityEventBase
    {
		/// <summary>
		/// Collection of items contained in this scriptable object
		/// </summary>
		public List<V> DataSet = new List<V>();

		/// <summary>
		/// Method used to add an item to the collection if it is not already there
		/// </summary>
		/// <param name="data">L'item a ajouter</param>
		public void Add(V data)
		{
			if (!DataSet.Contains(data))
			{
				DataSet.Add(data);
			}
		}

		/// <summary>
		/// Method for removing an item from the collection if it is in the collection
		/// </summary>
		/// <param name="data">L'item a retirer</param>
		public void Remove(V data)
		{
			if (DataSet.Contains(data))
			{
				DataSet.Remove(data);
			}
		}
	}
}
