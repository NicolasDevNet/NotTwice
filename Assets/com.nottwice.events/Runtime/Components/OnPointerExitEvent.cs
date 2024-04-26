using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using UnityEngine.EventSystems;
using UnityEngine;
using NaughtyAttributes;
using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Events;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerExit event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/OnPointerExitEvent")]
	public class OnPointerExitEvent : MonoBehaviour, IPointerExitHandler
	{
		[Required, Tooltip("Event to register with.")]
		public SOGameEvent Event;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_logger.Log(LogType.Log, $"Pointer exit from {name}");
			Event.Raise();
		}
	}
}
