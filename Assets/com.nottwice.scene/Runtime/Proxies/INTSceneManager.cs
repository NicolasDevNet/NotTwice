using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace NotTwice.Scene.Runtime.Proxies
{
	/// <summary>
	/// Stage management interface to be used for stage loading and unloading operations
	/// </summary>
	public interface INTSceneManager
	{
		void AddSceneLoadedEvent(UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> unityAction);
		void AddSceneUnloadedEvent(UnityAction<UnityEngine.SceneManagement.Scene> unityAction);
		AsyncOperation LoadSceneAsync(string sceneName);
		AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode);
		void RemoveSceneLoadedEvent(UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> unityAction);
		void RemoveSceneUnloadedEvent(UnityAction<UnityEngine.SceneManagement.Scene> unityAction);
		UnityEngine.SceneManagement.Scene GetActiveScene();
		AsyncOperation UnloadSceneAsync(string sceneName);
	}
}
