using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Events
{
	[CreateAssetMenu(menuName = "NotTwice/Events/Vector3ReactiveGameEvent")]
	public class Vector3ReactiveGameEvent : ReactiveGameEvent<Vector3ReactiveProperty, Vector3>
	{
	}
}
