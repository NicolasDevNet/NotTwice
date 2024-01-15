using NaughtyAttributes;
using UnityEngine;

namespace Assets.com.nottwice.components.Runtime.UI
{

	/// <summary>
	/// Component for making available the children of the gameobject associated with the same type T
	/// </summary>
	public abstract class CollectionContainer<T> : MonoBehaviour
		where T : Component
	{
		[ReadOnly]
		public T[] Children;

		public void Awake()
		{
			Children = GetComponentsInChildren<T>(true);
		}
	}
}
