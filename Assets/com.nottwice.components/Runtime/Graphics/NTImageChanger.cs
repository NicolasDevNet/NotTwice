using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace NotTwice.Components.Runtime.Graphics
{
	/// <summary>
	/// Component for changing the sprite value of an image component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/Graphics/ImageChanger")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Image))]
	public class NTImageChanger : MonoBehaviour
	{
        [ReadOnly]
        public Image ImageComponent;

        public void Start()
        {
            ImageComponent = GetComponent<Image>();
        }

        /// <summary>
        /// Method for changing an image sprite
        /// </summary>
        public void ChangeFromSpriteSource(Sprite sprite)
		{
			Debug.Log($"New sprite for component {ImageComponent.name}: {sprite.name}");

			ImageComponent.sprite = sprite;
		}
	}
}
