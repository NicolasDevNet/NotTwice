using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using NotTwice.Events.Runtime.Serializables.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Components.Behaviours
{
    /// <summary>
    /// Unity component linked to an invocable Unity event
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Behaviours/GameEventBehaviour")]
    public class NTGameEventBehaviour : NTBaseEventTypeSwitcher<NTGameEvent>
    {

    }
}
