using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.NotTwice.Tools.Runtime.Components.Events
{
	[AddComponentMenu("NotTwice/Events/Game Event Listener")]
	public class GameEventListener : MonoBehaviour
	{
		[Tooltip("Event to register with.")]
		public GameEvent Event;

		[Tooltip("Response to invoke when Event is raised.")]
		public UnityEvent Response;

		protected void OnEnable()
		{
			Event.RegisterListener(this);
		}

		protected void OnDisable()
		{
			Event.UnregisterListener(this);
		}

		public void OnEventRaised()
		{
			Response.Invoke();
		}
	}
}
