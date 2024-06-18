using System;

namespace NotTwice.Components.Runtime.Proxies
{
    /// <summary>
    /// Default proxy using the methods of <see cref="UnityEngine.Application"/>
    /// </summary>
    public class NTDefaultApplicationProxy : INTApplication
	{
		public void OpenURL(string url)
		{
            UnityEngine.Application.OpenURL(url);
		}

		public void Quit()
		{
            UnityEngine.Application.Quit();
		}

		public string GetApplicationVersion()
		{
			return UnityEngine.Application.version;
		}

		public string GetPersistentDataPath()
		{
			return UnityEngine.Application.persistentDataPath;
		}

		public void OnQuitApplication(Action onQuitApplication)
		{
			UnityEngine.Application.quitting += onQuitApplication;
		}
	}
}
