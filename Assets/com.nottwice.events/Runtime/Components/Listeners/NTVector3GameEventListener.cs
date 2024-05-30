using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTVector3GameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/Vector3GameEventListener")]
    public class NTVector3GameEventListener : NTGenericEventListener<NTVector3GameEvent, Vector3>
    {

    }
}
