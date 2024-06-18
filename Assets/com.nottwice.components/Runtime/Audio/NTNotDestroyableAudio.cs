using UnityEngine;

namespace NotTwice.Components.Runtime.Audio
{
	/// <summary>
	/// Component to persist an Audio component if it is the same across scenes
	/// </summary>
	[AddComponentMenu("NotTwice/Audio/NotDestroyableAudio")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(AudioSource))]
	public class NTNotDestroyableAudio : MonoBehaviour
	{
		public static NTNotDestroyableAudio Instance { get; private set; }

		public AudioSource AudioSource { get; private set; }

		public void OnEnable()
		{
            AudioSource component = GetComponent<AudioSource>();

            //If we have no instance, we take the current one by default
            if (Instance == null)
			{
				Debug.Log("The first Audio instance is retained.");
                Instance = this;
				AudioSource = component;
				DontDestroyOnLoad(Instance);
			}
			else
			{
				//If an instance exists, we check if the new instance has a different music to play it or keep the old component.
				if (Instance.AudioSource.clip.name != component.clip.name)
				{
					Debug.Log("The old Audio instance is replaced.");
					DestroyImmediate(Instance.gameObject);
					Instance = this;
					AudioSource = component;
				}
				else
				{
					Debug.Log("The old Audio instance is retained.");
					DestroyImmediate(this.gameObject);
				}
			}
		}
	}
}
