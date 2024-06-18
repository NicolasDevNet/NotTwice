using NaughtyAttributes;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using NotTwice.Events.Runtime.Serializables.Abstract;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Flow
{
    /// <summary>
    /// Part of a managed flow <see cref="NTEventFlowManager"/>
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Flow/EventFlowPart")]
	public class NTEventFlowPart : NTGenericEventTypeSwitcher<NTFlowPartGameEvent, NTEventFlowPart>
	{
        /// <summary>
        /// Flag indicating the status of this flow element
        /// </summary>
		[ReadOnly, Tooltip("Flag indicating the status of this flow element")]
		public bool IsDone;

        /// <summary>
        /// Unity Editor Friendly method for indicating that this flow element has completed its task
        /// </summary>
        public void SetIsDone()
		{
			IsDone = true;
		}

        /// <summary>
        /// Unity Editor Friendly method for executing this flow element's task
        /// </summary>
		public void Execute()
		{
            Raise(this);
		}
    }
}
