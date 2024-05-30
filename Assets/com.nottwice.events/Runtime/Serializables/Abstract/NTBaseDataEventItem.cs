using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using System;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Serializables.Abstract
{
	[Serializable]
	public abstract class NTBaseDataEventItem<T, U, V>
		where V : NTBaseDataEventItem<T, U, V>
        where T : NTBaseGameEvent<T, U>
        where U : UnityEventBase
    {
		public T Event;

		public V Item;

		public virtual void Raise()
		{
			Event?.Raise();
		}

		public bool IsSame(V item)
		{
			return Item.Equals(item);
		}
	}
}
