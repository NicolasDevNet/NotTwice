using UnityEngine;

namespace Assets.com.nottwice.ui.Runtime.Components
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
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"New color for component {SpriteRendererComponent.name}: {color}");

			SpriteRendererComponent.color = color;
		}
	}
}
