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
        /// <summary>
        /// Exit method
        /// </summary>
        public void ExecuteQuitApplication()
		{
			Debug.Log("Try to quit application");
			NTProxiesProvider.Application.Quit();
		}
	}
}
