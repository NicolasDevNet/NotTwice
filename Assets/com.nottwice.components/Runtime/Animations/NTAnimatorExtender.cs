using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

namespace NotTwice.Components.Runtime.Animations
{
    /// <summary>
    /// Extension class for an Animator component
    /// </summary>
    [AddComponentMenu("NotTwice/Animations/AnimatorExtender")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Animator))]
	public class NTAnimatorExtender : MonoBehaviour
	{
        /// <summary>
        /// The animator is fed automatically if there is an animator on the same gameobject.
        /// </summary>
        [ReadOnly, Tooltip("The animator is fed automatically if there is an animator on the same gameobject.")]
		public Animator Animator;

        /// <summary>
        /// End of animation event to be triggered manually with InvokeEndAnimationEvent method
        /// </summary>
        [Tooltip("End of animation event to be triggered manually with InvokeEndAnimationEvent method")]
		public UnityEvent EndAnimationEvent;

		public void Awake()
		{
			Animator = GetComponent<Animator>();
		}

        /// <summary>
        /// Indicates whether the animation has been played
        /// <para>Not covered by unit tests due to its dependency on an AnimatorController</para>
        /// </summary>
        [ExcludeFromCoverage]
        public bool PlayingAnimationIsDone()
		{
            return Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f;
        }

        /// <summary>
        /// Method for deactivating the Game Object associated with the animator
        /// </summary>
        public void DeactivateGameObject()
		{
			gameObject.SetActive(false);
		}

        /// <summary>
        /// Method for triggering the end-of-animation event
        /// </summary>
        public void InvokeEndAnimationEvent()
		{
			EndAnimationEvent?.Invoke();
        }
	}
}
