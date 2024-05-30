using Assets.com.nottwice.application.Runtime.Proxies;
using Assets.com.nottwice.lifetime.Runtime;
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

		private IApplication _application;

		private ILogger _logger;

		public void Awake()
		{
			_application = AppContainer.Get<IApplication>();
			_logger = AppContainer.Get<ILogger>();
		}

		public void OnEnable()
		{
			if (!TryGetComponent(out _textComponent))
			{
				throw new MissingComponentException($"The {typeof(TextMeshProUGUI).FullName} component is missing from the GameObject of the {typeof(ApplicationVersion).FullName} component.");
			}

			_textComponent.text += _application.GetApplicationVersion();

			_logger.Log(LogType.Log, "The application version is displayed");
		}
	}
}
