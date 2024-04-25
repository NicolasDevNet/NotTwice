using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Events
{
	[CreateAssetMenu(menuName = "NotTwice/Events/IntReactiveGameEvent")]
	public class IntReactiveGameEvent : ReactiveGameEvent<IntReactiveProperty, int>
	{
	}
}
