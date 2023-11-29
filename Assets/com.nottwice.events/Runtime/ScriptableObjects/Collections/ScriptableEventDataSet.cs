using Assets.com.nottwice.events.Runtime.Serializables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Collections
{
	public class ScriptableEventDataSet<T> : ScriptableObject
	{
		public List<DataEventItem<T>> DataSet = new List<DataEventItem<T>>();

		public void Add(DataEventItem<T> data)
		{
			if (!DataSet.Contains(data))
			{
				DataSet.Add(data);
			}
		}

		public void Remove(DataEventItem<T> data)
		{
			if (DataSet.Contains(data))
			{
				DataSet.Remove(data);
			}
		}
	}
}
