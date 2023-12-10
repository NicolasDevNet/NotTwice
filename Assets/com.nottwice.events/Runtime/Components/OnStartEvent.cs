using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice.lifetime.Runtime;
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

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void Start()
		{
			_logger.Log(LogType.Log, $"Start for {name} with event {Event.name}");
			Event.Raise();
		}
	}
}
