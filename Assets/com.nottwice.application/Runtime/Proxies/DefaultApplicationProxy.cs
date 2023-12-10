using System;
using UnityEngine;

namespace Assets.com.nottwice.application.Runtime.Proxies
{
	public class DefaultApplicationProxy : IApplication
	{
		public void OpenURL(string url)
		{
			Application.OpenURL(url);
		}

		public void Quit()
		{
			Application.Quit();
		}

		public string GetApplicationVersion()
		{
			return Application.version;
		}

		public void OnQuitApplication(Action onQuitApplication)
		{
			Application.quitting += onQuitApplication;
		}
	}
}
