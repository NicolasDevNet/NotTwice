using Cysharp.Threading.Tasks;
using NaughtyAttributes;
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
		[Required, Tooltip("Transition scene required to make the transition")]
		public NTLoadSceneInput TransitionScene;

		/// <summary>
		/// Previous scene to be unloaded
		/// </summary>
		[ReadOnly, Tooltip("Previous scene to be unloaded")]
		public string PreviousScene;

		/// <summary>
		/// Previous scene to be loaded
		/// </summary>
		[ReadOnly, Tooltip("Previous scene to be loaded")]
		public string TargetScene;

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
		/// <returns>The Task <see cref="UniTask"/> resulting from the operation.</returns>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async UniTask ExecuteAsync(NTStringVariable sceneName)
		{
			await ExecuteAsync(sceneName.Value, LoadSceneMode.Single);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// <para>The loading mode for this method is <see cref="LoadSceneMode.Single"/> by default</para>
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene with a scene transition</param>
		/// <returns>The Task <see cref="UniTask"/> resulting from the operation.</returns>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async UniTask ExecuteAsync(string sceneName)
		{
			await ExecuteAsync(sceneName, LoadSceneMode.Single);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene with a scene transition</param>
		/// <param name="loadSceneMode">Scene loading method <see cref="LoadSceneMode"/></param>
		/// <returns>The Task <see cref="UniTask"/> resulting from the operation.</returns>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async UniTask ExecuteAsync(string sceneName, LoadSceneMode loadSceneMode)
		{
			await ExecuteAsync(new NTLoadSceneInput()
			{
				SceneName = sceneName,
				LoadSceneMode = loadSceneMode
			});
		}

		/// <summary>
		/// Method for loading a scene asynchronously, with automatic loading of the targeted scene and possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneInput">Information required to load the scene <see cref="NTLoadSceneInput"/></param>
		/// <returns>The Task <see cref="UniTask"/> resulting from the operation.</returns>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async UniTask ExecuteAsync(NTLoadSceneInput sceneInput)
		{
			ValidateSceneInput(sceneInput);

			ValidateSceneInput(TransitionScene);

			PreviousScene = _sceneManager.GetActiveScene().name;

			TargetScene = sceneInput.SceneName;

			if(AutoLoadTargetScene)
			{
				AddListeners();
			}

			Debug.Log($"Load transition scene {TransitionScene.SceneName} asynchronously with a {TransitionScene.LoadSceneMode} mode");

			//Loading transition scene
			await _sceneManager.LoadSceneAsync(TransitionScene.SceneName, TransitionScene.LoadSceneMode);
		}

		/// <summary>
		/// Method for loading the target scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <returns>The Task <see cref="UniTask"/> resulting from the operation.</returns>
		public async UniTask LoadTargetScene()
		{
			Debug.Log($"Load scene {TargetScene} asynchronously with a {LoadSceneMode.Single} mode");

			AsyncOperation loadOperation = _sceneManager.LoadSceneAsync(TargetScene, LoadSceneMode.Single);

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

		private async void OnTransitionSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode loadSceneMode)
		{
			TransitionSceneLoaded = true;

			Debug.Log($"Transition scene {TransitionScene.SceneName} is loaded");

			if (PreviousSceneUnloaded && TransitionSceneLoaded)
			{
				PreviousSceneUnloaded = false;
				TransitionSceneLoaded = false;

				RemoveListeners();

				await LoadTargetScene();
			}
		}

		private async void OnPreviousSceneUnloaded(UnityEngine.SceneManagement.Scene scene)
		{
			PreviousSceneUnloaded = true;

			Debug.Log($"Previous scene {PreviousScene} was unloaded");

			if (PreviousSceneUnloaded && TransitionSceneLoaded)
			{
				PreviousSceneUnloaded = false;
				TransitionSceneLoaded = false;

				RemoveListeners();

				await LoadTargetScene();
			}
		}

		private void RemoveListeners()
		{
			_sceneManager.RemoveSceneLoadedEvent(OnTransitionSceneLoaded);
			_sceneManager.RemoveSceneUnloadedEvent(OnPreviousSceneUnloaded);
		}

		private void AddListeners()
		{
			_sceneManager.AddSceneLoadedEvent(OnTransitionSceneLoaded);
			_sceneManager.AddSceneUnloadedEvent(OnPreviousSceneUnloaded);
		}
	}
}
