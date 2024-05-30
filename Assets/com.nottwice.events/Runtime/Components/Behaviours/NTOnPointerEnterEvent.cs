using UnityEngine.EventSystems;
using UnityEngine;
using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;

namespace NotTwice.Events.Runtime.Components.Behaviours
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerEnter event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/Behaviours/OnPointerEnterEvent")]
	public class NTOnPointerEnterEvent : NTGenericEventBehaviour<NTPointerDataGameEvent, PointerEventData>, IPointerEnterHandler
	{
		public void OnPointerEnter(PointerEventData eventData)
		{
			Debug.Log( $"Pointer enter on {name}");
			Raise(eventData);
		}
	}
}
