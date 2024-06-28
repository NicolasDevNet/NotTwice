using NotTwice.Proxies.Runtime.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace NotTwice.Proxies.Runtime
{
	/// <summary>
	/// Proxy acting as a flat pass for <see cref="SceneManager"/> static methods.
	/// </summary>
	public class NTSceneManagerProxy : INTSceneManager
	{
        /// <summary>
        /// The total number of currently loaded Scenes.
        /// </summary>
        public int SceneCount
        {
			get
			{
				return SceneManager.sceneCount;
			}
		}

        /// <summary>
        /// Number of Scenes in Build Settings.
        /// </summary>
        public int SceneCountInBuildSettings
        {
            get
            {
                return SceneManager.sceneCountInBuildSettings;
            }
        }

        public Scene CreateScene(string sceneName)
        {
            return SceneManager.CreateScene(sceneName);
        }

        public Scene CreateScene(string sceneName, CreateSceneParameters parameters)
        {
            return SceneManager.CreateScene(sceneName, parameters);
        }

        public Scene GetActiveScene()
        {
            return SceneManager.GetActiveScene();
        }

        public Scene GetSceneAt(int index)
        {
            return SceneManager.GetSceneAt(index);
        }

        public Scene GetSceneByBuildIndex(int buildIndex)
        {
            return SceneManager.GetSceneByBuildIndex(buildIndex);
        }

        public Scene GetSceneByBuildIndex(string name)
        {
            return SceneManager.GetSceneByName(name);
        }

        public Scene GetSceneByPath(string scenePath)
        {
            return SceneManager.GetSceneByPath(scenePath);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadScene(sceneName, loadSceneMode);
        }

        public void LoadScene(int sceneBuildIndex, LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadScene(sceneBuildIndex, loadSceneMode);
        }

        public void LoadScene(string sceneName, LoadSceneParameters loadSceneParameters)
        {
            SceneManager.LoadScene(sceneName, loadSceneParameters);
        }

        public void LoadScene(int sceneBuildIndex, LoadSceneParameters loadSceneParameters)
        {
            SceneManager.LoadScene(sceneBuildIndex, loadSceneParameters);
        }

        public void LoadScene(int sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }

        public AsyncOperation LoadSceneAsync(string sceneName)
		{
			return SceneManager.LoadSceneAsync(sceneName);
		}

		public AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
		{
			return SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
		}

        public AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters loadSceneParameters)
        {
            return SceneManager.LoadSceneAsync(sceneName, loadSceneParameters);
        }

        public AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneParameters loadSceneParameters)
        {
            return SceneManager.LoadSceneAsync(sceneBuildIndex, loadSceneParameters);
        }

        public AsyncOperation LoadSceneAsync(int sceneBuildIndex)
        {
            return SceneManager.LoadSceneAsync(sceneBuildIndex);
        }

        public AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneMode loadSceneMode)
        {
            return SceneManager.LoadSceneAsync(sceneBuildIndex, loadSceneMode);
        }

        public AsyncOperation UnloadSceneAsync(string sceneName)
		{
			return SceneManager.UnloadSceneAsync(sceneName);
		}

        public AsyncOperation UnloadSceneAsync(string sceneName, UnloadSceneOptions unloadSceneOptions)
        {
            return SceneManager.UnloadSceneAsync(sceneName, unloadSceneOptions);
        }

        public AsyncOperation UnloadSceneAsync(Scene scene)
        {
            return SceneManager.UnloadSceneAsync(scene);
        }

        public AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions unloadSceneOptions)
        {
            return SceneManager.UnloadSceneAsync(scene, unloadSceneOptions);
        }

        public AsyncOperation UnloadSceneAsync(int sceneBuildIndex, UnloadSceneOptions unloadSceneOptions)
        {
            return SceneManager.UnloadSceneAsync(sceneBuildIndex, unloadSceneOptions);
        }

        public AsyncOperation UnloadSceneAsync(int sceneBuildIndex)
        {
            return SceneManager.UnloadSceneAsync(sceneBuildIndex);
        }

        public void MergeScenes(Scene sourceScece, Scene destinationScene)
        {
            SceneManager.MergeScenes(sourceScece, destinationScene);
        }

        public void MoveGameObjectToScene(GameObject go, Scene destinationScene)
        {
            SceneManager.MoveGameObjectToScene(go, destinationScene);
        }

        public bool SetActiveScene(Scene scene)
        {
            return SceneManager.SetActiveScene(scene);
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

        public void AddActiveSceneChangedEvent(UnityAction<Scene, Scene> unityAction)
        {
            SceneManager.activeSceneChanged += unityAction;
        }

        public void RemoveActiveSceneChangedEvent(UnityAction<Scene, Scene> unityAction)
        {
            SceneManager.activeSceneChanged -= unityAction;
        }
    }
}
