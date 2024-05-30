using Assets.com.nottwice.application.Runtime.Proxies;
using UnityEngine;

namespace Assets.com.nottwice.application.Runtime.Components
{
	/// <summary>
	/// Component used to exit the application.
	/// </summary>
	[AddComponentMenu("NotTwice/Application/QuitApplication")]
	[DisallowMultipleComponent]
	public class QuitApplication : MonoBehaviour
	{
		private IApplication _applicationInternal;

		private IApplication _application
		{
			get
			{
				if (_applicationInternal == null)
				{
					_applicationInternal = new DefaultApplicationProxy();
				}

				return _applicationInternal;
			}
			set
			{
				_applicationInternal = value;
			}
		}

		public void ExecuteQuitApplication()
		{
			Debug.Log("Try to quit application");
			_application.Quit();
		}
	}
}
