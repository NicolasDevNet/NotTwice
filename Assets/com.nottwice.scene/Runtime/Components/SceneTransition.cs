using UniRx.Triggers;
using UniRx;
using Assets.com.nottwice.scene.Runtime.ScriptableObjects;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using NaughtyAttributes;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.com.nottwice.scene.Runtime.Components
{
	/// <summary>
	/// Component for managing the transition scene
	/// </summary>
	[AddComponentMenu("NotTwice/Scene/SceneTransition")]
	[DisallowMultipleComponent]
	public class SceneTransition : MonoBehaviour
	{
		[Required, Tooltip("Animator used to play the transition animation.")]
		public Animator Animator;

		[Required, Tooltip("Variable used to retrieve scene selection.")]
		public StringVariable TargetSceneStorage;

		[Required, Tooltip("Variable that unloads the previous scene.")]
		public StringVariable PreviousSceneStorage;

		[Required, Tooltip("Transition scene configuration.")]
		public SceneTransitionConfiguration SceneTransitionConfiguration;

		[ReadOnly]
		[SerializeField]
		private bool _previousSceneWasUnloaded;

		[ReadOnly]
		[SerializeField]
		private bool _targetSceneIsLoaded;

		private IDisposable _loadingObserver;

		public void OnEnable()
		{
			_loadingObserver = this.UpdateAsObservable()
				.Where(_ => _previousSceneWasUnloaded && _targetSceneIsLoaded)
				.Subscribe(LoadingIsComplete, () => _loadingObserver.Dispose());
		}

		public void OnDisable()
		{
			_loadingObserver?.Dispose();
		}

		/// <summary>
		/// Method for asynchronously loading the target scene
		/// </summary>
		public void LoadTargetSceneAsync()
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Unloading of {PreviousSceneStorage.Value} started");

			SceneInstancesContainer.SceneManager.AddSceneUnloadedEvent(OnSceneUnloaded);

			SceneInstancesContainer.SceneManager.UnloadSceneAsync(PreviousSceneStorage.Value);

			SceneInstancesContainer.SceneManager.AddSceneLoadedEvent(OnSceneLoaded);

			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Loading of {TargetSceneStorage.Value} started");

			SceneInstancesContainer.SceneManager.LoadSceneAsync(TargetSceneStorage.Value, LoadSceneMode.Additive);
		}

		/// <summary>
		/// Method for asynchronously unloading the transition scene
		/// </summary>
		public void UnloadSceneSceneTransitionAsync()
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Unloading of {SceneTransitionConfiguration.SceneName} started");

			SceneInstancesContainer.SceneManager.RemoveSceneLoadedEvent(OnSceneLoaded);
			SceneInstancesContainer.SceneManager.RemoveSceneUnloadedEvent(OnSceneUnloaded);

			SceneInstancesContainer.SceneManager.UnloadSceneAsync(SceneTransitionConfiguration.SceneName);
		}

		#region Callbacks

		/// <summary>
		/// Callback method executed after loading the target scene
		/// </summary>
		private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
			if (scene.name == TargetSceneStorage.Value)
			{
				_targetSceneIsLoaded = true;
			}
		}

		/// <summary>
		/// Callback method executed after unloading the previous scene
		/// </summary>
		private void OnSceneUnloaded(Scene scene)
		{
			if (scene.name == PreviousSceneStorage.Value)
			{
				_previousSceneWasUnloaded = true;
			}
		}

		/// <summary>
		/// Callback method executed when the unloading of the previous scene and the loading of the target scene are completed.
		/// </summary>
		private void LoadingIsComplete(Unit unit)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, "Loading complete");
			Animator.SetBool(SceneTransitionConfiguration.ShowCurtainStateEndedName, true);
		}

		#endregion
	}
}
