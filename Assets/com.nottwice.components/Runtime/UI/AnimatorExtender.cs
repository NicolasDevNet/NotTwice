using NaughtyAttributes;
using UnityEngine;

namespace Assets.com.nottwice.components.Runtime.UI
{
	[AddComponentMenu("NotTwice/UI/AnimatorExtender")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Animator))]
	public class AnimatorExtender : MonoBehaviour
	{
		[ReadOnly, Tooltip("The animator is fed automatically if there is an animator on the same gameobject.")]
		public Animator Animator;

		public void Awake()
		{
			Animator = GetComponent<Animator>();
		}

		public bool PlayingAnimationIsDone
		{
			get
			{
				return Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f;
			}
		}
	}
}
