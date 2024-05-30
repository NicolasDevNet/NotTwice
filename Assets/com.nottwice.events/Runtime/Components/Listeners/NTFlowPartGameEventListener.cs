using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.Components.Flow;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTFlowPartGameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/FlowPartGameEventListener")]
    public class NTFlowPartGameEventListener : NTGenericEventListener<NTFlowPartGameEvent, NTEventFlowPart>
    {

    }
}
