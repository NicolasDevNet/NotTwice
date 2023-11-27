using UnityEngine;

namespace Assets.com.nottwice.data.Runtime.Proxies
{
	public class DefaultPlayerPrefsProxy : IPlayerPrefs
	{
		private static DefaultPlayerPrefsProxy _instance;

		public static DefaultPlayerPrefsProxy Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DefaultPlayerPrefsProxy();
				}

				return _instance;
			}
		}

		public void SetString(string key, string value)
		{
			PlayerPrefs.SetString(key, value);
		}

		public void SetFloat(string key, float value)
		{
			PlayerPrefs.SetFloat(key, value);
		}

		public void SetInt(string key, int value)
		{
			PlayerPrefs.SetInt(key, value);
		}

		public string GetString(string key)
		{
			return PlayerPrefs.GetString(key);
		}

		public float GetFloat(string key)
		{
			return PlayerPrefs.GetFloat(key);
		}

		public int GetInt(string key)
		{
			return PlayerPrefs.GetInt(key);
		}

		public bool HasKey(string key)
		{
			return PlayerPrefs.HasKey(key);
		}

		public void DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(key);
		}

		public void DeleteAll()
		{
			PlayerPrefs.DeleteAll();
		}

		public void Save()
		{
			PlayerPrefs.Save();
		}
	}
}
