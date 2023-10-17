using System.Collections.Generic;
using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Collections
{
	/// <summary>
	/// Cet objet scriptable n'est pas à utiliser directement, il est à implémenter par une classe enfant qui pourra contenir et stocker un jeu de données.
	/// </summary>
	public abstract class ScriptableDataSet<T> : ScriptableObject
	{
		public List<T> DataSet = new List<T>();

		public void Add(T data)
		{
			if(!DataSet.Contains(data))
			{
				DataSet.Add(data);
			}
		}

		public void Remove(T data)
		{
			if (DataSet.Contains(data))
			{
				DataSet.Remove(data);
			}
		}
	}
}
