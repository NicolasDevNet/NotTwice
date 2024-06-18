using NaughtyAttributes;
using UnityEngine;

namespace NotTwice.Components.Runtime.Graphics
{
	/// <summary>
	/// Component for changing the sprite value of an spriterenderer component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/Graphics/SpriteRendererChanger")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(SpriteRenderer))]
	public class NTSpriteRendererChanger : MonoBehaviour
	{
		[ReadOnly]
		public SpriteRenderer SpriteRendererComponent;

        public void Start()
        {
            SpriteRendererComponent = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Method for changing the sprite of a <see cref="SpriteRenderer"/> from a <see cref="Sprite"/>.
        /// </summary>
        public void ChangeFromSpriteSource(Sprite sprite)
		{
			Debug.Log($"New sprite for component {SpriteRendererComponent.name}: {sprite.name}");

			SpriteRendererComponent.sprite = sprite;
		}
	}
}
