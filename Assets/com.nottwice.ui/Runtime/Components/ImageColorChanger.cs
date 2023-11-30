using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component for changing the color value of an image component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/ImageColorChanger")]
	[DisallowMultipleComponent]
	public class ImageColorChanger : MonoBehaviour
	{
		public Image ImageComponent;

		public void ChangeFromSpriteSource(Color color)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"New color for component {ImageComponent.name}: {color}");

			ImageComponent.color = color;
		}
	}
}
