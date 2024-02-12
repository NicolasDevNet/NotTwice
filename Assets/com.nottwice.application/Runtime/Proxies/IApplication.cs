using System;

namespace Assets.com.nottwice.application.Runtime.Proxies
{
	public interface IApplication
	{
		string GetApplicationVersion();
		string GetPersistentDataPath();
		void OnQuitApplication(Action onQuitApplication);

		void OpenURL(string url);

		void Quit();
	}
}
