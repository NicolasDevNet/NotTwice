using Assets.com.nottwice.lifetime.Runtime;
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

		public void ChangeFromSpriteSource(Color color)
		{
			_logger.Log(LogType.Log, $"New color for component {ImageComponent.name}: {color}");

			ImageComponent.color = color;
		}
	}
}
