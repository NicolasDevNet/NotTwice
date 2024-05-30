using Assets.com.nottwice.lifetime.Runtime;
using UnityEngine;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// Component for changing the sprite value of an spriterenderer component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/SpriteRendererColorChanger")]
	[DisallowMultipleComponent]
	public class SpriteRendererColorChanger : MonoBehaviour
	{
		public SpriteRenderer SpriteRendererComponent;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void ChangeFromSpriteSource(Color color)
		{
			_logger.Log(LogType.Log, $"New color for component {SpriteRendererComponent.name}: {color}");

			SpriteRendererComponent.color = color;
		}
	}
}
