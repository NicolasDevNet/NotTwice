using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.Components.Listeners
{
	/// <summary>
	/// Component for listening to an event and triggering the responses associated with it
	/// </summary>
	[AddComponentMenu("NotTwice/Events/ReactiveStringEventListener")]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(11)]
	public class ReactiveStringEventListener : ReactiveEventListener<StringReactiveProperty, string>
	{
	}
}
