using UnityEngine;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component for changing the sprite value of an spriterenderer component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/SpriteRendererChanger")]
	[DisallowMultipleComponent]
	public class SpriteRendererChanger : MonoBehaviour
	{
		public SpriteRenderer SpriteRendererComponent;

		public void ChangeFromSpriteSource(Sprite sprite)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"New sprite for component {SpriteRendererComponent.name}: {sprite.name}");

			SpriteRendererComponent.sprite = sprite;
		}
	}
}
