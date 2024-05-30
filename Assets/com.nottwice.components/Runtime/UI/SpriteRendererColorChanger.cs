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

		public void ChangeFromSpriteSource(Color color)
		{
			Debug.Log($"New color for component {SpriteRendererComponent.name}: {color}");

			SpriteRendererComponent.color = color;
		}
	}
}
