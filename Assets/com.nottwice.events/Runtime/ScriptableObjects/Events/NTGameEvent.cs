using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class
    /// </summary>
    [CreateAssetMenu(fileName = "GameEvent", menuName = "NotTwice/Events/GameEvent")]
    public class NTGameEvent : NTBaseGameEvent<NTGameEvent, UnityEvent>
    {

	}
}
