using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.Components.Listeners
{
	/// <summary>
	/// Component for listening to an event and triggering the responses associated with it
	/// </summary>
	[AddComponentMenu("NotTwice/Events/ReactiveVector3EventListener")]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(11)]
	public class ReactiveVector3EventListener : ReactiveEventListener<Vector3ReactiveProperty, Vector3>
	{
	}
}
