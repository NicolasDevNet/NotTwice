using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace NotTwice.Components.Runtime.GameObjects
{
    /// <summary>
    /// Game object behavior extension class for adding functionality
    /// </summary>
    [AddComponentMenu("NotTwice/GameObjects/GameObjectExtender")]
	[DisallowMultipleComponent]
	public class NTGameObjectExtender : MonoBehaviour
	{
		/// <summary>
		/// Méthode permettant de détruire tous les enfants de ce game object
		/// </summary>
		[Button]
		public void ClearChildren()
		{
			var children = new List<GameObject>();

			foreach (Transform child in transform)
			{
				children.Add(child.gameObject);
			}

			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
		}
	}
}
