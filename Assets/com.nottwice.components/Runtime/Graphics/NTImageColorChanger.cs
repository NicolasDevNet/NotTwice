using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using UnityEngine;
using UnityEngine.UI;

namespace NotTwice.Components.Runtime.Graphics
{
	/// <summary>
	/// Component for changing the color value of an image component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/Graphics/ImageColorChanger")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Image))]
	public class NTImageColorChanger : MonoBehaviour
	{
		[ReadOnly]
		public Image ImageComponent;

        public void Start()
        {
            ImageComponent = GetComponent<Image>();
        }

        /// <summary>
        /// A method for changing the color of an image according to <see cref="NTColorVariable"/>
        /// </summary>
        public void ChangeFromColorVariable(NTColorVariable colorVariable)
		{
			Debug.Log($"New color for component {ImageComponent.name}: {colorVariable}");

			ImageComponent.color = colorVariable.Value;
		}

        /// <summary>
        /// A method for changing the color of an image according to <see cref="Color"/>
        /// </summary>
        public void ChangeFromColorSource(Color color)
		{
			Debug.Log($"New color for component {ImageComponent.name}: {color}");

			ImageComponent.color = color;
		}
	}
}
