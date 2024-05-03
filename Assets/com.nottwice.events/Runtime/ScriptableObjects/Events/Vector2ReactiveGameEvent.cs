using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Events
{
	[CreateAssetMenu(menuName = "NotTwice/Events/Vector2ReactiveGameEvent")]
	public class Vector2ReactiveGameEvent : ReactiveGameEvent<Vector2ReactiveProperty, Vector2>
	{
	}
}
