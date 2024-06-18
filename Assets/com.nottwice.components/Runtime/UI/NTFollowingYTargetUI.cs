using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;

namespace NotTwice.Components.Runtime.UI
{
	/// <summary>
	/// Component that allows a Transform component to be followed by this component
	/// </summary>
	[AddComponentMenu("NotTwice/UI/FollowingYTargetUI")]
	[DisallowMultipleComponent]
	public class NTFollowingYTargetUI : MonoBehaviour
	{
		[Required, Expandable]
		public NTFloatVariable AnimationDuration;

		public void ExecuteFollow(Transform target)
		{
			Debug.Log($"{name} is following {target.name} at Y:{target.position.y}");
			transform.DOLocalMoveY(target.localPosition.y, AnimationDuration.Value);
		}
	}
}
