using NotTwice.Events.Runtime.Components.Flow;
using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a NTEventFlowPart value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "FlowPartEvent", menuName = "NotTwice/Events/FlowPartEvent")]
    public class NTFlowPartGameEvent : NTGenericGameEvent<NTFlowPartGameEvent, NTEventFlowPart>
    {
    }
}
