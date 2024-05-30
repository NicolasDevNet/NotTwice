using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Variables
{
    /// <summary>
    /// Boolean reactive variable associated with an event
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveBoolVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveBoolVariableEvent")]
	public class NTReactiveBoolVariableEvent : NTGenericReactiveVariableEvent<NTBoolGameEvent , BoolReactiveProperty, bool>
	{

	}
}
