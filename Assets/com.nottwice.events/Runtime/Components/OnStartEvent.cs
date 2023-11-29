using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a GameEvent when a Start event is detected.
	/// </summary>
	[DefaultExecutionOrder(12)]
	[AddComponentMenu("NotTwice/Events/OnStartEvent")]
	public class OnStartEvent : MonoBehaviour
	{
		[Required, Tooltip("Event to register with.")]
		public GameEvent Event;

		public void Start()
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Start for {name} with event {Event.name}");
			Event.Raise();
		}
	}
}
