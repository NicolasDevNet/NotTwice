using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.scene.Runtime.Proxies;
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

		private ILogger _logger;
		private ISceneManager _sceneManager;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
			_sceneManager = AppContainer.Get<ISceneManager>();
		}

		public void Execute()
		{
			Execute(OptionalTargetScene);
		}

		public void Execute(SceneConfiguration targetScene)
		{
			_logger.Log(LogType.Log, $"Change scene to {targetScene.Name}");

			_sceneManager.UnloadSceneAsync(targetScene.Name);
		}
	}
}
