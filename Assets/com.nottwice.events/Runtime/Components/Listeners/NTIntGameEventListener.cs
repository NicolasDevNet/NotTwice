using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTIntGameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/IntGameEventListener")]
    public class NTIntGameEventListener : NTGenericEventListener<NTIntGameEvent, int>
    {

    }
}
