using NaughtyAttributes;
using System.Collections;
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

		public IEnumerator Execute()
		{
			Event?.Invoke(this);
			yield return new WaitUntil(() => IsDone);
		}
	}
}
