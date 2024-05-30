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
		/// <returns>The Task <see cref="UniTask"/> resulting from the operation.</returns>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async UniTask ExecuteAsync(NTStringVariable sceneName)
		{
			await ExecuteAsync(sceneName.Value);
		}

		/// <summary>
		/// Method for unloading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneName">Scene name required to unload the scene</param>
		/// <returns>The Task <see cref="UniTask"/> resulting from the operation.</returns>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async UniTask ExecuteAsync(string sceneName)
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
