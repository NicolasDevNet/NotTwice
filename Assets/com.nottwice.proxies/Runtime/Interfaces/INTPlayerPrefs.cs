namespace NotTwice.Proxies.Runtime.Interfaces
{
    /// <summary>
    /// Interface contract outlining methods to be defined for saving information in a user preference system
    /// </summary>
    public interface INTPlayerPrefs
    {
        /// <summary>
        /// Method for deleting all user preference keys
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Method for deleting a user preference by its key
        /// </summary>
        void DeleteKey(string key);

        /// <summary>
        /// Method for retrieving a float value from a key
        /// </summary>
        float GetFloat(string key);

        /// <summary>
        /// Method for retrieving a float value from a key,
        /// returns a default value if it doesn't exist
        /// </summary>
        float GetFloat(string key, float defaultValue);

        /// <summary>
        /// Method for retrieving an integer value from a key
        /// </summary>
        int GetInt(string key);

        /// <summary>
        /// Method for retrieving an integer value from a key,
        /// returns a default value if it doesn't exist
        /// </summary>
        int GetInt(string key, int defaultValue);

        /// <summary>
        /// Method for retrieving a string value from a key
        /// </summary>
        string GetString(string key);

        /// <summary>
        /// Method for retrieving a string value from a key,
        /// returns a default value if it doesn't exist
        /// </summary>
        string GetString(string key, string defaultValue);

        /// <summary>
        /// Method for checking whether a key exists or not
        /// </summary>
        bool HasKey(string key);

        /// <summary>
        /// Method for saving changes
        /// </summary>
        void Save();

        /// <summary>
        /// Method for defining a float value for a key
        /// </summary>
        void SetFloat(string key, float value);

        /// <summary>
        /// Method for defining an int value for a key
        /// </summary>
        void SetInt(string key, int value);

        /// <summary>
        /// Method for defining a string value for a key
        /// </summary>
        void SetString(string key, string value);
    }
}
