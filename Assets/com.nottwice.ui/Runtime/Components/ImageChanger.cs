using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component for changing the sprite value of an image component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/ImageChanger")]
	[DisallowMultipleComponent]
	public class ImageChanger : MonoBehaviour
	{
		public Image ImageComponent;

		public void ChangeFromSpriteSource(Sprite sprite)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"New sprite for component {ImageComponent.name}: {sprite.name}");

			ImageComponent.sprite = sprite;
		}
	}
}
