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
        int SceneCount { get; }
        int SceneCountInBuildSettings { get; }

        void AddActiveSceneChangedEvent(UnityAction<Scene, Scene> unityAction);
        void AddSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction);
        void AddSceneUnloadedEvent(UnityAction<Scene> unityAction);
        Scene CreateScene(string sceneName);
        Scene CreateScene(string sceneName, CreateSceneParameters parameters);
        Scene GetActiveScene();
        Scene GetSceneAt(int index);
        Scene GetSceneByBuildIndex(int buildIndex);
        Scene GetSceneByBuildIndex(string name);
        Scene GetSceneByPath(string scenePath);
        void LoadScene(int sceneBuildIndex);
        void LoadScene(int sceneBuildIndex, LoadSceneMode loadSceneMode);
        void LoadScene(int sceneBuildIndex, LoadSceneParameters loadSceneParameters);
        void LoadScene(string sceneName);
        void LoadScene(string sceneName, LoadSceneMode loadSceneMode);
        void LoadScene(string sceneName, LoadSceneParameters loadSceneParameters);
        AsyncOperation LoadSceneAsync(int sceneBuildIndex);
        AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneMode loadSceneMode);
        AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneParameters loadSceneParameters);
        AsyncOperation LoadSceneAsync(string sceneName);
        AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode);
        AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters loadSceneParameters);
        void MergeScenes(Scene sourceScece, Scene destinationScene);
        void MoveGameObjectToScene(GameObject go, Scene destinationScene);
        void RemoveActiveSceneChangedEvent(UnityAction<Scene, Scene> unityAction);
        void RemoveSceneLoadedEvent(UnityAction<Scene, LoadSceneMode> unityAction);
        void RemoveSceneUnloadedEvent(UnityAction<Scene> unityAction);
        bool SetActiveScene(Scene scene);
        AsyncOperation UnloadSceneAsync(int sceneBuildIndex);
        AsyncOperation UnloadSceneAsync(int sceneBuildIndex, UnloadSceneOptions unloadSceneOptions);
        AsyncOperation UnloadSceneAsync(Scene scene);
        AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions unloadSceneOptions);
        AsyncOperation UnloadSceneAsync(string sceneName);
        AsyncOperation UnloadSceneAsync(string sceneName, UnloadSceneOptions unloadSceneOptions);
    }
}
