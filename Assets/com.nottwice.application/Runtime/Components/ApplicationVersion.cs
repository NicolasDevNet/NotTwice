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

		public void OnEnable()
		{
			if (!TryGetComponent(out _textComponent))
			{
				throw new MissingComponentException($"The {typeof(TextMeshProUGUI).FullName} component is missing from the GameObject of the {typeof(ApplicationVersion).FullName} component.");
			}

			_textComponent.text += ApplicationInstancesContainer.Application.GetApplicationVersion();

			ApplicationInstancesContainer.Logger.Log(LogType.Log, "The application version is displayed");

			DestroyImmediate(gameObject);
		}
	}
}
