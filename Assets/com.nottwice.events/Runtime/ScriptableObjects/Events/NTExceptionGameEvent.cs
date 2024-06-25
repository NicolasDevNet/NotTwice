using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using System;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
    /// <summary>
    /// Scriptable event class for passing an Exception value through the event chain
    /// </summary>
    [CreateAssetMenu(fileName = "ExceptionGameEvent", menuName = "NotTwice/Events/ExceptionGameEvent")]
    public class NTExceptionGameEvent : NTGenericGameEvent<NTExceptionGameEvent, Exception>
	{
	}
}
