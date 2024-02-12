using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a UnityEvent when a Start event is detected.
	/// </summary>
	[DefaultExecutionOrder(12)]
	[AddComponentMenu("NotTwice/Events/OnStartUnityEvent")]
	public class OnStartUnityEvent : MonoBehaviour
	{
		[Required, Tooltip("Event to register with.")]
		public UnityEvent Event;

		public void Start()
		{
			Event?.Invoke();
		}
	}
}
