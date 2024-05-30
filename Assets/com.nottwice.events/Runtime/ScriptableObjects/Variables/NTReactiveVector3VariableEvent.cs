using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Variables
{
    /// <summary>
    /// Vector3 reactive variable associated with an event
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveVector3VariableEvent", menuName = "NotTwice/Events/Variables/ReactiveVector3VariableEvent")]
	public class NTReactiveVector3VariableEvent : NTGenericReactiveVariableEvent<NTVector3GameEvent , Vector3ReactiveProperty, Vector3>
	{

	}
}
