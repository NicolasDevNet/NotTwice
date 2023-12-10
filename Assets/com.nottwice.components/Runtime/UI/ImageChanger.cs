using Assets.com.nottwice.lifetime.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// Component for changing the sprite value of an image component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/ImageChanger")]
	[DisallowMultipleComponent]
	public class ImageChanger : MonoBehaviour
	{
		public Image ImageComponent;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void ChangeFromSpriteSource(Sprite sprite)
		{
			_logger.Log(LogType.Log, $"New sprite for component {ImageComponent.name}: {sprite.name}");

			ImageComponent.sprite = sprite;
		}
	}
}
