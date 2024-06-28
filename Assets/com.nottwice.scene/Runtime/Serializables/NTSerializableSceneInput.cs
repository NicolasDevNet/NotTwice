using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotTwice.Scene.Runtime.Serializables
{
	/// <summary>
	/// Serializable input class used to call scene change functions
	/// </summary>
	[Serializable]
	public class NTSerializableSceneInput
	{
		/// <summary>
		/// Enum defining the scene loading mode
		/// </summary>
		[Tooltip("Enum defining the scene loading mode")]
		[Dropdown(nameof(GetLoadSceneModes))]
		public LoadSceneMode LoadSceneMode;

		/// <summary>
		/// Scene to be targeted for scene loading
		/// </summary>
		[Tooltip("Scene to be targeted for scene loading")]
		[Scene]
		public string SceneName;

		private DropdownList<LoadSceneMode> GetLoadSceneModes()
		{
			return NTConstants.LoadSceneModes;
		}
	}
}
