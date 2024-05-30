using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UniRx;
using UnityEngine;

namespace NotTwice.Events.Runtime.ScriptableObjects.Variables
{
    /// <summary>
    /// String reactive variable associated with an event
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveStringVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveStringVariableEvent")]
	public class NTReactiveStringVariableEvent : NTGenericReactiveVariableEvent<NTStringGameEvent , StringReactiveProperty, string>
	{

	}
}
