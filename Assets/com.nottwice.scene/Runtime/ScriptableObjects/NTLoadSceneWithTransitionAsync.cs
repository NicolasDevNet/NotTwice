using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using NotTwice.Proxies.Runtime;
using NotTwice.Scene.Runtime.Abstract;
using NotTwice.Scene.Runtime.Serializables;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotTwice.Scene.Runtime.ScriptableObjects
{
	/// <summary>
	/// Scriptable service object for asynchronous scene loading with a scene transition
	/// </summary>
	[CreateAssetMenu(fileName = "LoadSceneWithTransitionAsync", menuName = "NotTwice/Scene/Services/LoadSceneWithTransitionAsync")]
	public class NTLoadSceneWithTransitionAsync : NTBaseLoadScene
	{
		/// <summary>
		/// Indicates whether the target scene should be loaded automatically at the end of loading, or whether it should be loaded by the user
		/// </summary>
		[Tooltip("Indicates whether the target scene should be loaded automatically at the end of loading, or whether it should be loaded by the user")]
		public bool AutoLoadTargetScene;

		/// <summary>
		/// Transition scene required to make the transition
		/// </summary>
		[Tooltip("Transition scene required to make the transition")]
		public NTSerializableSceneInput TransitionScene;

		/// <summary>
		/// Previous scene to be unloaded
		/// </summary>
		[ReadOnly, Tooltip("Previous scene to be unloaded")]
		public string PreviousScene;

		/// <summary>
		/// Indicator showing that the transition scene is loaded
		/// </summary>
		[ReadOnly, Tooltip("Indicator showing that the transition scene is loaded")]
		public bool TransitionSceneLoaded;

		/// <summary>
		/// Indicator showing that the previous scene is unloaded
		/// </summary>
		[ReadOnly, Tooltip("Indicator showing that the previous scene is unloaded")]
		public bool PreviousSceneUnloaded;

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// <para>The loading mode for this method is <see cref="LoadSceneMode.Single"/> by default</para>
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene with a scene transition</param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync(NTStringVariable sceneName)
		{
			ExecuteAsync(sceneName.Value, LoadSceneMode.Single);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneInput">Input to use for loading or unloading</param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync(NTScriptableSceneInput sceneInput)
		{
			ExecuteAsync(sceneInput.SceneName, sceneInput.LoadSceneMode);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// <para>The loading mode for this method is <see cref="LoadSceneMode.Single"/> by default</para>
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene with a scene transition</param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync(string sceneName)
		{
			ExecuteAsync(sceneName, LoadSceneMode.Single);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// <para>The loading mode for this method is <see cref="LoadSceneMode.Single"/> by default</para>
		/// </summary>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync()
		{
			ExecuteAsync(TargetScene.Value, LoadSceneMode.Single);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene with a scene transition</param>
		/// <param name="loadSceneMode">Scene loading method <see cref="LoadSceneMode"/></param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync(string sceneName, LoadSceneMode loadSceneMode)
		{
			ExecuteAsync(new NTSerializableSceneInput()
			{
				SceneName = sceneName,
				LoadSceneMode = loadSceneMode
			});
		}

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneInput">Information required to load the scene <see cref="NTSerializableSceneInput"/></param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async void ExecuteAsync(NTSerializableSceneInput sceneInput)
		{
			ValidateSceneInput(sceneInput);

			ValidateSceneInput(TransitionScene);

			PreviousScene = NTProxiesProvider.SceneManager.GetActiveScene().name;

			TargetScene = sceneInput.SceneName;

			if(AutoLoadTargetScene)
			{
				AddListeners();
			}

			Debug.Log($"Load transition scene {TransitionScene.SceneName} asynchronously with a {TransitionScene.LoadSceneMode} mode");

			//Loading transition scene
			await NTProxiesProvider.SceneManager.LoadSceneAsync(TransitionScene.SceneName, TransitionScene.LoadSceneMode);
		}

		/// <summary>
		/// Method for loading the target scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		public async void LoadTargetScene()
		{
			Debug.Log($"Load scene {TargetScene} asynchronously with a {LoadSceneMode.Single} mode");

			AsyncOperation loadOperation = NTProxiesProvider.SceneManager.LoadSceneAsync(TargetScene, LoadSceneMode.Single);

			TargetScene = string.Empty;
			PreviousScene = string.Empty;

			if (ProgressHandler == null)
			{
				await loadOperation;
			}
			else
			{
				await loadOperation.ToUniTask(progress: Progress.Create<float>(ProgressHandler.OnProgress));
			}
		}

		private void OnTransitionSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode loadSceneMode)
		{
			TransitionSceneLoaded = true;

			Debug.Log($"Transition scene {TransitionScene.SceneName} is loaded");

			if (PreviousSceneUnloaded && TransitionSceneLoaded)
			{
				PreviousSceneUnloaded = false;
				TransitionSceneLoaded = false;

				RemoveListeners();

				LoadTargetScene();
			}
		}

		private void OnPreviousSceneUnloaded(UnityEngine.SceneManagement.Scene scene)
		{
			PreviousSceneUnloaded = true;

			Debug.Log($"Previous scene {PreviousScene} was unloaded");

			if (PreviousSceneUnloaded && TransitionSceneLoaded)
			{
				PreviousSceneUnloaded = false;
				TransitionSceneLoaded = false;

				RemoveListeners();

				LoadTargetScene();
			}
		}

		private void RemoveListeners()
		{
            NTProxiesProvider.SceneManager.RemoveSceneLoadedEvent(OnTransitionSceneLoaded);
            NTProxiesProvider.SceneManager.RemoveSceneUnloadedEvent(OnPreviousSceneUnloaded);
		}

		private void AddListeners()
		{
            NTProxiesProvider.SceneManager.AddSceneLoadedEvent(OnTransitionSceneLoaded);
            NTProxiesProvider.SceneManager.AddSceneUnloadedEvent(OnPreviousSceneUnloaded);
		}
	}
}
