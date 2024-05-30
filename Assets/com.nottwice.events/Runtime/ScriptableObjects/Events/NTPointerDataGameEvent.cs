using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a PointerEventData value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "PointerDataGameEvent", menuName = "NotTwice/Events/PointerDataGameEvent")]
    public class NTPointerDataGameEvent : NTGenericGameEvent<NTPointerDataGameEvent, PointerEventData>
	{
	}
}
