using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a String value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "StringGameEvent", menuName = "NotTwice/Events/StringGameEvent")]
    public class NTStringGameEvent : NTGenericGameEvent<NTStringGameEvent, string>
	{
	}
}
