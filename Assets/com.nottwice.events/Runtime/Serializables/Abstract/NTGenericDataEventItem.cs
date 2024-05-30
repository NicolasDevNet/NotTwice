using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using System;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Serializables.Abstract
{
	[Serializable]
	public abstract class NTGenericDataEventItem<T, U, V> : NTBaseDataEventItem<T, UnityEvent<U>, V>
        where T : NTGenericGameEvent<T, U>
        where V : NTBaseDataEventItem<T, UnityEvent<U>, V>
    {
        public override void Raise()
        {
            throw new NotImplementedException("Method not implemented for an event with no upstream value");
        }

        public void Raise(U value)
        {
            Event?.Raise(value);
        }
    }
}
