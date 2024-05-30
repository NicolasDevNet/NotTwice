using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTStringGameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/StringGameEventListener")]
    public class NTStringGameEventListener : NTGenericEventListener<NTStringGameEvent, string>
    {

    }
}
