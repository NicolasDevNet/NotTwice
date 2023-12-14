using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using Assets.com.nottwice.lifetime.Runtime;

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
		public FloatVariable AnimationDuration;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void ExecuteFollow(Transform target)
		{
			_logger.Log(LogType.Log, $"{name} is following {target.name} at Y:{target.position.y}");
			transform.DOLocalMoveY(target.position.y, AnimationDuration.Value);
		}
	}
}
