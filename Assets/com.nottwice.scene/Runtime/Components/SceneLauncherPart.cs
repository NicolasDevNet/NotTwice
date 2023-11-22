using UnityEngine;

namespace Assets.com.nottwice.scene.Runtime.Components
{
	/// <summary>
	/// Partial scene initialization component
	/// </summary>
	[AddComponentMenu("NotTwice/Scene/SceneLauncherPart")]
	[DisallowMultipleComponent]
	public abstract class SceneLauncherPart : MonoBehaviour
	{
		public abstract void Init();
	}
}
