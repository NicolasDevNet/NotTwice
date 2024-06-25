using NotTwice.Proxies.Runtime.Interfaces;
using UnityEngine;

namespace NotTwice.Proxies.Runtime
{
    /// <summary>
    /// Proxy acting as a flat pass for <see cref="PlayerPrefs"/> static methods.
    /// </summary>
    public class NTPlayerPrefsProxy : INTPlayerPrefs
    {
        /// <summary>
        /// Removes all keys and values from the preferences. Use with caution.
        /// </summary>
		public void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        /// <summary>
        /// Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey has no impact.
        /// </summary>
        public void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        /// <summary>
        /// Returns true if the given key exists in PlayerPrefs, otherwise returns false.
        /// </summary>
        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        /// <summary>
        /// Saves all modified preferences.
        /// </summary>
        public void Save()
        {
            PlayerPrefs.Save();
        }

        #region Get

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public int GetInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public int GetInt(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public string GetString(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public string GetString(string key, string defaultValue)
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public float GetFloat(string key, float defaultValue)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public float GetFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }

        #endregion

        #region Set

        /// <summary>
        /// Sets a single integer value for the preference identified by the given key. You
        /// can use PlayerPrefs.GetInt to retrieve this value.
        /// </summary>
        public void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        /// <summary>
        /// Sets a single string value for the preference identified by the given key. You
        /// can use PlayerPrefs.GetString to retrieve this value.
        /// </summary>
        public void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        /// <summary>
        /// Sets the float value of the preference identified by the given key. You can use
        /// PlayerPrefs.GetFloat to retrieve this value.
        /// </summary>
        public void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        #endregion
    }
}
