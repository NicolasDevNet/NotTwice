using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.com.nottwice.scene.Runtime.Proxies
{
	public interface ISceneManager
	{
		void AddSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction);
		void AddSceneUnloadedEvent(UnityAction<Scene> unityAction);
		AsyncOperation LoadSceneAsync(string sceneName);
		AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode);
		void RemoveSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction);
		void RemoveSceneUnloadedEvent(UnityAction<Scene> unityAction);
		Scene GetActiveScene();
		AsyncOperation UnloadSceneAsync(string sceneName);
	}
}
