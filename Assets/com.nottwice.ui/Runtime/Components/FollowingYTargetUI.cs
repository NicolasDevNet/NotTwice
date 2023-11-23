using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component that allows a Transform component to be followed by this component
	/// </summary>
	[AddComponentMenu("NotTwice/UI/FollowingYTargetUI")]
	[DisallowMultipleComponent]
	public class FollowingYTargetUI : MonoBehaviour
	{
		[Required]
		public FloatVariable AnimationDuration;

		public void ExecuteFollow(Transform target)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"{name} is following {target.name} at Y:{target.position.y}");
			transform.DOMoveY(target.position.y, AnimationDuration.Value);
		}
	}
}
