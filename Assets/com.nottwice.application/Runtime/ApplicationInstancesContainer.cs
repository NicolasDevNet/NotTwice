using Assets.com.nottwice.application.Runtime.Proxies;
using UnityEngine;

namespace Assets.com.nottwice
{
	/// <summary>
	/// Static instance container used for global application management
	/// </summary>
	public static class ApplicationInstancesContainer
	{
		private static ILogger _logger;

		public static ILogger Logger
		{
			get
			{
				if (_logger == null)
				{
					_logger = new Logger(Debug.unityLogger.logHandler);
				}

				return _logger;
			}
			set
			{
				_logger = value;
			}
		}

		private static IApplication _application;

		public static IApplication Application
		{
			get
			{
				if (_application == null)
				{
					_application = DefaultApplicationProxy.Instance;
				}

				return _application;
			}
			set
			{
				_application = value;
			}
		}
	}
}
