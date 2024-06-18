
using NotTwice.Scene.Runtime.Serializables;
using System;
using UnityEngine.SceneManagement;

namespace NotTwice.Scene.Runtime.Abstract
{
	/// <summary>
	/// Basic abstract class for classes that need to do scene loading
	/// </summary>
	public abstract class NTBaseLoadScene : NTBaseSceneHandler
	{
		/// <summary>
		/// Method for loading a scene asynchronously
		/// </summary>
		/// <param name="sceneName">Name of scene to load</param>
		/// <param name="loadSceneMode">Scene loading mode</param>
		public abstract void ExecuteAsync(string sceneName, LoadSceneMode loadSceneMode);

		/// <summary>
		/// Method for loading a scene asynchronously
		/// </summary>
		/// <param name="sceneInput">Scene information required for loading</param>
		public abstract void ExecuteAsync(NTSerializableSceneInput sceneInput);

		/// <summary>
		/// Method for checking the validity of scene input
		/// </summary>
		/// <param name="sceneInput">The body to be checked</param>
		/// <exception cref="ArgumentNullException">Exception thrown when instance or scene name is null</exception>
		public void ValidateSceneInput(NTSerializableSceneInput sceneInput)
		{
			if (sceneInput == null)
			{
				throw new ArgumentNullException(nameof(sceneInput));
			}

			ValidateSceneName(sceneInput.SceneName);
		}
	}
}
