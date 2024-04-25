using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Events
{
	[CreateAssetMenu(menuName = "NotTwice/Events/StringReactiveGameEvent")]
	public class StringReactiveGameEvent : ReactiveGameEvent<StringReactiveProperty, string>
	{
	}
}
