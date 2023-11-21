using System;
using UnityEngine;

namespace Assets.com.nottwice.application.Runtime.Proxies
{
	public class DefaultApplicationProxy : IApplication
	{
		private static DefaultApplicationProxy _instance;

		public static DefaultApplicationProxy Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DefaultApplicationProxy();
				}

				return _instance;
			}
		}

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
