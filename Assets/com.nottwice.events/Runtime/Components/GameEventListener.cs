using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice.lifetime.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component for listening to an event and triggering the responses associated with it
	/// </summary>
	[AddComponentMenu("NotTwice/Events/GameEventListener")]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(11)]
	public class GameEventListener : MonoBehaviour
	{
		[Required ,Tooltip("Event to register with.")]
		public GameEvent Event;

		[Tooltip("Response to invoke when Event is raised.")]
		public UnityEvent Response;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		protected void OnEnable()
		{
			Event.RegisterListener(this);
		}

		protected void OnDisable()
		{
			Event.UnregisterListener(this);
		}

		public void OnEventRaised()
		{
			_logger.Log(LogType.Log, $"Event raise: {Event.name}");
			Response?.Invoke();
		}
	}
}
