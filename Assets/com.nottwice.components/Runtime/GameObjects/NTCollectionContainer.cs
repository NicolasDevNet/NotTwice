using NaughtyAttributes;
using UnityEngine;

namespace NotTwice.Components.Runtime.GameObjects
{

	/// <summary>
	/// Component for making available the children of the gameobject associated with the same type T
	/// </summary>
	public abstract class NTCollectionContainer<T> : MonoBehaviour
		where T : Component
	{
        /// <summary>
        /// Collection of T-type children for this game object
        /// </summary>
        [ReadOnly, Tooltip("Collection of T-type children for this game object")]
		public T[] Children;

		public void Awake()
		{
			Children = GetComponentsInChildren<T>(true);
		}
	}
}
