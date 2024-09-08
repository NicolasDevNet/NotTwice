using UnityEngine.EventSystems;
using UnityEngine;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using NotTwice.Events.Runtime.Serializables.Abstract;

namespace NotTwice.Events.Runtime.Components.Behaviours
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerExit event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/Behaviours/OnPointerExitEvent")]
	public class NTOnPointerExitEvent : NTGenericEventTypeSwitcher<NTPointerDataGameEvent, PointerEventData>, IPointerExitHandler
	{
		public void OnPointerExit(PointerEventData eventData)
		{
			Debug.Log($"Pointer exit from {name}");
			Raise(eventData);
		}
	}
}
