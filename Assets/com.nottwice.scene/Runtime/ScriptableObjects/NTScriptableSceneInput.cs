using NaughtyAttributes;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace NotTwice.Scene.Runtime.ScriptableObjects
{
	/// <summary>
	/// Scriptable objet permettant de paramétrer une gestion de scène qui pourra être utilisée dans les services <see cref="NTLoadSceneAsync"/>, <see cref="NTLoadSceneWithTransitionAsync"/> or <see cref="NTUnloadSceneAsync"/>
	/// </summary>
	[CreateAssetMenu(fileName = "NTScriptableSceneInput", menuName = "NotTwice/Scene/Inputs/ScriptableSceneInput")]
	public class NTScriptableSceneInput : ScriptableObject
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
			return Constants.LoadSceneModes;
		}
	}
}
