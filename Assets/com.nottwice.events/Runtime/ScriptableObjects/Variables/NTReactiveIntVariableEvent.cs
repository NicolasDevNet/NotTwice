using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Variables
{
    /// <summary>
    /// Int reactive variable associated with an event
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveIntVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveIntVariableEvent")]
	public class NTReactiveIntVariableEvent : NTGenericReactiveVariableEvent<NTIntGameEvent , IntReactiveProperty, int>
	{

	}
}
