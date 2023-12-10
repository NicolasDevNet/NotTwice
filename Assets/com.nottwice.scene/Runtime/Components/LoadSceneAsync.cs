using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.scene.Runtime.Proxies;
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

		[Tooltip("Load scene mode when methods cannot be called with parameters")]
		public LoadSceneMode LoadSceneMode;

		protected ILogger _logger;
		protected ISceneManager _sceneManager;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
			_sceneManager = AppContainer.Get<ISceneManager>();
		}

		public void Execute()
		{
			Execute(OptionalTargetScene, LoadSceneMode);
		}

		public void Execute(SceneConfiguration targetScene, LoadSceneMode loadSceneMode)
		{
			_logger.Log(LogType.Log, $"Change scene to {targetScene.Name}");

			_sceneManager.LoadSceneAsync(targetScene.Name, loadSceneMode);
		}
	}
}
