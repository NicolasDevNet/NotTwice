using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Collections;
using Assets.com.nottwice.events.Runtime.Serializables;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Abstract class used to trigger a conditioned event when the component is activated.
	/// The event triggered is the one linked to the conditioned item.
	/// </summary>
	public abstract class OnStartConditionalDataSetEvent<T> : MonoBehaviour
		where T : DataEventItem<T>
	{
		public ScriptableEventDataSet<T> DataEventItems;

		[ReadOnly]
		public T ConditionalItem;

		protected void OnEnable()
		{
			GameEvent targetEvent = GetTargetEvent();

			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Start for {name} with event {targetEvent.name}");
			targetEvent.Raise();
		}

		protected void SetConditionalItem(T conditionalItem)
		{
			ConditionalItem = conditionalItem;
		}

		protected GameEvent GetTargetEvent()
		{
			return DataEventItems.DataSet.Find(dei => dei.IsSameItem(ConditionalItem)).Event;
		}
	}
}
