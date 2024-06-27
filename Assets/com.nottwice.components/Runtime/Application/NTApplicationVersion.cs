using NotTwice.Proxies.Runtime;
using NotTwice.Proxies.Runtime.Interfaces;
using TMPro;
using UnityEngine;

namespace NotTwice.Components.Runtime.Application
{
    /// <summary>
    /// Component for displaying the current version of the application
    /// </summary>
    [AddComponentMenu("NotTwice/Application/ApplicationVersion")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TMP_Text))]
	public class NTApplicationVersion : MonoBehaviour
	{
		private INTApplication _applicationInternal;

		public INTApplication Application
		{
			private get
			{
				if(_applicationInternal == null )
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

		public void OnEnable()
		{
			GetComponent<TMP_Text>().text += Application.Version;

			Debug.Log("The application version is displayed");
		}
	}
}
