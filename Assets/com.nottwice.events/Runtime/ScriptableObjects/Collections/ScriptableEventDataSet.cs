using Assets.com.nottwice.events.Runtime.Serializables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Collections
{
	public class ScriptableEventDataSet<T, U> : ScriptableObject
		where T : DataEventItem<U>
	{
		public List<T> DataSet = new List<T>();

		public void Add(T data)
		{
			if (!DataSet.Contains(data))
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
