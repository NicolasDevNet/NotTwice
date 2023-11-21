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
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Redirect to {targetUrl.Value}");
			ApplicationInstancesContainer.Application.OpenURL(targetUrl.Value);
		}
	}
}
