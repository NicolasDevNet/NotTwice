using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.scene.Runtime.Components
{
	/// <summary>
	/// Scene initialization component that executes the various expected partial components
	/// </summary>
	[AddComponentMenu("NotTwice/Scene/SceneLauncher")]
	[DisallowMultipleComponent]
	public class SceneLauncher : MonoBehaviour
	{
		[Tooltip("List of initialized components")]
		public List<SceneLauncherPart> SceneLauncherParts;

		public void Start()
		{
			foreach (SceneLauncherPart part in SceneLauncherParts)
			{
				part.Init();
			}
		}
	}
}
