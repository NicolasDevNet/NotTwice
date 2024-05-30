using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace NotTwice.Events.Runtime.Components.Flow
{
    /// <summary>
    /// Unity component for managing a sequenced flow of events <see cref="NTEventFlowPart"/>
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Flow/EventFlowManager")]
	[DisallowMultipleComponent]
	public class NTEventFlowManager : MonoBehaviour
	{
        /// <summary>
        /// Flag indicating flow status
        /// </summary>
        [ReadOnly, Tooltip("Flag indicating feed status")]
		public bool IsDone;

        /// <summary>
        /// Collection of the various elements that the flow will trigger
        /// </summary>
        [Tooltip("Collection of the various elements that the flow will trigger")]
		public List<NTEventFlowPart> FlowParts = new List<NTEventFlowPart>();

        /// <summary>
        /// Asynchronous method for stream execution
        /// </summary>
        /// <returns>The task resulting from the execution of this flow</returns>
        public async UniTask Execute()
		{
			await WaitForFlowParts();
        }

		private IEnumerator WaitForFlowParts()
		{
			foreach (NTEventFlowPart part in FlowParts)
			{
				part.Execute();
				yield return new WaitUntil(() => part.IsDone);			
			}

			IsDone = true;
		}
	}
}
