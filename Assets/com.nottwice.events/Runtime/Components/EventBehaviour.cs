using UnityEngine;
using UnityEngine.Events;

namespace Assets.com.nottwice.events.Runtime.Components
{
	[AddComponentMenu("NotTwice/Events/EventBehaviour")]
	[DisallowMultipleComponent]
	public class EventBehaviour : MonoBehaviour
	{
		public UnityEvent UnityEvent;

		public void Raise()
		{
			UnityEvent?.Invoke();
		}
	}
}
