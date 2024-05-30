using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Scene.Runtime.Proxies
{
	/// <summary>
	/// Proxy for the SceneManager, making the code that depends on it testable
	/// </summary>
	public class NTDefaultSceneProxy : INTSceneManager
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

		public void AddSceneLoadedEvent(UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> unityAction)
		{
			SceneManager.sceneLoaded += unityAction;
		}

		public void RemoveSceneLoadedEvent(UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> unityAction)
		{
			SceneManager.sceneLoaded -= unityAction;
		}

		public void AddSceneUnloadedEvent(UnityAction<UnityEngine.SceneManagement.Scene> unityAction)
		{
			SceneManager.sceneUnloaded += unityAction;
		}

		public void RemoveSceneUnloadedEvent(UnityAction<UnityEngine.SceneManagement.Scene> unityAction)
		{
			SceneManager.sceneUnloaded -= unityAction;
		}

		public UnityEngine.SceneManagement.Scene GetActiveScene()
		{
			return SceneManager.GetActiveScene();
		}
	}
}
