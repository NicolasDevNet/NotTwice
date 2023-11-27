using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.com.nottwice.audio.Runtime.Extentions
{
	public static class AudioMixerExtentions
	{
		/// <summary>
		/// An extension method for calculating a value from 0 to 100 in decibels before feeding it to the audio mixer.
		/// </summary>
		public static void SetFloatFromMaxHundredToDb(this AudioMixer audioMixer, string exposedParamterName, float maxHundredValue)
		{
			if(audioMixer == null)
			{
				throw new ArgumentNullException(nameof(audioMixer));
            }

			if(maxHundredValue < 0 || maxHundredValue > 100)
			{
				throw new InvalidOperationException($"The value provided must be between 0 (includes) and 100 (includes), the current value is: {maxHundredValue}");
			}

			float dbValue = maxHundredValue == 0 ? -40.0f : 20.0f * Mathf.Log10(maxHundredValue / 100);

			audioMixer.SetFloat(exposedParamterName, dbValue);
		}
	}
}
