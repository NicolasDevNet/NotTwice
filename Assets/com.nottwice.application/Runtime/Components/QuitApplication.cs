using Assets.com.nottwice.application.Runtime.Proxies;
using Assets.com.nottwice.lifetime.Runtime;
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
		private IApplication _application;

		private ILogger _logger;

		public void Awake()
		{
			_application = AppContainer.Get<IApplication>();
			_logger = AppContainer.Get<ILogger>();
		}

		public void ExecuteQuitApplication()
		{
			_logger.Log(LogType.Log ,"Try to quit application");
			_application.Quit();
		}
	}
}
