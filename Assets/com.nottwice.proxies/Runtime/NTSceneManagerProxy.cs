using NotTwice.Proxies.Runtime.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace NotTwice.Proxies.Runtime
{
	/// <summary>
	/// Proxy acting as a flat pass for <see cref="SceneManager"/> static methods.
	/// <para>TODO: Complete implementation of all <see cref="SceneManager"/> methods. </para>
	/// </summary>
	public class NTSceneManagerProxy : INTSceneManager
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
