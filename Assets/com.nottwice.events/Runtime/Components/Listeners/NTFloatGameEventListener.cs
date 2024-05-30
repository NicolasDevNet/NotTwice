using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTFloatGameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/FloatGameEventListener")]
    public class NTFloatGameEventListener : NTGenericEventListener<NTFloatGameEvent, float>
    {

    }
}
