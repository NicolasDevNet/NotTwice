using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Collections;
using Assets.com.nottwice.events.Runtime.Serializables;
using Assets.com.nottwice.lifetime.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Abstract class used to trigger a conditioned event when the component is activated.
	/// The event triggered is the one linked to the conditioned item.
	/// </summary>
	[DefaultExecutionOrder(12)]
	public abstract class OnStartConditionalDataSetEvent<T, U> : MonoBehaviour
		where T : DataEventItem<U>
	{
		public ScriptableEventDataSet<T, U> DataEventItems;

		[ReadOnly]
		public U ConditionalItem;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		protected void OnEnable()
		{
			GameEvent targetEvent = GetTargetEvent();

			_logger.Log(LogType.Log, $"Start for {name} with event {targetEvent.name}");
			targetEvent.Raise();
		}

		protected void SetConditionalItem(U conditionalItem)
		{
			ConditionalItem = conditionalItem;
		}

		protected GameEvent GetTargetEvent()
		{
			return DataEventItems.DataSet.Find(dei => dei.IsSameItem(ConditionalItem)).Event;
		}
	}
}
