using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a Int value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "IntGameEvent", menuName = "NotTwice/Events/IntGameEvent")]
    public class NTIntGameEvent : NTGenericGameEvent<NTIntGameEvent, int>
	{
	}
}
