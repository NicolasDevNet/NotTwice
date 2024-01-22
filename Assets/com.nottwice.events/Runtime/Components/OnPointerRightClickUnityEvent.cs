using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice.lifetime.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a UnityEvent when a PointerRightClick event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/OnPointerRightClickUnityEvent")]
	public class OnPointerRightClickUnityEvent : MonoBehaviour, IPointerClickHandler
	{
		[Tooltip("Event to register with.")]
		public UnityEvent Event;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if(eventData.button != PointerEventData.InputButton.Right)
			{
				return;
			}

			_logger.Log(LogType.Log, $"Pointer right click on {name}");
			Event?.Invoke();
		}
	}
}
