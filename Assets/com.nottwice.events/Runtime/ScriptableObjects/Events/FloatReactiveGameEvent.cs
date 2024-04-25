using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Events
{
	[CreateAssetMenu(menuName = "NotTwice/Events/FloatReactiveGameEvent")]
	public class FloatReactiveGameEvent : ReactiveGameEvent<FloatReactiveProperty, float>
	{
	}
}
