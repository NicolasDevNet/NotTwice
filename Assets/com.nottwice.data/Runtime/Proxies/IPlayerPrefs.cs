namespace Assets.com.nottwice.data.Runtime.Proxies
{
	public interface IPlayerPrefs
	{
		void DeleteAll();
		void DeleteKey(string key);
		float GetFloat(string key);
		int GetInt(string key);
		string GetString(string key);
		void HasKey(string key);
		void Save();
		void SetFloat(string key, float value);
		void SetInt(string key, int value);
		void SetString(string key, string value);
	}
}
