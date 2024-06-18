using NaughtyAttributes;
using UnityEngine.SceneManagement;

namespace NotTwice.Scene.Runtime
{
	/// <summary>
	/// Internal constant class dedicated to static resource pooling
	/// </summary>
	internal static class Constants
	{
		/// <summary>
		/// Collection of loading modes for a scene
		/// </summary>
		public static DropdownList<LoadSceneMode> LoadSceneModes = new DropdownList<LoadSceneMode>()
			{
				{ LoadSceneMode.Single.ToString(), LoadSceneMode.Single },
				{ LoadSceneMode.Additive.ToString(), LoadSceneMode.Additive }
			};
	}
}
