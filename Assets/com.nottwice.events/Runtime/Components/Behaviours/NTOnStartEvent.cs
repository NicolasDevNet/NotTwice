using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Behaviours
{
	/// <summary>
	/// Component to trigger a GameEvent when a Start event is detected.
	/// </summary>
	[DefaultExecutionOrder(12)]
	[AddComponentMenu("NotTwice/Events/Behaviours/OnStartEvent")]
	public class NTOnStartEvent : NTGameEventBehaviour
    {
		public void Start()
		{
			Debug.Log($"Start for {name} with event {Event.name}");
			Raise();
		}
	}
}
