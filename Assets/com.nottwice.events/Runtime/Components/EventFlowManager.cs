using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.Components
{
	[AddComponentMenu("NotTwice/Events/EventFlowManager")]
	[DisallowMultipleComponent]
	public class EventFlowManager : MonoBehaviour
	{
		public List<EventFlowPart> FlowParts = new List<EventFlowPart>();

		public void Execute()
		{
			foreach(EventFlowPart part in FlowParts)
			{
				StartCoroutine(part.Execute());
			}
		}
	}
}
