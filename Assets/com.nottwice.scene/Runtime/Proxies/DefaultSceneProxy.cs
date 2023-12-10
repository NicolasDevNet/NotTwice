using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.com.nottwice.scene.Runtime.Proxies
{
	public class DefaultSceneProxy : ISceneManager
	{
		public AsyncOperation LoadSceneAsync(string sceneName)
		{
			return SceneManager.LoadSceneAsync(sceneName);
		}

		public AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
		{
			return SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
		}

		public AsyncOperation UnloadSceneAsync(string sceneName)
		{
			return SceneManager.UnloadSceneAsync(sceneName);
		}

		public void AddSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction)
		{
			SceneManager.sceneLoaded += unityAction;
		}

		public void RemoveSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction)
		{
			SceneManager.sceneLoaded -= unityAction;
		}

		public void AddSceneUnloadedEvent(UnityAction<Scene> unityAction)
		{
			SceneManager.sceneUnloaded += unityAction;
		}

		public void RemoveSceneUnloadedEvent(UnityAction<Scene> unityAction)
		{
			SceneManager.sceneUnloaded -= unityAction;
		}

		public Scene GetActiveScene()
		{
			return SceneManager.GetActiveScene();
		}
	}
}
