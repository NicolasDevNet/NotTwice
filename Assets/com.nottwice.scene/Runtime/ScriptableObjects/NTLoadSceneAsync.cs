using Cysharp.Threading.Tasks;
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
	/// Scriptable service object for asynchronous scene loading
	/// </summary>
	[CreateAssetMenu(fileName = "LoadSceneAsync", menuName = "NotTwice/Scene/Services/LoadSceneAsync")]
	public class NTLoadSceneAsync : NTBaseLoadScene
	{
		/// <summary>
		/// Method for loading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// <para>The loading mode for this method is <see cref="LoadSceneMode.Single"/> by default</para>
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene</param>
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
		/// Method for loading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// <para>The loading mode for this method is <see cref="LoadSceneMode.Single"/> by default</para>
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene</param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override void ExecuteAsync(string sceneName)
		{
			ExecuteAsync(sceneName, LoadSceneMode.Single);
		}

		/// <summary>
		/// Method for loading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneName">Scene name required to load the scene</param>
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
		/// Method for loading a scene asynchronously, possibly taking into account an operation progress manager <see cref="IProgress{T}"/>.
		/// </summary>
		/// <param name="sceneInput">Information required to load the scene <see cref="NTSerializableSceneInput"/></param>
		/// <exception cref="ArgumentNullException">Exception lifted if information not supplied</exception>
		public override async void ExecuteAsync(NTSerializableSceneInput sceneInput)
		{
			ValidateSceneInput(sceneInput);

			Debug.Log($"Load scene {sceneInput.SceneName} asynchronously with a {sceneInput.LoadSceneMode} mode");

			AsyncOperation loadOperation = NTProxiesProvider.SceneManager.LoadSceneAsync(sceneInput.SceneName, sceneInput.LoadSceneMode);

			if(ProgressHandler == null)
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
