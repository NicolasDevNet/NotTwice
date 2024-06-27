using NaughtyAttributes;
using NotTwice.Proxies.Runtime;
using NotTwice.Proxies.Runtime.Interfaces;
using NotTwice.Scene.Runtime.ScriptableObjects;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using System;
using UnityEngine;

namespace NotTwice.Scene.Runtime.Abstract
{
	/// <summary>
	/// Basic abstract class for classes that need to do scene management
	/// </summary>
	public abstract class NTBaseSceneHandler : ScriptableObject
	{
		/// <summary>
		/// Optional scene progress manager
		/// </summary>
		[Expandable ,Tooltip("Optional scene loading progress manager")]
		public NTBaseSceneProgressHandler ProgressHandler;

		private INTSceneManager _sceneManagerInternal;

		/// <summary>
		/// Scene manager used to perform scene operations, by default it is <see cref="NTDefaultSceneProxy"/>
		/// </summary>
		protected INTSceneManager _sceneManager
		{
			get
			{
				if (_sceneManagerInternal == null)
				{
					_sceneManagerInternal = new NTSceneManagerProxy();
				}

				return _sceneManagerInternal;
			}
			set
			{
				_sceneManagerInternal = value;
			}
		}

		/// <summary>
		/// Method for loading or unloading a scene asynchronously
		/// </summary>
		/// <param name="sceneName">Name of scene to load or unload</param>
		public abstract void ExecuteAsync(NTStringVariable sceneName);

		/// <summary>
		/// Method for loading or unloading a scene asynchronously
		/// </summary>
		/// <param name="sceneInput">Input to use for loading or unloading</param>
		public abstract void ExecuteAsync(NTScriptableSceneInput sceneInput);

		/// <summary>
		/// Method for loading or unloading a scene asynchronously
		/// </summary>
		/// <param name="sceneName">Name of scene to load or unload</param>
		public abstract void ExecuteAsync(string sceneName);

		public void ValidateSceneName(string sceneName)
		{
			if (string.IsNullOrWhiteSpace(sceneName))
			{
				throw new ArgumentNullException(nameof(sceneName));
			}
		}
	}
}
