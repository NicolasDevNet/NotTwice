using NotTwice.Proxies.Runtime;
using NotTwice.Proxies.Runtime.Interfaces;
using UnityEngine;

namespace NotTwice.Components.Runtime.Application
{
	/// <summary>
	/// Component used to exit the application.
	/// </summary>
	[AddComponentMenu("NotTwice/Application/QuitApplication")]
	[DisallowMultipleComponent]
	public class NTQuitApplication : MonoBehaviour
	{
		private INTApplication _applicationInternal;

		public INTApplication Application
		{
			private get
			{
				if (_applicationInternal == null)
				{
					_applicationInternal = new NTApplicationProxy();
				}

				return _applicationInternal;
			}
			set
			{
				_applicationInternal = value;
			}
		}

        /// <summary>
        /// Exit method
        /// </summary>
        public void ExecuteQuitApplication()
		{
			Debug.Log("Try to quit application");
			Application.Quit();
		}
	}
}
