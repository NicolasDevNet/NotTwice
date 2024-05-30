using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// Component that allows a Transform component to be followed by this component
	/// </summary>
	[AddComponentMenu("NotTwice/UI/FollowingYTargetUI")]
	[DisallowMultipleComponent]
	public class FollowingYTargetUI : MonoBehaviour
	{
		[Required]
		public NTFloatVariable AnimationDuration;

		public void ExecuteFollow(Transform target)
		{
			Debug.Log($"{name} is following {target.name} at Y:{target.position.y}");
			transform.DOLocalMoveY(target.localPosition.y, AnimationDuration.Value);
		}
	}
}
