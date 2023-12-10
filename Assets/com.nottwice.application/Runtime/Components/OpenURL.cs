using Assets.com.nottwice.application.Runtime.Proxies;
using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using UnityEngine;

namespace Assets.com.nottwice.application.Runtime.Components
{
	/// <summary>
	/// Component to redirect the user to the url when opening a new browser or tab.
	/// </summary>
	[AddComponentMenu("NotTwice/Application/OpenURL")]
	[DisallowMultipleComponent]
	public class OpenURL : MonoBehaviour
	{
		[Tooltip("Optional parameter used if the use of the component requires a method without parameters.")]
		public StringVariable UrlToRedirect;

		private IApplication _application;

		private ILogger _logger;

		public void Awake()
		{
			_application = AppContainer.Get<IApplication>();
			_logger = AppContainer.Get<ILogger>();
		}

		public void ExecuteOpeningURL()
		{
			if(UrlToRedirect == null)
			{
				throw new MissingComponentException("A StringVariable is needed to use this method.");
			}

			ExecuteOpeningURL(UrlToRedirect);
		}

		public void ExecuteOpeningURL(StringVariable targetUrl)
		{
			_logger.Log(LogType.Log, $"Redirect to {targetUrl.Value}");
			_application.OpenURL(targetUrl.Value);
		}
	}
}
