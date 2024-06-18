using Cysharp.Threading.Tasks;
using NotTwice.Scene.Runtime.Abstract;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using System;
using UnityEngine;

namespace NotTwice.Scene.Runtime.ScriptableObjects
{
	/// <summary>
	/// Scriptable service object for asynchronous scene unloading
	/// </summary>
	[CreateAssetMenu(fileName = "UnloadSceneAsync", menuName = "NotTwice/Scene/Services/UnloadSceneAsync")]
	public class NTUnloadSceneAsync : NTBaseSceneHandler
	{
		/// <summary>
		/// Method for unloading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneName">Scene name required to unload the scene</param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync(NTStringVariable sceneName)
		{
			ExecuteAsync(sceneName.Value);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneInput">Input to use for loading or unloading</param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync(NTScriptableSceneInput sceneInput)
		{
			ExecuteAsync(sceneInput.SceneName);
		}

		/// <summary>
		/// Method for unloading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneName">Scene name required to unload the scene</param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async void ExecuteAsync(string sceneName)
		{
			Debug.Log($"Unload scene {sceneName} asynchronously");

			ValidateSceneName(sceneName);

			AsyncOperation loadOperation = _sceneManager.UnloadSceneAsync(sceneName);

			if (ProgressHandler == null)
			{
				await loadOperation;
			}
			else
			{
				await loadOperation.ToUniTask(progress: Progress.Create<float>(ProgressHandler.OnProgress));
			}
		}
	}
}
