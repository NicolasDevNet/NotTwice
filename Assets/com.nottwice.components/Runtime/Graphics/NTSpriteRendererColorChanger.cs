using NaughtyAttributes;
using UnityEngine;

namespace NotTwice.Components.Runtime.Graphics
{
	/// <summary>
	/// Component for changing the sprite value of an spriterenderer component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/Graphics/SpriteRendererColorChanger")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(SpriteRenderer))]
	public class NTSpriteRendererColorChanger : MonoBehaviour
	{
		[ReadOnly]
		public SpriteRenderer SpriteRendererComponent;

		public void Start ()
		{
			SpriteRendererComponent = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Method for changing the color of <see cref="SpriteRenderer"/> from <see cref="Color"/>.
        /// </summary>
        public void ChangeFromSpriteSource(Color color)
		{
			Debug.Log($"New color for component {SpriteRendererComponent.name}: {color}");

			SpriteRendererComponent.color = color;
		}
	}
}
