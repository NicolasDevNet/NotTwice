using Assets.com.nottwice.application.Runtime.Proxies;
using TMPro;
using UnityEngine;

namespace Assets.com.nottwice.application.Runtime.Components
{
	/// <summary>
	/// Component for displaying the current version of the application
	/// </summary>
	[AddComponentMenu("NotTwice/Application/ApplicationVersion")]
	[DisallowMultipleComponent]
	public class ApplicationVersion : MonoBehaviour
	{
		private TextMeshProUGUI _textComponent;

		private IApplication _applicationInternal;

		private IApplication _application
		{
			get
			{
				if(_applicationInternal == null )
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

		public void OnEnable()
		{
			if (!TryGetComponent(out _textComponent))
			{
				throw new MissingComponentException($"The {typeof(TextMeshProUGUI).FullName} component is missing from the GameObject of the {typeof(ApplicationVersion).FullName} component.");
			}

			_textComponent.text += _application.GetApplicationVersion();

			Debug.Log("The application version is displayed");
		}
	}
}
