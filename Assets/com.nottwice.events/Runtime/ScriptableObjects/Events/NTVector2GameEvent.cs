using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a Vector2 value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "Vector2GameEvent", menuName = "NotTwice/Events/Vector2GameEvent")]
    public class NTVector2GameEvent : NTGenericGameEvent<NTVector2GameEvent, Vector2>
	{
	}
}
