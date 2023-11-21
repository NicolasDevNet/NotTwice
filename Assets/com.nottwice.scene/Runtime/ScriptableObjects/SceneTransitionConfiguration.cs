using NaughtyAttributes;
using UnityEngine;

namespace Assets.com.nottwice.scene.Runtime.ScriptableObjects
{
	[CreateAssetMenu(fileName = "SceneTransitionConfiguration", menuName = "NotTwice/Configurations/Scene/SceneTransitionConfiguration")]
	public class SceneTransitionConfiguration : ScriptableObject
	{
		[Scene]
		[Tooltip("Transition scene name")]
		public string SceneName;

		[Tooltip("Name of the variable in the animator that triggers the end-of-transition animation state.")]
		public string ShowCurtainStateEndedName;
	}
}
