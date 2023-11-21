using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using UnityEngine.EventSystems;
using UnityEngine;
using NaughtyAttributes;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerEnter event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/OnPointerEnterEvent")]
	[DisallowMultipleComponent]
	public class OnPointerEnterEvent : MonoBehaviour, IPointerEnterHandler
	{
		[Required, Tooltip("Event to register with.")]
		public GameEvent Event;

		public void OnPointerEnter(PointerEventData eventData)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Pointer enter on {name}");
			Event.Raise();
		}
	}
}
