using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Collections
{
	/// <summary>
	/// This scriptable object is not to be used directly, it is to be implemented by a child class that can contain and store a dataset.
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
