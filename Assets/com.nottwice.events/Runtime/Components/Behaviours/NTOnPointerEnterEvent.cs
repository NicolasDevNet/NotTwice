using UnityEngine.EventSystems;
using UnityEngine;
using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using NotTwice.Events.Runtime.Serializables.Abstract;

namespace NotTwice.Events.Runtime.Components.Behaviours
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerEnter event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/Behaviours/OnPointerEnterEvent")]
	public class NTOnPointerEnterEvent : NTGenericEventTypeSwitcher<NTPointerDataGameEvent, PointerEventData>, IPointerEnterHandler
	{
		public void OnPointerEnter(PointerEventData eventData)
		{
			Debug.Log( $"Pointer enter on {name}");
			Raise(eventData);
		}
	}
}
