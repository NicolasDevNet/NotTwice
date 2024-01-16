using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.com.nottwice.events.Runtime.Components
{
	[AddComponentMenu("NotTwice/Events/EventFlowPart")]
	public class EventFlowPart : MonoBehaviour
	{
		[ReadOnly]
		public bool IsDone;

		public UnityEvent<EventFlowPart> Event;

		public void SetIsDone()
		{
			IsDone = true;
		}

		public void Execute()
		{
			Event?.Invoke(this);
		}
	}
}
