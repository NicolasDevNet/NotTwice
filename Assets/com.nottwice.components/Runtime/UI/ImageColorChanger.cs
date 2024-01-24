using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// Component for changing the color value of an image component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/ImageColorChanger")]
	[DisallowMultipleComponent]
	public class ImageColorChanger : MonoBehaviour
	{
		public Image ImageComponent;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void ChangeFromColorVariable(ColorVariable colorVariable)
		{
			_logger.Log(LogType.Log, $"New color for component {ImageComponent.name}: {colorVariable}");

			ImageComponent.color = colorVariable.Value;
		}

		public void ChangeFromColorSource(Color color)
		{
			_logger.Log(LogType.Log, $"New color for component {ImageComponent.name}: {color}");

			ImageComponent.color = color;
		}
	}
}
