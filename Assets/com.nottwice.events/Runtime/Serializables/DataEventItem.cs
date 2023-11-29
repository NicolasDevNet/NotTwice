using Assets.com.nottwice.events.Runtime.ScriptableObjects;

namespace Assets.com.nottwice.events.Runtime.Serializables
{
	/// <summary>
	/// Abstract class for use with a T model to link data to an event
	/// </summary>
	public abstract class DataEventItem<T>
	{
		public GameEvent Event;

		public T Item;

		public void Raise()
		{
			Event?.Raise();
		}

		public bool IsSameItem(T item)
		{
			return Item.Equals(item);
		}
	}
}
