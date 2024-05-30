using Assets.com.nottwice.application.Runtime.Proxies;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
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
		public NTStringVariable UrlToRedirect;

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

		public void ExecuteOpeningURL()
		{
			if(UrlToRedirect == null)
			{
				throw new MissingComponentException("A StringVariable is needed to use this method.");
			}

			ExecuteOpeningURL(UrlToRedirect);
		}

		public void ExecuteOpeningURL(NTStringVariable targetUrl)
		{
			Debug.Log($"Redirect to {targetUrl.Value}");
			_application.OpenURL(targetUrl.Value);
		}
	}
}
