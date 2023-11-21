using System;

namespace Assets.com.nottwice.application.Runtime.Proxies
{
	public interface IApplication
	{
		string GetApplicationVersion();

		void OnQuitApplication(Action onQuitApplication);

		void OpenURL(string url);

		void Quit();
	}
}
