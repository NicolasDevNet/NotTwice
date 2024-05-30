using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTPointerDataGameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/PointerDataGameEventListener")]
    public class NTPointerDataGameEventListener : NTGenericEventListener<NTPointerDataGameEvent, PointerEventData>
    {

    }
}
