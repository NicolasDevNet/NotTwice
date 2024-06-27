using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace NotTwice.Proxies.Runtime.Interfaces
{
	/// <summary>
	/// Interface contract outlining methods to be defined for scene operations
	/// </summary>
	public interface INTSceneManager
	{
		void AddSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction);
		void AddSceneUnloadedEvent(UnityAction<Scene> unityAction);
		Scene GetActiveScene();
		AsyncOperation LoadSceneAsync(string sceneName);
		AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode);
		void RemoveSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction);
		void RemoveSceneUnloadedEvent(UnityAction<Scene> unityAction);
		AsyncOperation UnloadSceneAsync(string sceneName);
	}
}
