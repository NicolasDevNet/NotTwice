using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Events;
using Assets.com.nottwice.lifetime.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerMiddleClick event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/OnPointerMiddleClickEvent")]
	public class OnPointerMiddleClickEvent : MonoBehaviour, IPointerClickHandler
	{
		[Required, Tooltip("Event to register with.")]
		public GameEvent Event;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if(eventData.button != PointerEventData.InputButton.Middle)
			{
				return;
			}

			_logger.Log(LogType.Log, $"Pointer middle click on {name}");
			Event?.Raise();
		}
	}
}
