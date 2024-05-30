using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a Boolean value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "BoolGameEvent", menuName = "NotTwice/Events/BoolGameEvent")]
    public class NTBoolGameEvent : NTGenericGameEvent<NTBoolGameEvent, bool>
	{
	}
}
