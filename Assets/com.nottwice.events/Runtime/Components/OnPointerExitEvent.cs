using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using UnityEngine.EventSystems;
using UnityEngine;
using NaughtyAttributes;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerExit event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/OnPointerExitEvent")]
	[DisallowMultipleComponent]
	public class OnPointerExitEvent : MonoBehaviour, IPointerExitHandler
	{
		[Required, Tooltip("Event to register with.")]
		public GameEvent Event;

		public void OnPointerExit(PointerEventData eventData)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Pointer exit from {name}");
			Event.Raise();
		}
	}
}
