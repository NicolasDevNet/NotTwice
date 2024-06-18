using System;

namespace NotTwice.Components.Runtime.Proxies
{
    /// <summary>
    /// Interface providing management methods for a Unity application
    /// </summary>
    public interface INTApplication
	{
		string GetApplicationVersion();
		string GetPersistentDataPath();
		void OnQuitApplication(Action onQuitApplication);

		void OpenURL(string url);

		void Quit();
	}
}
