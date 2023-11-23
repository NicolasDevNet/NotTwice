using Assets.com.nottwice.scene.Runtime.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.com.nottwice.scene.Runtime.Components
{
	/// <summary>
	/// Component for asynchronous scene unloading
	/// </summary>
	[AddComponentMenu("NotTwice/Scene/UnloadSceneAsync")]
	[DisallowMultipleComponent]
	public class UnloadSceneAsync : MonoBehaviour
	{
		[Tooltip("Target scene when methods cannot be called with parameters")]
		public SceneConfiguration OptionalTargetScene;

		public void Execute()
		{
			Execute(OptionalTargetScene);
		}

		public void Execute(SceneConfiguration targetScene)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Change scene to {targetScene.Name}");

			SceneInstancesContainer.SceneManager.UnloadSceneAsync(targetScene.Name);
		}
	}
}
