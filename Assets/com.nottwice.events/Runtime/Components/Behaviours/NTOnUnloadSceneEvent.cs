using NotTwice.Proxies.Runtime.Interfaces;
using NotTwice.Proxies.Runtime;
using UnityEngine.SceneManagement;
using NotTwice.Events.Runtime.Serializables.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Behaviours
{
	[AddComponentMenu("NotTwice/Events/Behaviours/OnUnloadSceneEvent")]
	public class NTOnUnloadSceneEvent : NTGenericEventTypeSwitcher<NTSceneGameEvent, Scene>
	{
		private INTSceneManager _sceneManagerInternal;

		private INTSceneManager _sceneManager
		{
			get
			{
				if (_sceneManagerInternal == null)
				{
					_sceneManagerInternal = new NTSceneManagerProxy();
				}

				return _sceneManagerInternal;
			}
		}

		public void Awake()
		{
			_sceneManager.AddSceneUnloadedEvent(OnUnloadScene);
		}

		private void OnUnloadScene(Scene scene)
		{
			Raise(scene);
		}
	}
}
