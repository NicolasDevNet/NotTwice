using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing a Float value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "FloatGameEvent", menuName = "NotTwice/Events/FloatGameEvent")]
    public class NTFloatGameEvent : NTGenericGameEvent<NTFloatGameEvent, float>
	{
	}
}
