using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
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

		public void ChangeFromColorVariable(NTColorVariable colorVariable)
		{
			Debug.Log($"New color for component {ImageComponent.name}: {colorVariable}");

			ImageComponent.color = colorVariable.Value;
		}

		public void ChangeFromColorSource(Color color)
		{
			Debug.Log($"New color for component {ImageComponent.name}: {color}");

			ImageComponent.color = color;
		}
	}
}
