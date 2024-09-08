using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using NotTwice.Events.Runtime.Serializables.Abstract;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotTwice.Events.Runtime.Components.Behaviours
{
    /// <summary>
    /// Component to trigger a GameEvent when a PointerLeftClick event is detected.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Behaviours/OnPointerLeftClickEvent")]
	public class NTOnPointerClickEvent : NTGenericEventTypeSwitcher<NTPointerDataGameEvent, PointerEventData>, IPointerClickHandler
	{
		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log($"Pointer click on {name}");
			Raise(eventData);
		}
	}
}
