using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTVector2GameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/Vector2GameEventListener")]
    public class NTVector2GameEventListener : NTGenericEventListener<NTVector2GameEvent, Vector2>
    {

    }
}
