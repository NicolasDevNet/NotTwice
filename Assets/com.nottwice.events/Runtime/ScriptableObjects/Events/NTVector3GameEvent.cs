using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a Vector3 value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "Vector3GameEvent", menuName = "NotTwice/Events/Vector3GameEvent")]
    public class NTVector3GameEvent : NTGenericGameEvent<NTVector3GameEvent, Vector3>
	{
	}
}
