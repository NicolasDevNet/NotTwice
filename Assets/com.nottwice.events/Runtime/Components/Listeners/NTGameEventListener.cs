using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTGameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/GameEventListener")]
    public class NTGameEventListener : NTBaseEventListener<NTGameEvent, UnityEvent>
    {
        public override void OnEventRaised()
        {
            Response?.Invoke();
        }
    }
}
