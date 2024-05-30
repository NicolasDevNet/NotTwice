using NaughtyAttributes;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Components.Flow
{
    /// <summary>
    /// Part of a managed flow <see cref="NTEventFlowManager"/>
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Flow/EventFlowPart")]
	public class NTEventFlowPart : MonoBehaviour
	{
        /// <summary>
        /// Defines whether a UnityEvent object should be used to trigger the event
        /// </summary>
        [OnValueChanged(nameof(OnUseUnityEventChange))]
        [Tooltip("Defines whether a UnityEvent object should be used to trigger the event")]
        public bool UseUnityEvent;

        /// <summary>
        /// Defines whether a GameEvent object should be used to trigger the event
        /// </summary>
        [OnValueChanged(nameof(OnUseGameEventChange))]
        [Tooltip("Defines whether a GameEvent object should be used to trigger the event")]
        public bool UseGameEvent;

        /// <summary>
        /// Flag indicating the status of this flow element
        /// </summary>
		[ReadOnly, Tooltip("Flag indicating the status of this flow element")]
		public bool IsDone;

        /// <summary>
        /// Unity event triggered for this flow element
        /// <para>The value of this instance of <see cref="NTEventFlowPart"/> is passed as a parameter to manipulate its status later.</para>
        /// </summary>
        [ShowIf(nameof(UseUnityEvent))]
        [Tooltip("Unity event triggered for this flow element")]
		public UnityEvent<NTEventFlowPart> UnityEvent;

        /// <summary>
        /// Game event triggered for this flow element
        /// <para>The value of this instance of <see cref="NTEventFlowPart"/> is passed as a parameter to manipulate its status later.</para>
        /// </summary>
        [ShowIf(nameof(UseGameEvent))]
        [Tooltip("Game event triggered for this flow element")]
        public NTFlowPartGameEvent GameEvent;

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
            if (UseUnityEvent)
            {
                UnityEvent?.Invoke(this);
            }
            else if(UseGameEvent)
            {
                GameEvent?.Raise(this);
            }
		}

        private void OnUseUnityEventChange()
        {
            if(UseUnityEvent)
            {
                UseGameEvent = false;
            }
        }

        private void OnUseGameEventChange()
        {
            if (UseGameEvent)
            {
                UseUnityEvent = false;
            }
        }
    }
}
