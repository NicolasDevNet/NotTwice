using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Variables
{
    /// <summary>
    /// Float reactive variable associated with an event
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveFloatVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveFloatVariableEvent")]
	public class NTReactiveFloatVariableEvent : NTGenericReactiveVariableEvent<NTFloatGameEvent , FloatReactiveProperty, float>
	{

	}
}
