using Assets.com.nottwice.scene.Runtime.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.com.nottwice.scene.Runtime.Components
{
	/// <summary>
	/// Component for asynchronous scene loading
	/// </summary>
	[AddComponentMenu("NotTwice/Scene/LoadSceneAsync")]
	[DisallowMultipleComponent]
	public class LoadSceneAsync : MonoBehaviour
	{
		[Tooltip("Target scene when methods cannot be called with parameters")]
		public SceneConfiguration OptionalTargetScene;

		public void Execute()
		{
			Execute(OptionalTargetScene, LoadSceneMode.Single);
		}

		public void Execute(SceneConfiguration targetScene, LoadSceneMode loadSceneMode)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Change scene to {targetScene.Name}");

			SceneInstancesContainer.SceneManager.LoadSceneAsync(targetScene.Name, loadSceneMode);
		}
	}
}
