using UnityEngine.EventSystems;
using UnityEngine;
using Assets.com.nottwice.lifetime.Runtime;
using UnityEngine.Events;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a UnityEvent when a PointerEnter event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/OnPointerEnterUnityEvent")]
	public class OnPointerEnterUnityEvent : MonoBehaviour, IPointerEnterHandler
	{
		[Tooltip("Event to register with.")]
		public UnityEvent Event;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_logger.Log(LogType.Log, $"Pointer enter on {name}");
			Event?.Invoke();
		}
	}
}
