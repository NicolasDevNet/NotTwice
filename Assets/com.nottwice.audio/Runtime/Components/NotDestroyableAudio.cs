using UnityEngine;

namespace Assets.com.nottwice.audio.Runtime.Components
{
	/// <summary>
	/// Component to persist an Audio component if it is the same across scenes
	/// </summary>
	[AddComponentMenu("NotTwice/Audio/NotDestroyableAudio")]
	[DisallowMultipleComponent]
	public class NotDestroyableAudio : MonoBehaviour
	{
		private static NotDestroyableAudio _instance;

		public AudioSource AudioSource { get; private set; }

		public void OnEnable()
		{
			//If there is no audio component, differentiation by audio source name is not possible.
			if (!TryGetComponent(out AudioSource component))
			{
				throw new MissingComponentException("The AudioSource component is missing from the gameobject.");
			}

			//If we have no instance, we take the current one by default
			if (_instance == null)
			{
				ApplicationInstancesContainer.Logger.Log(LogType.Log, "The first Audio instance is retained.");
				_instance = this;
				AudioSource = component;
				DontDestroyOnLoad(_instance);
			}
			else
			{
				//If an instance exists, we check if the new instance has a different music to play it or keep the old component.
				if (_instance.AudioSource.clip.name != component.clip.name)
				{
					ApplicationInstancesContainer.Logger.Log(LogType.Log, "The old Audio instance is replaced.");
					DestroyImmediate(_instance.gameObject);
					_instance = this;
					AudioSource = component;
				}
				else
				{
					ApplicationInstancesContainer.Logger.Log(LogType.Log, "The old Audio instance is retained.");
					DestroyImmediate(this.gameObject);
				}
			}
		}
	}
}
