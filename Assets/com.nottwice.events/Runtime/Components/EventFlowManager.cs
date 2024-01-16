using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.Components
{
	[AddComponentMenu("NotTwice/Events/EventFlowManager")]
	[DisallowMultipleComponent]
	public class EventFlowManager : MonoBehaviour
	{
		[ReadOnly]
		public bool IsDone;

		public List<EventFlowPart> FlowParts = new List<EventFlowPart>();

		public void Execute()
		{
			StartCoroutine(WaitForFlowParts());
		}

		private IEnumerator WaitForFlowParts()
		{
			foreach (EventFlowPart part in FlowParts)
			{
				yield return new WaitUntil(() => part.IsDone);			
			}

			IsDone = true;
		}
	}
}
