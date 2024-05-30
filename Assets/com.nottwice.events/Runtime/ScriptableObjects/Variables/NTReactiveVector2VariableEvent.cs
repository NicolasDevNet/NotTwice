using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Variables
{
    /// <summary>
    /// Vector2 reactive variable associated with an event
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveVector2VariableEvent", menuName = "NotTwice/Events/Variables/ReactiveVector2VariableEvent")]
	public class NTReactiveVector2VariableEvent : NTGenericReactiveVariableEvent<NTVector2GameEvent , Vector2ReactiveProperty, Vector2>
	{

	}
}
